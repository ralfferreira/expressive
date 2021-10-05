using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Funcionario : Usuario
    {
        private string cargo;
        private decimal salario_fixo;
        private string comissao;
        private DateTime dt_contrato;
        private DateTime dt_demissao;        
        private int vendas;
        private decimal valorTotal;

        public string Cargo { get => cargo; set => cargo = value; }
        public decimal Salario_fixo { get => salario_fixo; set => salario_fixo = value; }
        public string Comissao { get => comissao; set => comissao = value; }
        public DateTime Dt_contrato { get => dt_contrato; set => dt_contrato = value; }
        public DateTime Dt_demissao { get => dt_demissao; set => dt_demissao = value; }
        public int Vendas { get => vendas; set => vendas = value; }
        public decimal ValorTotal { get => valorTotal; set => valorTotal = value; }
    }
}
