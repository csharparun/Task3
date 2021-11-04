using System;
using System.Collections.Generic;
using System.Text;

namespace ufynd.assessment.Contracts.Models
{
    public class Hotel
    {
        public int Classification { get; set; }
        
        public int HotelID { get; set; }
        
        public string Name { get; set; }
        
        public double ReviewScore { get; set; }
    }
}
