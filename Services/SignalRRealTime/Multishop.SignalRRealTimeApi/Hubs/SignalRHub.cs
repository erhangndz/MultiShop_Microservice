using Microsoft.AspNetCore.SignalR;
using Multishop.SignalRRealTimeApi.Services;

namespace Multishop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub(ISignalRService _signalRService): Hub
    {


    }
}
