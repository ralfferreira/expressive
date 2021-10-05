using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Usuario
    {
        private int cod;
        private string nome;
        private string endereco;
        private string cidade;
        private string cep;
        private string uf;
        private string cpf;
        private string email;
        private string senha;

        public int Cod { get => cod; set => cod = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Uf { get => uf; set => uf = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}
