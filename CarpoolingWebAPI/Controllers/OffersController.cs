using CarpoolingWebAPI.Interfaces;
using CarpoolingWebAPI.Services;
using CarpoolingWebAPI.ViewModels;
using CarPoolingWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CarpoolingWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private IOfferServices offersServices;

        public OffersController(IOfferServices offersServices)
        {
            this.offersServices = offersServices;
        }

        [HttpPost]
        public IActionResult Offer(OfferRequest offerRequest)
        {
            Ride ride = offersServices.OfferRide(offerRequest);

            return Ok(ride);
        }

    }
}
