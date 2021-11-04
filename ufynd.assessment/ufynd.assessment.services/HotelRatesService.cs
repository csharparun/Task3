using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using ufynd.assessment.Contracts.Interfaces;
using ufynd.assessment.Contracts.Models;

namespace ufynd.assessment.Services
{
    public class HotelRatesService : IHotelRatesService
    {
        public HotelDetails GetHotelDetailsByHotelIdAndArrivalDate(int hotelId, DateTime arrivalDate)
        {
            // File content can be either stream or string or json object. 
            // currently reading from the solution.
            string filePath = string.Concat(AssemblyDirectory, @"\Files\task 3 - hotelsrates.json");
            if (!File.Exists(filePath))
            {
                return null;
            }

            var jsonFile = File.ReadAllText(filePath);

            var results = JsonConvert.DeserializeObject<IList<HotelDetails>>(jsonFile);
            var item = results.FirstOrDefault(i => i.Hotel?.HotelID == hotelId);
            if (item != null)
            {
                HotelDetails result = new HotelDetails();
                result.Hotel = item.Hotel;
                var rates = new List<HotelRate>();
                foreach (var hotelRate in item.HotelRates)
                {
                    DateTime dateTime;
                    if (DateTime.TryParse(Convert.ToString(hotelRate.TargetDay), out dateTime) && dateTime.Date.Equals(arrivalDate))
                    {
                        rates.Add(hotelRate);
                    }
                }

                result.HotelRates = rates;
                return result;
            }
            else
            {
                return null;
            }
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
