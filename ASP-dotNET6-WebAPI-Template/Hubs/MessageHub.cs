using Microsoft.AspNetCore.SignalR;

namespace ASP_dotNET6_WebAPI_Template.Hubs;

public class MessageHub : Hub
{
    public async Task SendMessage(string messageText)
    {
        await Clients.All.SendAsync(messageText);
    }

}
