using System;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using System.Diagnostics;
using Take.Blip.Client;

namespace Blip_sdk
{
    /// <summary>
    /// Defines a class for handling messages. 
    /// This type must be registered in the application.json file in the 'messageReceivers' section.
    /// </summary>
    public class PlainTextMessageReceiver : IMessageReceiver
    {
        private readonly ISender _sender;
        private readonly Settings _settings;

        public PlainTextMessageReceiver(ISender sender, Settings settings)
        {
            _sender = sender;
            _settings = settings;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            Trace.TraceInformation($"From: {message.From} \tContent: {message.Content}");

            // Pega a mensagem enviada para o bot
            Console.WriteLine(message.Content.ToString());

            await _sender.SendMessageAsync("Bem vindo! Ao comprador de ingressos online.", message.From, cancellationToken);

            // Tempo para mostrar a proxima mensagem
            Thread.Sleep(1000);
            await _sender.SendMessageAsync("Como posso ajudar?", message.From, cancellationToken);
        }
    }
}
