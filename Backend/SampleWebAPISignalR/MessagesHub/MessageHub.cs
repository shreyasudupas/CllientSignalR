using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SampleWebAPISignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SampleWebAPISignalR.MessagesHub
{
    [HubName("MessageHub")]
    public class MessageHub:Hub
    {
        private static readonly Dictionary<string, int> _connections = new Dictionary<string, int>();
        private static int i = 0;

        public override Task OnConnected()
        {
            string name = Context.ConnectionId;
            _connections.Add(name, i);
            i++;

            return base.OnConnected();
        }

        [HubMethodName("sendMessage")]
        public void SendMessage(List<Messages> msg)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            foreach(var conn in _connections)
                context.Clients.Client(conn.Key).updateMessage(msg);
        }
        

        //[HubMethodName("sendMessage")]
        //public void SendMessage(List<Messages> msg,string connectionId)
        //{
        //    Clients.Client(connectionId).updateMessage(msg);
        //}

        [HubMethodName("recieveMessage")]
        public void RecieveMessage(string connectionId)
        {
            var d = "This is from server";
            Clients.Client(connectionId).reciveMessage(d);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string connId = Context.ConnectionId;

            _connections.Remove(Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

    }
}