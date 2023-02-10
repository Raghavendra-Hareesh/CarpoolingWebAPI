using CarpoolingWebAPI.Services;
using CarpoolingWebAPI.ViewModels;
using CarPoolingWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarpoolingWebAPI.Controllers
{
    [ApiController]
    [Route("api/Rides")]

    public class RidesController : ControllerBase
    {
        private AppDbContext appDbContext;
        private IBookingServices bookingServices;

        public RidesController(AppDbContext appDbContext, IBookingServices bookingServices)
        {            
            this.appDbContext = appDbContext;
            this.bookingServices = bookingServices;
        }

        [HttpGet("Available")]
        public async Task<IActionResult> ShowAllRides()
        {   
            return Ok(await appDbContext.Rides.ToListAsync());
        }

        [HttpGet("Bookings")]
        public async Task<IActionResult> ShowBookings()
        {
            return Ok(await appDbContext.Bookings.ToListAsync());
        }

        [HttpPost("Filter")]
        public IEnumerable<Ride> Filter(RideRequest rideRequest)
        {
            return bookingServices.FilterRides(rideRequest).ToList();
        }

        [HttpPost("Book")]
        public async Task<ActionResult> Book(BookingRequest bookingRequest)
        {
            Ride? ride = await appDbContext.Rides.Where(_ => _.OfferID.Equals(bookingRequest.OfferID)).FirstOrDefaultAsync();

            if (ride == null) return NotFound("Ride Doesn't Exist");

            string status = bookingServices.BookRide(bookingRequest, ride);

            return Ok(status);
        }
    }
}