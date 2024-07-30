using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebAPPSignalR
{
    [Authorize]
    public class SampleHub : Hub
    {
        [Authorize("SamplePolicyName")]
        public async Task SendMessageToAll(string message)
        {
            string userName = Context.User.Identity.Name;
            await Clients.All.SendAsync("ReceiveMessage", $"User {userName} says " + message);
        }
        [Authorize("SamplePolicyName")]
        public async Task SendMessageToCaller(string message)
        {
            string userName = Context.User.Identity.Name;
            await Clients.Caller.SendAsync("ReceiveMessage", $"User {userName} says " + message);
        }
        public async Task SendMessageToUser(string connectionId, string message)
        {
            string userName = Context.User.Identity.Name;
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", $"User {userName} says " + message);
        }
        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }
        public async Task SendMessageToGroup(string group, string message)
        {
            string userName = Context.User.Identity.Name;
            await Clients.Group(group).SendAsync("ReceiveMessage", $"User {userName} says "+ message);
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);

            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(ex);
        }
    }
}
