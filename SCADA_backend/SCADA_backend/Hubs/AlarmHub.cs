using Microsoft.AspNetCore.SignalR;
using SCADA_backend.Model;

namespace SCADA_backend.Hubs
{
public class AlarmHub : Hub
{
    public async Task SendAlarm()
    {
        await Clients.All.SendAsync("ReceiveAlarm", "new alarm");
    }
}
}