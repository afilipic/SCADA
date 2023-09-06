
using Microsoft.AspNetCore.SignalR;

namespace SCADA_backend.Hubs
{
    public class TagHub : Hub
    {

        public async Task SendTag()
        {
            await Clients.All.SendAsync("ReceiveTag", "tesssst");
        }
    }
}