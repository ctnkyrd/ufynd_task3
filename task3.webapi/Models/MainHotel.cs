using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace task3.webapi.Models
{
    public class MainHotel
    {
        public Hotel hotel { get; set;}
        public List<HotelRate> hotelRates { get; set;}
    }
}