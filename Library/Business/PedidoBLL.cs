using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class PedidoBLL
    {
        PedidoDAL dao = new PedidoDAL();

        public bool CadProd(Pedido p)
        {
            bool salvou = false;
            dao.CadPedido(p);

            if (p.Num > 0)
            {
                salvou = true;
            }
            return salvou;
        }

        public List<Pedido> SelecionarTodos()
        {
            return dao.SelecionarTodos();
        }

        public Pedido SelecionarPorCod(int num)
        {
            return dao.SelecionarPorCod(num);
        }

        public bool Atualizar(Pedido p)
        {
            bool atualizou = false;

            if (p.Num == 0)
            {
                throw new Exception("Selecione um Produto para atualizar.");
            }

            if (dao.Atualizar(p) > 0)
            {
                atualizou = true;
            }
            return atualizou;
        }

        public bool Deletar(int num)
        {
            bool deletou = false;

            if (dao.Deletar(num) > 0)
            {
                deletou = true;
            }
            return deletou;
        }

        public List<Pedido> SelecionarTodosUser(int cod, string tipo)
        {
            return dao.SelecionarTodosUser(cod, tipo);
        }
    }
}
