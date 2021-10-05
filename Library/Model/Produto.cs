using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Produto
    {
        private int cod;
        private string nome;
        private string descricao;
        private decimal val_unit;
        private string categoria;
        private int estoque;
        private string foto;
        private bool desativado;

        public int Cod { get => cod; set => cod = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public decimal Val_unit { get => val_unit; set => val_unit = value; }
        public int Estoque { get => estoque; set => estoque = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Foto { get => foto; set => foto = value; }
        public bool Desativado { get => desativado; set => desativado = value; }
    }
}
