using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GerenciadorProdutosWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServicoGerenciadorProdutos : IServicoGerenciadorProdutos
    {
        //Representa a Lista de Produtos no Banco de Dados
        static List<Produto> produtos = new List<Produto>();

        public ServicoGerenciadorProdutos()
        {
            Produto prod = new Produto();
            prod.Nome = "Bicicleta";
            prod.Preco = 100;
            prod.Quantidade = 1;
            produtos.Add(prod);

            prod = new Produto();
            prod.Nome = "Carro";
            prod.Preco = 35000;
            prod.Quantidade = 0;
            produtos.Add(prod);

            prod = new Produto();
            prod.Nome = "Celular";
            prod.Preco = 300;
            prod.Quantidade = 3;
            produtos.Add(prod);

            prod = new Produto();
            prod.Nome = "Camiseta do Infnet";
            prod.Preco = 70;
            prod.Quantidade = 10;
            produtos.Add(prod);
        }

        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
        }

        public void EditarProduto(Produto produto)
        {
            Produto prod = produtos.Find(x => x.Id == produto.Id);
            if (prod == null)
                return; //Não encontrou o produto e retorna
            prod.Nome = produto.Nome;
            prod.Foto = produto.Foto;
            prod.Descricao = produto.Descricao;
            prod.Categoria = produto.Categoria;
            prod.Preco = produto.Preco;
            prod.Quantidade = prod.Quantidade;
        }

        public List<Produto> ObterProdutos()
        {
            return produtos;
        }

        public void RemoverProduto(Produto produto)
        {
            //produtos.Remove(produto);
            //var produtoExcluir = produtos.Find(p => p.Id == produto.Id);
            //produtos.Remove(produtoExcluir);

            for (int i = 0; i < produtos.Count; i++)
            {
                if(produtos[i].Id == produto.Id)
                {
                    produtos.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
