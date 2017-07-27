using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.ServiceBus.Messaging;
using GerenciadorComprasWCF.ServicoProdutos;

namespace GerenciadorComprasWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServicoGerenciadorCompras : IServicoGerenciadorCompras
    {
        public List<Produto> ObterProdutosDisponiveis()
        {
            //Cliente de acesso ao WCF Gerenciador de Produtos
            ServicoProdutos.ServicoGerenciadorProdutosClient client = new ServicoGerenciadorProdutosClient();

            //Resultado - Produtos a serem retornados.
            List<Produto> produtos;

            client.Open(); //Abre Acesso ao WCF
            //Obtem a lista de produtos disponiveis
            produtos = client.ObterProdutos().Where(x => x.Quantidade > 0).ToList();
            client.Close(); //Fecha o Acesso ao WCF

            return produtos;
        }
        public bool EnviarPedido(Pedido pedido)
        {
            
            var connectionString = "Endpoint=sb://amazingstore.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=MRF/41K8dKlXrzHN5LOci43oIowe4xGLYIXU0lrRUTI=";
            var queueName = "amazingqueue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage(pedido);//Mensagem
            client.Send(message);
            
            return true;//Pedido enviado com sucesso
        }
    }
}
