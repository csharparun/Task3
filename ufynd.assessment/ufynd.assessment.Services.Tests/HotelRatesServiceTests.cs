using System;
using NUnit.Framework;
using ufynd.assessment.Contracts.Interfaces;

namespace ufynd.assessment.Services.Tests
{
    public class HotelRatesServiceTests
    {
        private IHotelRatesService hotelRatesService;

        [SetUp]
        public void Setup()
        {
            this.hotelRatesService = new HotelRatesService();
        }

        [Test]
        public void HotelRatesService_GetHotelDetailsByHotelIdAndArrivalDate_ValidTest()
        {
            int inputHotelId = 7294;
            var result = this.hotelRatesService.GetHotelDetailsByHotelIdAndArrivalDate(inputHotelId, new DateTime(2016, 3, 15));
            Assert.IsNotNull(result);
            Assert.AreEqual(inputHotelId, result.Hotel.HotelID);
        }

        [Test]
        public void HotelRatesService_GetHotelDetailsByHotelIdAndArrivalDate_NullTest()
        {
            int inputHotelId = 1;
            var result = this.hotelRatesService.GetHotelDetailsByHotelIdAndArrivalDate(inputHotelId, new DateTime(2016, 3, 15));
            Assert.IsNull(result);
        }
    }
}