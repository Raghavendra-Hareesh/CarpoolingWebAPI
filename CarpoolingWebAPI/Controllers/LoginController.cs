using CarpoolingWebAPI.Interfaces;
using CarpoolingWebAPI.Models;
using CarpoolingWebAPI.ViewModels;
using CarPoolingWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolingWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginServices authServices;

        public LoginController(ILoginServices authServices)
        {
            this.authServices = authServices;
        }

        [HttpPost]
        public ActionResult<User> Authenticate(LoginRequest loginUserRequest)
        {
            string status = authServices.AuthenticateUser(loginUserRequest);

            if(status.Equals("Yes"))
                return Ok(status);

            return BadRequest(status);
        }
    }

}