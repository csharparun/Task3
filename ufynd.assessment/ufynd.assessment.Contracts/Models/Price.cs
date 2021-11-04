using System;
using System.Collections.Generic;
using System.Text;

namespace ufynd.assessment.Contracts.Models
{
    public class Price
    {
        public string Currency { get; set; }

        public double NumericFloat { get; set; }
        
        public int NumericInteger { get; set; }
    }
}
