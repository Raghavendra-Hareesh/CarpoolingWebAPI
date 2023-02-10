using CarpoolingWebAPI.Models;
using CarpoolingWebAPI.ViewModels;
using CarPoolingWebAPI.Models;

namespace CarpoolingWebAPI.Interfaces
{
    public interface IUserServices
    {
        public User AddUser(AddUserRequest addUserRequest);
    }
}
