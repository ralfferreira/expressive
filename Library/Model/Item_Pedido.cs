using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Item_Pedido
    {
        private Produto produto;
        private int qtd;
        private int numPedido;
        private int codProduto;

        public Produto Produto { get => produto; set => produto = value; }
        public int Qtd { get => qtd; set => qtd = value; }
        public int NumPedido { get => numPedido; set => numPedido = value; }
        public int CodProduto { get => codProduto; set => codProduto = value; }
    }
}
