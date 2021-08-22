using System;
using task3.webapi.Models;

namespace task3.webapi.Services
{
    public interface IHotelRatesService
    {
         MainHotel GetHotelRates(int hotelId, DateTime arrivalDate);
    }
}