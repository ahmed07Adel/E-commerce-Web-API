using API.HUB;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> hubContext;

        public ChatController(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        [HttpPost("SendMsg")]
        public IActionResult SendMessage([FromBody] MessageDTO msg)
        {
            hubContext.Clients.All.SendAsync("ReceiveOne", msg.User, msg.Message);
            return Ok();
        }
    }
}
