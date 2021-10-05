using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class Item_PedidoBLL
    {
        Item_PedidoDAL dao = new Item_PedidoDAL();

        public bool CadProd(Item_Pedido i)
        {
            bool salvou = false;
            int reg = dao.CadItem(i);

            if (reg > 0)
            {
                salvou = true;
            }
            return salvou;
        }

        public List<Item_Pedido> SelecionarTodos(int num)
        {
            return dao.SelecionarTodos(num);
        }

        public Item_Pedido SelecionarPorCod(int num, int cod)
        {
            return dao.SelecionarPorCod(num, cod);
        }

        public bool Atualizar(Item_Pedido i)
        {
            bool atualizou = false;

            if (i.CodProduto == 0)
            {
                throw new Exception("Selecione um Produto para atualizar.");
            }

            if (dao.Atualizar(i) > 0)
            {
                atualizou = true;
            }
            return atualizou;
        }

        public bool Deletar(int num,int cod)
        {
            bool deletou = false;

            if (dao.Deletar(num, cod) > 0)
            {
                deletou = true;
            }
            return deletou;
        }
    }
}
