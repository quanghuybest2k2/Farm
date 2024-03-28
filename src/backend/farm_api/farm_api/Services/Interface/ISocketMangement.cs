using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;

namespace farm_api.Services.Interface
{
    public interface ISocketMangement
    {
        string AddSocket(WebSocket socket);
        Task RemoveSocket(string connectionId);
        WebSocket GetSocketById(string id);
        ICollection<WebSocket> GetAll();
        Task SendMessageAsync(string connectionId, string message);
        Task SendMessageToAllAsync(string message);
    }
}
