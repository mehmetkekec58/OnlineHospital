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
    public class MessagesController : ControllerBase
    {
        IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("send")]

        public IActionResult SendMessage(Message message)
        {
            var result = _messageService.send(message);
            if (result.Success)
            {
                return  Ok(result);
            }
            else
            {
                return  BadRequest(result);
            }
        }

        [HttpGet("list")]

        public IActionResult ListMessage(string alan, string gonderen)
        {
            var result = _messageService.GetAllMessages(alan,gonderen);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("listmessage")]

        public IActionResult GetListMessage(string userName)
        {
            var result = _messageService.GetListUser(userName);
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
