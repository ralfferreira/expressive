using Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Pedido
    {
        private int num;
        private int pr_entrega;
        private DateTime dt_pedido;
        private decimal valor;
        private Cliente cliente;
        private Funcionario funcionario;
        private List<Item_Pedido> produtos;

        public int Num { get => num; set => num = value; }
        public int Pr_entrega { get => pr_entrega; set => pr_entrega = value; }
        public DateTime Dt_pedido { get => dt_pedido; set => dt_pedido = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Funcionario Funcionario { get => funcionario; set => funcionario = value; }
        public List<Item_Pedido> Produtos { get => produtos; set => produtos = value; }

        public Pedido()
        {
            this.Produtos = new List<Item_Pedido>();
        }

        public void CalcularValorTotal()
        {
            decimal valorTotal = 0.00m;

            foreach (Item_Pedido item in this.Produtos)
            {
                decimal qtd = Convert.ToDecimal(item.Qtd);
                decimal preco = item.Produto.Val_unit;
                valorTotal = valorTotal + (qtd * preco);
            }
            this.Valor = valorTotal;
        }
    }
}
