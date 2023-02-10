using CarpoolingWebAPI.Interfaces;
using CarPoolingWebAPI.Models;

namespace CarpoolingWebAPI.Services
{
    public class HistoryServices : IHistoryServices
    {
        private AppDbContext appDbContext;

        public HistoryServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public List<Booking> GetBookingHistory(string userId)
        {
            User? user = appDbContext.Users.Where(_ => _.UserID.Equals(userId)).FirstOrDefault();

            string[] bookingIDs = user.BookingsMade.Split(", ");

            return (from _ in appDbContext.Bookings where bookingIDs.Contains(_.BookingID) select _).ToList();
        }

        public List<History> GetOfferHistory(string userId)
        {
            User? user = appDbContext.Users.Where(_ => _.UserID.Equals(userId)).FirstOrDefault();

            string[] offerIDs = user.OffersMade.Split(", ");

            return (from _ in appDbContext.History where offerIDs.Contains(_.OfferID) select _).ToList();
        }

    }
}
