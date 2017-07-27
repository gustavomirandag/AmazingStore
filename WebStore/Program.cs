using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.ServiceBus.Messaging;

namespace WebStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cliente do WCF de Gerenciamento de Compras
            ServicoCompras.ServicoGerenciadorComprasClient client = new ServicoCompras.ServicoGerenciadorComprasClient();

            //Obtem produtos disponíveis
            List<ServicoCompras.Produto> produtosDisponiveis;
            client.Open();
            produtosDisponiveis = client.ObterProdutosDisponiveis();

            //Adiciona todos os produtos disponíveis no carrinho
            List<ServicoCompras.Produto> carrinho;
            carrinho = produtosDisponiveis;

            //Prepara o pedido
            ServicoCompras.Pedido pedido = new ServicoCompras.Pedido();
            pedido.Destinatario = "Turma de EDS";
            pedido.Endereco = "Rua São José 90";
            pedido.Produtos = carrinho;

            //Realiza o Pedido
            client.EnviarPedido(pedido);
            client.Close();
        }
    }
}
