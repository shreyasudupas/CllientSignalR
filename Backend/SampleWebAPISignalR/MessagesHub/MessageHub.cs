using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SampleWebAPISignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebAPISignalR.MessagesHub
{
    [HubName("MessageHub")]
    public class MessageHub:Hub
    {
        [HubMethodName("sendMessage")]
        public static void SendMessage(List<Messages> msg)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            context.Clients.All.updateMessage(msg);
        }
    }
}