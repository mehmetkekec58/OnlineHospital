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
    public class FallowsController : ControllerBase
    {

        private IFallowService _fallowService;

        public FallowsController(IFallowService fallowService)
        {
            _fallowService = fallowService;
        }

        [HttpPost("fallow")]

        public IActionResult Fallow(Fallow fallow)
        {
            var result = _fallowService.Fallow(fallow);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPost("unfallow")]

        public IActionResult UnFallow(Fallow fallow)
        {
            var result = _fallowService.UnFallowed(fallow);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("fallowcount")]

        public IActionResult FallowCount(string username)
        {
            var result = _fallowService.FallowedCount(username);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("isfallowing")]

        public IActionResult IsFallowing(Fallow fallow)
        {
            var result = _fallowService.isFallowing(fallow);
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
