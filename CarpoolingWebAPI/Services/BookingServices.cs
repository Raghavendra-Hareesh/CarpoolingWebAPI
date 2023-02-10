using CarpoolingWebAPI.ViewModels;
using CarPoolingWebAPI.Models;

namespace CarpoolingWebAPI.Services
{
    public class BookingServices : IBookingServices
    {
        private AppDbContext appDbContext;

        public BookingServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Ride> FilterRides(RideRequest filterARideRequest)
        {
            var _fromPlace = filterARideRequest.FromPlace;
            var _toPlace = filterARideRequest.ToPlace;
            var _date = filterARideRequest.Date;
            var _time = filterARideRequest.Time;
            var _seatsRequired = filterARideRequest.SeatsRequired;

            var filteredRides = appDbContext.Rides.AsEnumerable().Where(_ => _.Date == _date && _.Time == _time && (_.Stops.IndexOf(_fromPlace) < _.Stops.IndexOf(_toPlace) &&
                                                               //CalculateAvailableSeats(_.Stops, _.SeatsPerStop, _fromPlace) >= _seatsRequired &&
                                                               CheckAvailability(_.Stops, _.SeatsPerStop, _fromPlace, _toPlace, _seatsRequired)));

            return filteredRides;
        }

        private bool CheckAvailability(string stops, string seatsPerStop, string fromPlace, string toPlace, int seatsRequired)
        {
            List<string> seatCounts = stops.Split(", ").ToList();
            int startIndex = seatCounts.IndexOf(fromPlace);
            int endIndex = seatCounts.IndexOf(toPlace);

            List<string> seatsList = seatsPerStop.Split(", ").ToList();

            /*foreach(string seats in seatsList)
                Console.WriteLine(seats);*/

            for (int i = startIndex; i < endIndex; i++)
            {
                if (Convert.ToInt32(seatsList[i]) < seatsRequired)
                    return false;
            }

            return true;
        }

        /*private int CalculateAvailableSeats(string stops, string seatsPerStop, string fromPlace)
        {
            int x = Convert.ToInt32(seatsPerStop.Split(", ")[stops.Split(", ").ToList().IndexOf(fromPlace)]);

            return x;
        }*/

        public string BookRide(BookingRequest bookingRequest, Ride? ride)
        {
            //Console.WriteLine("incoming" + ride.SeatsPerStop);
            //Console.WriteLine(IsActiveRide(ride));

            string statusMsg = "";

            if (IsActiveRide(ride.SeatsPerStop))
            {
                int indexOfFromStop = ride.Stops.Split(", ").ToList().IndexOf(bookingRequest.FromPlace);
                int indexOfToStop = ride.Stops.Split(", ").ToList().IndexOf(bookingRequest.ToPlace);

                string[] seatCount = ride.SeatsPerStop.Split(", ");

                for (int i = indexOfFromStop; i < indexOfToStop; i++)
                {
                    int seatsAtThatStop = Convert.ToInt32(seatCount[i]);
                    seatsAtThatStop -= bookingRequest.NumOfSeatsBooked;
                    seatCount[i] = "" + seatsAtThatStop;
                }

                ride.SeatsPerStop = string.Join(", ", seatCount);

                var booking = new Booking()
                {
                    BookingID = Guid.NewGuid().ToString(),
                    OfferID = bookingRequest.OfferID,
                    FromPlace = bookingRequest.FromPlace,
                    ToPlace = bookingRequest.ToPlace,
                    NumberOfSeatsBooked = bookingRequest.NumOfSeatsBooked,
                    DriverID = ride.DriverID,   
                    PassengerID = bookingRequest.PassengerID
                };

                appDbContext.Bookings.AddAsync(booking);

                User? passenger = appDbContext.Users.Where(_ => _.UserID.Equals(bookingRequest.PassengerID)).FirstOrDefault();

                passenger.BookingsMade += booking.BookingID + ", ";

                History? rideHistory = appDbContext.History.Where(_ => _.OfferID.Equals(bookingRequest.OfferID)).FirstOrDefault();

                ride.BookingList += booking.BookingID + ", ";
                rideHistory.BookingList = ride.BookingList;                                                                

                rideHistory.SeatsPerStop = ride.SeatsPerStop;

                if(!IsActiveRide(ride.SeatsPerStop))
                {
                    appDbContext.Rides.Remove(ride);
                    appDbContext.SaveChanges();
                }

                appDbContext.SaveChanges();

                statusMsg = "Ride Booked !";
            }
            else
            {
                statusMsg = "No Matches Found !";                
            }

            return statusMsg;
        }

        public bool IsActiveRide(string SeatsPerStop)
        {
            string[] seats = SeatsPerStop.Split(", ");

            for (int i = 0; i < seats.Length - 2; i++)
            {
                if (seats[i] != "0" && seats[i + 1] != "0")  // 2 0 0 0 0 0 2 
                    return true;
            }

            return false;
        }
    }
}
