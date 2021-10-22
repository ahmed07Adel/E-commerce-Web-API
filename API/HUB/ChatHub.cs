using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.HUB
{
    public class ChatHub : Hub
    {
        public Task SendMessage(string message, string user)
        {
            return Clients.All.SendAsync("RecieveOne", user, message);
        }
    }
}
