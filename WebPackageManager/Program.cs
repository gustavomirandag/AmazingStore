using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using System.Threading;

namespace WebPackageManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Endpoint=sb://amazingstore.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=MRF/41K8dKlXrzHN5LOci43oIowe4xGLYIXU0lrRUTI=";
            var client = QueueClient.CreateFromConnectionString(connectionString, "amazingqueue");
            ManualResetEvent CompletedEvent = new ManualResetEvent(false);

            client.OnMessage(message =>
                {
                    //Obtem o pedido que está no ServiceBus
                    ServicoCompras.Pedido pedido;
                    pedido = message.GetBody<ServicoCompras.Pedido>();

                    Console.WriteLine(String.Format("Destinatario: {0}", pedido.Destinatario)); 
                    Console.WriteLine(String.Format("Endereço: {0}", pedido.Endereco)); 
                    foreach(ServicoCompras.Produto prod in pedido.Produtos)
                    {
                        Console.WriteLine(String.Format(" => {0} - {1}", prod.Nome, prod.Quantidade));
                    }

                    //Imprime o identificador da mensagem
                    Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
                    Console.WriteLine();
                });

            CompletedEvent.WaitOne();
        }
    }
}
