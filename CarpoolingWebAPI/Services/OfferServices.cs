using CarpoolingWebAPI.Interfaces;
using CarpoolingWebAPI.ViewModels;
using CarPoolingWebAPI.Models;

namespace CarpoolingWebAPI.Services
{
    public class OfferServices : IOfferServices
    {
        private AppDbContext appDbContext;

        public OfferServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Ride OfferRide(OfferRequest offerRequest)
        {
            int totalSeats = offerRequest.SeatsAvailable;
            string seatsPerStop = "";
            int stopsCount = offerRequest.Stops.Split(", ").Count();

            for (int i = 0; i < stopsCount; i++)
                seatsPerStop += totalSeats + ", ";

            string _offerID = Guid.NewGuid().ToString();

            Ride ride = new()
            {
                OfferID = _offerID,
                DriverID = offerRequest.DriverID,
                Stops = offerRequest.Stops,
                TotalSeats = offerRequest.SeatsAvailable,
                SeatsPerStop = seatsPerStop,
                BookingList = "",
                Date = offerRequest.Date,
                Time = offerRequest.Time,
                StartPoint = offerRequest.StartPoint,
                EndPoint = offerRequest.EndPoint,
                Price = offerRequest.Price,
            };

            History history = new()
            {
                OfferID = _offerID,
                DriverID = offerRequest.DriverID,
                Stops = offerRequest.Stops,
                TotalSeats = offerRequest.SeatsAvailable,
                SeatsPerStop = seatsPerStop,
                BookingList = "",
                Date = offerRequest.Date,
                Time = offerRequest.Time,
                StartPoint = offerRequest.StartPoint,
                EndPoint = offerRequest.EndPoint,
                Price = offerRequest.Price,
            };

            //Ride ride = new Ride(rideModel);
            //History history = new History(rideModel);

            appDbContext.History.Add(history);
            appDbContext.Rides.Add(ride);

            User? user = appDbContext.Users.Where(_ => _.UserID.Equals(offerRequest.DriverID)).FirstOrDefault();

            user.OffersMade += ride.OfferID + ", ";

            appDbContext.SaveChanges();

            return ride;
        }
    }
}
