using Business.Abstract;
using Entities.Concrete;
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
    public class UserProfilePhotoController : ControllerBase
    {
        IUserProfilePhoto _userProfilePhoto;

        public UserProfilePhotoController(IUserProfilePhoto userProfilePhoto)
        {
            _userProfilePhoto = userProfilePhoto;
        }


        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _userProfilePhoto.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(string userName)
        {
            var result = _userProfilePhoto.GetImagesByCarId(userName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]

        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] UserProfilePhoto carImage)
        {
            var result = _userProfilePhoto.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete([FromForm(Name = ("Id"))] int carImageId)
        {

            var deleteCarImageByCarId = _userProfilePhoto.Get(carImageId).Data;
            var result = _userProfilePhoto.Delete(deleteCarImageByCarId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateimage")]

        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] UserProfilePhoto carImage)
        {
            var result = _userProfilePhoto.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
