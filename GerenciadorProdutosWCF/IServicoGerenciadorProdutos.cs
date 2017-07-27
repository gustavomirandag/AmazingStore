using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GerenciadorProdutosWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicoGerenciadorProdutos
    {

        [OperationContract]
        void AdicionarProduto(Produto value);
        [OperationContract]
        void EditarProduto(Produto value);
        [OperationContract]
        void RemoverProduto(Produto value);
        [OperationContract]
        List<Produto> ObterProdutos();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Produto:IComparable
    {
        Guid id;
        string nome;
        string foto;
        string descricao;
        string categoria;
        float preco;
        int quantidade;

        [DataMember]
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        [DataMember]
        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }

        [DataMember]
        public string Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        [DataMember]
        public float Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
            }
        }

        [DataMember]
        public string Foto
        {
            get
            {
                return foto;
            }

            set
            {
                foto = value;
            }
        }

        [DataMember]
        public int Quantidade
        {
            get
            {
                return quantidade;
            }

            set
            {
                quantidade = value;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this.Id == ((Produto)obj).Id)
                return true; //É igual ao outro objeto
            return false;
        }

        public int CompareTo(object obj)
        {
            Produto other = (Produto)obj;
            if (this.preco == other.preco)
                return 0; //The price is the same
            else if (this.preco < other.preco)
                return -1;
            else
                return 1;
        }
    }
}
