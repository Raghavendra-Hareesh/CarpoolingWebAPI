using CarpoolingWebAPI.ViewModels;

namespace CarpoolingWebAPI.Interfaces
{
    public interface ILoginServices
    {
        public string AuthenticateUser(LoginRequest loginUserRequest);
    }
}
