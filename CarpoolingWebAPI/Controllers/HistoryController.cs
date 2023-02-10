using CarpoolingWebAPI.Interfaces;
using CarPoolingWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarpoolingWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class HistoryController : ControllerBase
    {
        private IHistoryServices historyServices;

        public HistoryController(IHistoryServices historyServices)
        {
            this.historyServices = historyServices;
        }


        [HttpGet("{userId}/BookingHistory")]
        public List<Booking> GenerateBookingHistory(string userId)
        {
            return historyServices.GetBookingHistory(userId);
        }

        [HttpGet("{userId}/OfferHistory")]
        public List<History> GenerateOfferHistory(string userId)
        {
            return historyServices.GetOfferHistory(userId);
        }
    }
}
