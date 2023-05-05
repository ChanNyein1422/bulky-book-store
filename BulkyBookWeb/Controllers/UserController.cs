﻿using Data.Models;
using BulkyBookWeb.AuthServices;
using Infra.Helper.UserApiRequest;
using Microsoft.AspNetCore.Mvc;
using Infra.Helper;

namespace BulkyBookWeb.Controllers
{
    public class UserController : Controller
    {
        IUserApiRequest _iuser;
        IAuth _auth;
        public UserController(IUserApiRequest iuser, IAuth iauth)
        {
            this._iuser = iuser;
            this._auth = iauth;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _RegisterView()
        {
            return View();
        }
        public async Task<IActionResult> _EditView(int id)
        {
            var userdata = await _iuser.GetUserByID(id);
            return View(userdata);
        }
        [HttpPost]
        public async Task<IActionResult> UpSert(tbUser user)
        {
            user.CreatedDate = DateTime.Now;
            var userdata = await _iuser.UpSert(user);
            return Ok(userdata);
        }

        [HttpPost]
        public async Task<IActionResult> Login(tbUser user)
        {
            var status = "Login Fail";
            var result = await _iuser.Login(user.Email, user.Password);
            if(result.Id > 0)
            {
                status = "Success";
                _auth.AuthorizeUser(result, HttpContext);
            }
            return Json(status);
        }

        public IActionResult Logout()
        {
            _auth.Logout(HttpContext);
            return RedirectToAction("Index", "User");
        }
    }
}
