using CarpoolingWebAPI.Interfaces;
using CarpoolingWebAPI.Models;
using CarpoolingWebAPI.ViewModels;
using CarPoolingWebAPI.Models;

namespace CarpoolingWebAPI.Services
{
    public class LoginServices : ILoginServices
    {
        private AppDbContext appDbContext;

        public LoginServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public string AuthenticateUser(LoginRequest loginRequest)
        {
            string status = "No";
            string email = loginRequest.Email;
            string password = "" + loginRequest.Password.GetHashCode();

            User? user = appDbContext.Users.Where(_ => _.Email.Equals(email)).FirstOrDefault();

            if (user != null)
            {
                UserLogin? cred = appDbContext.UserLogin.Where(_ => _.UserID.Equals(user.UserID)).FirstOrDefault();

                string pass = cred.Password;

                if (cred.Password == password)
                    status = "Yes";
            }

            return status;
        }
    }
}
