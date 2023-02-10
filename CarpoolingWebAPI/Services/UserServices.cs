using CarpoolingWebAPI.Interfaces;
using CarpoolingWebAPI.Models;
using CarpoolingWebAPI.ViewModels;
using CarPoolingWebAPI.Models;

namespace CarpoolingWebAPI.Services
{
    public class UserServices : IUserServices
    {
        AppDbContext appDbContext;

        public UserServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public User AddUser(AddUserRequest addUserRequest)
        {
            User user = new User()
            {
                UserID = Guid.NewGuid().ToString(),
                First_Name = addUserRequest.First_Name,
                Last_Name = addUserRequest.Last_Name,
                Email = addUserRequest.Email,
                Phone = addUserRequest.Phone,
                Age = addUserRequest.Age,
                Gender = addUserRequest.Gender,
                OffersMade = addUserRequest.OffersMade,
                BookingsMade = addUserRequest.BookingsMade,
            };

            appDbContext.Users.Add(user);

            appDbContext.UserLogin.Add(new UserLogin()
            {
                UserID = user.UserID,
                Password = addUserRequest.Password,
            });

            appDbContext.SaveChanges();

            return user;
        }

    }
}
