using BulkyBookAPI.Services.User;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser _iUser;

        public UserController(IUser iUser)
        {
            _iUser = iUser;
        }

        [HttpGet("api/user/getallusers")]
        public IActionResult GetAllUsers()
        {
            var user = this._iUser.GetAllUsers();
            return Ok(user);
        }

        [HttpGet("api/user/getuserbyid")]
        public IActionResult GetUserById(int id)
        {
            var user = this._iUser.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("api/user/delete")]
        public IActionResult DeleteUser(int id)
        {
            var user = this._iUser.UserDelete(id);
            return Ok(user);
        }

        [HttpPost("api/user/upsert")]
        public async Task<IActionResult> UpSert(tbUser user)
        {
            user = await this._iUser.UpSert(user);
            return Ok(user);
        }

        [HttpPost("api/user/login")]
        public async Task<tbUser> LoginUser(tbUser obj)
        {
            string email = obj.Email;
            string password = obj.Password;
            var user = await this._iUser.LoginUser(email, password);
            user.CreatedDate = null;
            return user;
        }
    }
}
