using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class UsuarioBLL
    {
        UsuarioDAL dao = new UsuarioDAL();

        public int Login(Usuario u)
        {            
            int Resultado = dao.Login(u);            
            return Resultado;
        }

        public bool Registrar(Usuario u)
        {
            bool Cadastrado = false;
            int Resultado = dao.Registrar(u);
            if(Resultado > 0)
            {
                Cadastrado = true;
            }
            return Cadastrado;
        }
    }
}
