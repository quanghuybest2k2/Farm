namespace farm_api.Hub;
using Microsoft.AspNetCore.SignalR;
public class FarmHub:Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
