using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ufynd.assessment.Contracts.Interfaces;
using ufynd.assessment.Contracts.Models;
using ufynd.assessment.task3.WebAPI.Controllers;

namespace ufynd.assessment.task3.WebAPI.Tests
{
    public class HotelRatesControllerTests
    {
        private Mock<IHotelRatesService> mockHotelRatesService;

        private HotelRatesController hotelRatesController;

        [SetUp]
        public void Setup()
        {
            this.mockHotelRatesService = new Mock<IHotelRatesService>();
            this.hotelRatesController = new HotelRatesController(this.mockHotelRatesService.Object);
        }

        [Test]
        public void HotelRatesController_GetHotelRates_InvalidHotelIdTest()
        {
            var result = this.hotelRatesController.GetHotelRates(0, DateTime.UtcNow.ToLongDateString());
            Assert.AreEqual(StatusCodes.Status400BadRequest, ((StatusCodeResult)result).StatusCode);
        }

        [Test]
        public void HotelRatesController_GetHotelRates_InvalidArrivalDateTest()
        {
            var result = this.hotelRatesController.GetHotelRates(1234, "error");
            Assert.AreEqual(StatusCodes.Status400BadRequest, ((StatusCodeResult)result).StatusCode);
        }

        [Test]
        public void HotelRatesController_GetHotelRates_ResultIsNullTest()
        {
            HotelDetails hotelDetails = null;
            this.mockHotelRatesService.Setup(e => e.GetHotelDetailsByHotelIdAndArrivalDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(hotelDetails);
            var result = this.hotelRatesController.GetHotelRates(1234, DateTime.UtcNow.ToLongDateString());
            Assert.AreEqual(StatusCodes.Status404NotFound, ((StatusCodeResult)result).StatusCode);
        }

        [Test]
        public void HotelRatesController_GetHotelRates_ValidTest()
        {
            List<HotelRate> rates = new List<HotelRate>();
            rates.Add(new HotelRate()
            {
                Adults = 1,
                Los = 2,
                Price = new Price()
                {
                    Currency = "EUR",
                    NumericFloat = 1.0,
                    NumericInteger = 1
                },
            });
            HotelDetails hotelDetails = new HotelDetails()
            {
                Hotel = new Hotel()
                {
                    Classification = 1,
                    HotelID = 1234,
                    Name = "Paris",
                    ReviewScore = 1
                },
                HotelRates = rates
            };
            this.mockHotelRatesService.Setup(e => e.GetHotelDetailsByHotelIdAndArrivalDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(hotelDetails);
            var result = this.hotelRatesController.GetHotelRates(1234, DateTime.UtcNow.ToLongDateString());
            var resultDetails = (HotelDetails)((OkObjectResult)result).Value;
            Assert.AreEqual(hotelDetails.Hotel.HotelID, resultDetails.Hotel.HotelID);
            Assert.AreEqual(hotelDetails.Hotel.Name, resultDetails.Hotel.Name);
            Assert.AreEqual(hotelDetails.Hotel.Classification, resultDetails.Hotel.Classification);
            Assert.AreEqual(hotelDetails.Hotel.ReviewScore, resultDetails.Hotel.ReviewScore);
        }

        [Test]
        public void HotelRatesController_GetHotelRates_ExceptionTest()
        {
            this.mockHotelRatesService.Setup(e => e.GetHotelDetailsByHotelIdAndArrivalDate(It.IsAny<int>(), It.IsAny<DateTime>())).Throws(new Exception());
            var result = this.hotelRatesController.GetHotelRates(1234, DateTime.UtcNow.ToLongDateString());
            Assert.AreEqual(StatusCodes.Status500InternalServerError, ((StatusCodeResult)result).StatusCode);
        }
    }
}