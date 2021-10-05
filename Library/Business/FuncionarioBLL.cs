using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class FuncionarioBLL
    {
        FuncionarioDAL dao = new FuncionarioDAL();

        public bool CadFun(Funcionario f)
        {
            bool salvou = false;
            dao.CadFun(f);

            if (f.Cod > 0)
            {
                salvou = true;
            }
            return salvou;
        }

        public List<Funcionario> SelecionarTodos()
        {
            return dao.SelecionarTodos();
        }

        public Funcionario SelecionarPorCod(int cod)
        {
            return dao.SelecionarPorCod(cod);
        }

        public bool AtualizarAdmin(Funcionario f)
        {
            bool atualizou = false;

            if (f.Cod == 0)
            {
                throw new Exception("Selecione um Funcionario para atualizar.");
            }

            if (dao.AtualizarAdmin(f) > 0)
            {
                atualizou = true;
            }
            return atualizou;
        }

        public bool Atualizar(Funcionario f)
        {
            bool atualizou = false;

            if (f.Cod == 0)
            {
                throw new Exception("Selecione um Funcionario para atualizar.");
            }

            if (dao.AtualizarUser(f) > 0)
            {
                atualizou = true;
            }
            return atualizou;
        }

        public bool Demitir(int cod)
        {
            bool demitido = false;

            if (dao.Demitir(cod) > 0)
            {
                demitido = true;
            }
            return demitido;
        }

        public List<Funcionario> RelatorioVendas()
        {
            return dao.RelatorioVendas();
        }
    }
}

    
