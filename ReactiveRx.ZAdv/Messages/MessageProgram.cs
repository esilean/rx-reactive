using ReactiveRx.ZAdv.Messages.Events;
using ReactiveRx.ZAdv.Messages.Interfaces;
using ReactiveRx.ZAdv.Messages.Services;
using System;

namespace ReactiveRx.ZAdv.Messages
{
    public class MessageProgram
    {
        public MessageProgram()
        {
            IMessageEventHandler<MessageReceivedEvent> eventHandler = new MessageEventHandler<MessageReceivedEvent>();

            eventHandler.Subscribe("sub1", async (x) =>
            {
                await Console.Out.WriteLineAsync($"Sub1 = {x.Message}");
            });

            eventHandler.Subscribe("sub2", (x) => x.Message == "aaa", async (x) =>
            {
                await Console.Out.WriteLineAsync($"Sub2 = {x.Message}");
            });

            eventHandler.Publish(new MessageReceivedEvent { Message = "messaging...." });
            eventHandler.Publish(new MessageReceivedEvent { Message = "aaa" });

            Console.ReadKey();
        }
    }
}
