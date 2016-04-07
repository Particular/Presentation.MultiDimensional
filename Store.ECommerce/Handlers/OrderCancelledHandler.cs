﻿using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using NServiceBus;
using Store.Messages.Events;

public class OrderCancelledHandler : IHandleMessages<OrderCancelled>
{
    public Task Handle(OrderCancelled message, IMessageHandlerContext context)
    {
        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<OrdersHub>();

        hubContext.Clients.Client(message.ClientId).orderCancelled(new
            {
                message.OrderNumber,
            });
        return Task.FromResult(0);
    }

}
