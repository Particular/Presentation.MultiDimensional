﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NServiceBus;
using Store.Messages.RequestResponse;

public class ProvisionDownloadHandler : IHandleMessages<ProvisionDownloadRequest>
{

    public async Task Handle(ProvisionDownloadRequest message, IMessageHandlerContext context)
    {
        if (DebugFlagMutator.Debug)
        {
            Debugger.Break();
        }

        Console.WriteLine("Provision the products and make the Urls available to the Content management for download ...[{0}] product(s) to provision", string.Join(", ", message.ProductIds));

        await context.Reply(new ProvisionDownloadResponse
            {
                OrderNumber = message.OrderNumber,
                ProductIds = message.ProductIds,
                ClientId = message.ClientId
            });
    }
}
