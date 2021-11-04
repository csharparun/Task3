using System;
using System.Collections.Generic;
using System.Text;
using ufynd.assessment.Contracts.Models;

namespace ufynd.assessment.Contracts.Interfaces
{
    public interface IHotelRatesService
    {
        HotelDetails GetHotelDetailsByHotelIdAndArrivalDate(int hotelId, DateTime arrivalDate);
    }
}
