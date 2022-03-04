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
    public class DiseasesController : ControllerBase
    {
       private IDiseaseService _diseaseService;

        public DiseasesController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }
        [HttpPost("add")]

        public IActionResult Add(Disease disease)
        {
            var result = _diseaseService.Add(disease);
            if (result.Success)
            {
               return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPost("update")]

        public IActionResult Update(Disease disease)
        {
            var result = _diseaseService.Update(disease);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("delete")]

        public IActionResult Delete(Disease disease)
        {
            var result = _diseaseService.Delete(disease);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _diseaseService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _diseaseService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyuserid")]

        public IActionResult GetByUserId(int userId)
        {
            var result = _diseaseService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("getdiseasedetailbyid")]

        public IActionResult GetDiseaseDetailById(int id)
        {
            var result = _diseaseService.GetDiseaseDetail(id);
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
