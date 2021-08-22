using System;
using System.Collections.Generic;
using System.Linq;
using task3.webapi.Models;

namespace task3.webapi.Services
{
    public class HotelRatesService : IHotelRatesService
    {
        private IJsonMapper _mapper;
        private IEnumerable<MainHotel> _mainHotels;

        public HotelRatesService(IJsonMapper mapper){
            _mapper = mapper;
            //initilize available hotes with json file
            _mainHotels = _mapper.Deserialize<IEnumerable<MainHotel>>(new List<MainHotel>(), "task 3 - hotelsrates.json");
        }

        public MainHotel GetHotelRates(int hotelId, DateTime arrivalDate){
            //filter hotes by id
            var filteredHotel = _mainHotels.SingleOrDefault(h => h.hotel.hotelId == hotelId);
            if (filteredHotel == null)
            {
                throw new ArgumentNullException("Hotel not found");
            }
            //filter hotel rates by provided arrival date
            var filteredRates = filteredHotel.hotelRates.Where(r => r.targetDay.Date == arrivalDate.Date);
            return new MainHotel {hotel = filteredHotel.hotel, hotelRates = filteredRates.ToList()};
        } 
    }
}