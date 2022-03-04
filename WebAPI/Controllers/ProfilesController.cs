using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        IUserService _userservice;

        public ProfilesController(IUserService userservice)
        {
            _userservice = userservice;
        }

        [HttpGet("getprofiledetailbyusername")]

        public IActionResult GetUserProfileDetailbyUserName(string userName)
        {
            var result = _userservice.GetUserByUserName(userName);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
