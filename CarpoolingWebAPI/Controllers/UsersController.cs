using CarpoolingWebAPI.Interfaces;
using CarpoolingWebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarpoolingWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private AppDbContext appDbContext;
        private IUserServices userServices;

        public UsersController(AppDbContext appDbContext, IUserServices userServices)
        {
            this.appDbContext = appDbContext;
            this.userServices = userServices;

        }

        [HttpPost]
        public ActionResult AddUserToDB(AddUserRequest addUserRequest)
        {
            addUserRequest.Password = "" + addUserRequest.Password.GetHashCode();

            var user = userServices.AddUser(addUserRequest);

            return Ok(user);
        }

        [HttpGet("All")]
        public async Task<ActionResult> ShowUsers()
        {
            return Ok(await appDbContext.Users.ToListAsync());
        }
    }
}
