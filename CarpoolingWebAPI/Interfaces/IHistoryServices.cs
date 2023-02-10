using CarPoolingWebAPI.Models;

namespace CarpoolingWebAPI.Interfaces
{
    public interface IHistoryServices
    {
        public List<Booking> GetBookingHistory(string userId);

        public List<History> GetOfferHistory(string userId);
    }
}
