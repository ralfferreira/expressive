using Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class PedidoDAL
    {
        ClienteDAL daoCliente = new ClienteDAL();
        FuncionarioDAL daoFuncionario = new FuncionarioDAL();
        Item_PedidoDAL daoItem = new Item_PedidoDAL();

        public int CadPedido(Pedido p)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("INSERT INTO Pedido ");
                sql.AppendLine("(pr_entrega, dt_pedido, valor, cod_cliente, cod_fun) ");
                sql.AppendLine("VALUES (@prazo, @data, @valor, @cliente, @funcionario) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY() as num;");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@prazo", p.Pr_entrega);
                    cmd.Parameters.AddWithValue("@data", p.Dt_pedido);
                    cmd.Parameters.AddWithValue("@valor", p.Valor);
                    cmd.Parameters.AddWithValue("@cliente", p.Cliente.Cod);
                    cmd.Parameters.AddWithValue("@funcionario", p.Funcionario.Cod);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                p.Num = Convert.ToInt32(dr["num"]);
                            }
                        }
                    }
                    con.Close();
                }

                Item_PedidoDAL daoItem = new Item_PedidoDAL();

                foreach (Item_Pedido item in p.Produtos)
                {
                    item.NumPedido = p.Num;
                    item.CodProduto = item.Produto.Cod;
                    daoItem.CadItem(item);
                }

                return reg;
            }
        }

        public List<Pedido> SelecionarTodos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT num_pedido, pr_entrega, dt_pedido, valor, cod_clie, cod_fun ");
                sql.AppendLine("FROM Pedido ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Pedido p = new Pedido();
                                p.Num = Convert.ToInt32(dr["num_pedido"]);
                                p.Pr_entrega = Convert.ToInt32(dr["pr_entrega"]);
                                p.Dt_pedido = Convert.ToDateTime(dr["dt_pedido"]);
                                p.Valor = Convert.ToDecimal(dr["valor"]);
                                p.Cliente = daoCliente.SelecionarPorCod(Convert.ToInt32(dr["cod_clie"]));
                                p.Funcionario = daoFuncionario.SelecionarPorCod(Convert.ToInt32(dr["cod_fun"]));
                                p.Produtos = daoItem.SelecionarTodos(p.Num);

                                listaPedidos.Add(p);//Adicionando o objeto para a lista
                            }
                        }
                        return listaPedidos;
                    }
                }
            }
        }

        public Pedido SelecionarPorCod(int num)
        {
            Pedido p = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT num_pedido, pr_entrega, dt_pedido, valor, cod_clie, cod_fun ");
                sql.AppendLine("FROM Pedido WHERE num_pedido = @num_pedido");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@num_pedido", num); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                p = new Pedido();
                                p.Num = Convert.ToInt32(dr["num_pedido"]);
                                p.Pr_entrega = Convert.ToInt32(dr["pr_entrega"]);
                                p.Dt_pedido = Convert.ToDateTime(dr["dt_pedido"]);
                                p.Valor = Convert.ToDecimal(dr["valor"]);
                                p.Cliente = daoCliente.SelecionarPorCod(Convert.ToInt32(dr["cod_clie"]));
                                p.Funcionario = daoFuncionario.SelecionarPorCod(Convert.ToInt32(dr["cod_fun"]));
                            }
                        }
                        return p;
                    }
                }
            }
        }

        public int Atualizar(Pedido p)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("UPDATE Pedido SET ");
                sql.AppendLine("pr_entrega = @entrega, ");
                sql.AppendLine("valor = @valor, ");
                sql.AppendLine("cod_clie = @cliente, ");
                sql.AppendLine("cod_fun = @vendedor ");
                sql.AppendLine("WHERE num_pedido = @pedido");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@entrega", p.Pr_entrega);
                    cmd.Parameters.AddWithValue("@valor", p.Valor);
                    cmd.Parameters.AddWithValue("@cliente", p.Cliente.Cod);
                    cmd.Parameters.AddWithValue("@vendedor", p.Funcionario.Cod);
                    cmd.Parameters.AddWithValue("@pedido", p.Num);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public int Deletar(int num)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE FROM Pedido ");
                sql.AppendLine("WHERE num_pedido = @pedido ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@pedido", num);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public List<Pedido> SelecionarTodosUser(int cod, string tipo)
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT num_pedido, pr_entrega, dt_pedido, valor, cod_clie, cod_fun ");
                sql.AppendLine("FROM Pedido ");

                if(tipo == "F")
                {
                    sql.AppendLine("WHERE cod_fun = @cod");
                }
                else
                {
                    sql.AppendLine("WHERE cod_clie = @cod ");
                }

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@cod", cod);
                    

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Pedido p = new Pedido();
                                p.Num = Convert.ToInt32(dr["num_pedido"]);
                                p.Pr_entrega = Convert.ToInt32(dr["pr_entrega"]);
                                p.Dt_pedido = Convert.ToDateTime(dr["dt_pedido"]);
                                p.Valor = Convert.ToDecimal(dr["valor"]);
                                p.Cliente = daoCliente.SelecionarPorCod(Convert.ToInt32(dr["cod_clie"]));
                                p.Funcionario = daoFuncionario.SelecionarPorCod(Convert.ToInt32(dr["cod_fun"]));
                                p.Produtos = daoItem.SelecionarTodos(p.Num);

                                listaPedidos.Add(p);//Adicionando o objeto para a lista
                            }
                        }
                        return listaPedidos;
                    }
                }
            }
        }
    }
}
