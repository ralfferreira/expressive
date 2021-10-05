using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class ProdutoBLL
    {
        ProdutoDAL dao = new ProdutoDAL();

        public bool CadProd(Produto p)
        {
            bool salvou = false;
            dao.CadProd(p);

            if (p.Cod > 0)
            {
                salvou = true;
            }
            return salvou;
        }

        public List<Produto> SelecionarTodos()
        {
            return dao.SelecionarTodos();
        }

        public Produto SelecionarPorCod(int cod)
        {
            return dao.SelecionarPorCod(cod);
        }

        public bool Atualizar(Produto p)
        {
            bool atualizou = false;

            if (p.Cod == 0)
            {
                throw new Exception("Selecione um Produto para atualizar.");
            }

            if (dao.Atualizar(p) > 0)
            {
                atualizou = true;
            }
            return atualizou;
        }

        public bool Deletar(int cod)
        {
            bool deletou = false;

            if (dao.Deletar(cod) > 0)
            {
                deletou = true;
            }
            return deletou;
        }
    }
}

