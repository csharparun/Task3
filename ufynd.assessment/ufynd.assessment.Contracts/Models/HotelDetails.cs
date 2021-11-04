using System;
using System.Collections.Generic;
using System.Text;

namespace ufynd.assessment.Contracts.Models
{
    public class HotelDetails
    {
        public Hotel Hotel { get; set; }

        public List<HotelRate> HotelRates { get; set; }
    }
}
