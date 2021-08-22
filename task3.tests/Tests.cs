using System;
using System.Collections.Generic;
using NUnit.Framework;
using task3.webapi.Models;
using task3.webapi.Services;
using task3.webapi.Controllers;
using Moq;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace task3.tests
{
    public class Tests
    {
        private List<MainHotel> _mainHotels;
        private HotelRatesService _service;
        private JsonMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mainHotels = new List<MainHotel>{
                new MainHotel
                {
                    hotel = new Hotel { classification = 1, hotelId = 1, name = "Test Hotel", reviewscore = 1.2 },
                    hotelRates = new List<HotelRate> {
                        new HotelRate {
                            adults=2,
                            los=1,
                            price= new Price {currency = "EUR", numericFloat=325.5, numericInteger=32550},
                            rateDescription = "Test Description",
                            rateID = "_TESTID",
                            rateName = "My Test RateName",
                            rateTags = new List<RateTag>{new RateTag{name = "Myrate", shape = true}},
                            targetDay = DateTime.Now.AddDays(5).Date
                            },
                        new HotelRate {
                            adults=2,
                            los=1,
                            price= new Price {currency = "EUR", numericFloat=325.5, numericInteger=32550},
                            rateDescription = "Test Description",
                            rateID = "_TESTID",
                            rateName = "My Test RateName",
                            rateTags = new List<RateTag>{new RateTag{name = "Myrate", shape = true}},
                            targetDay = DateTime.Now.AddDays(4).Date
                        },
                        new HotelRate {
                            adults=2,
                            los=1,
                            price= new Price {currency = "EUR", numericFloat=325.5, numericInteger=32550},
                            rateDescription = "Test Description",
                            rateID = "_TESTID",
                            rateName = "My Test RateName",
                            rateTags = new List<RateTag>{new RateTag{name = "Myrate", shape = true}},
                            targetDay = DateTime.Now.AddDays(3).Date
                        }
                    }

                },

                new MainHotel
                {
                    hotel = new Hotel { classification = 1, hotelId = 2, name = "Test2 Hotel", reviewscore = 5.2 },
                    hotelRates = new List<HotelRate> {
                        new HotelRate {
                            adults=2,
                            los=1,
                            price= new Price {currency = "EUR", numericFloat=425.5, numericInteger=42550},
                            rateDescription = "Test2 Description",
                            rateID = "_TESTID2",
                            rateName = "My Test2 RateName",
                            rateTags = new List<RateTag>{new RateTag{name = "Myrate2", shape = true}},
                            targetDay = DateTime.Now.AddDays(5).Date
                            },
                        new HotelRate {
                            adults=2,
                            los=1,
                            price= new Price {currency = "EUR", numericFloat=425.5, numericInteger=42550},
                            rateDescription = "Test2 Description",
                            rateID = "_TESTID2",
                            rateName = "My Test2 RateName",
                            rateTags = new List<RateTag>{new RateTag{name = "Myrate2", shape = true}},
                            targetDay = DateTime.Now.AddDays(4).Date
                            }
                    }
                }

            };
        }

        [Test]
        public void GetHotelRates_Returns_Correct_Number_Of_Results()
        {
            //Arrange
            var mockService = new Mock<IHotelRatesService>();

            var filteredHotel = _mainHotels.FirstOrDefault(h => h.hotel.hotelId == 1);
            var expectedFilteredRates = filteredHotel.hotelRates
                .Where(r => r.targetDay.Date == DateTime.Now.AddDays(4).Date);
           
            MainHotel mainHotel = new MainHotel { hotel = filteredHotel.hotel, hotelRates = expectedFilteredRates.ToList()};

            mockService
                .Setup(h => h.GetHotelRates(It.IsAny<int>(), It.IsAny<DateTime>()))
                .Returns(() => mainHotel);

            var controller = new HotelRatesController(mockService.Object);

            //act
            IActionResult responseObject = controller.GetHotelRates(1, DateTime.Now.AddDays(4));
            var response = responseObject as OkObjectResult;

            //assert
            Assert.NotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
            Assert.IsInstanceOf<MainHotel>(response.Value);
            Assert.AreEqual(expectedFilteredRates.Count(), ((MainHotel)response.Value).hotelRates.Count);
        }
    }
}