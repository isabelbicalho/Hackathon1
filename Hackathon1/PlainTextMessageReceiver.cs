using System;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using Takenet.MessagingHub.Client;
using Takenet.MessagingHub.Client.Listener;
using Takenet.MessagingHub.Client.Sender;
using System.Diagnostics;
using Lime.Messaging.Contents;

namespace Hackathon1
{
    public class PlainTextMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public PlainTextMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            var document = new PlainText { Text = "... Inspiração, e um pouco de café! E isso me basta!" };
            Trace.TraceInformation($"From: {message.From} \tContent: {message.Content}");
            await _sender.SendMessageAsync(document, message.From, cancellationToken);
        }
    }
}
