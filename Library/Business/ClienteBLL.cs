using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class ClienteBLL
    {
        ClienteDAL dao = new ClienteDAL();

        public bool CadClie(Cliente c)
        {
            bool salvou = false;
            dao.CadClie(c);
            
            if (c.Cod > 0)
            {
                salvou = true;
            }
            return salvou;
        }

        public List<Cliente> SelecionarTodos()
        {            
            return dao.SelecionarTodos();
        }

        public Cliente SelecionarPorCod(int cod)
        {
            return dao.SelecionarPorCod(cod);
        }

        public bool Atualizar(Cliente c)
        {
            bool atualizou = false;            

            if (c.Cod == 0)
            {
                throw new Exception("Selecione uma Cliente para atualizar.");
            }

            if (dao.Atualizar(c) > 0)
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
