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
    public class Item_PedidoDAL
    {
        ProdutoDAL dao = new ProdutoDAL();

        public int CadItem(Item_Pedido i)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("INSERT INTO Item_Pedido ");
                sql.AppendLine("(num_pedido, cod_prod, quant) ");
                sql.AppendLine("VALUES (@pedido, @produto, @qtd) ");
                sql.AppendLine("SELECT COUNT(*) as reg FROM Item_Pedido ");
                sql.AppendLine("WHERE num_pedido = @pedido AND cod_prod = @produto");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@pedido", i.NumPedido);
                    cmd.Parameters.AddWithValue("@produto", i.CodProduto);
                    cmd.Parameters.AddWithValue("@qtd", i.Qtd);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                reg = Convert.ToInt32(dr["reg"]);
                            }
                        }
                    }
                    con.Close();
                }
                return reg;
            }
        }

        public List<Item_Pedido> SelecionarTodos(int num)
        {
            List<Item_Pedido> listaItens = new List<Item_Pedido>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT num_pedido, cod_prod, quant ");
                sql.AppendLine("FROM Item_Pedido WHERE num_pedido");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Item_Pedido i = new Item_Pedido();
                                i.NumPedido = Convert.ToInt32(dr["num_pedido"]);
                                i.CodProduto = Convert.ToInt32(dr["cod_prod"]);
                                i.Qtd = Convert.ToInt32(dr["quant"]);
                                i.Produto = dao.SelecionarPorCod(i.CodProduto);

                                listaItens.Add(i);
                            }
                        }
                        return listaItens;
                    }
                }
            }
        }

        public Item_Pedido SelecionarPorCod(int num,int cod)
        {
            Item_Pedido i = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT num_pedido, cod_prod, quant ");
                sql.AppendLine("FROM Item_Pedido WHERE num_pedido = @pedido AND cod_prod = @produto");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@pedido", num);
                    cmd.Parameters.AddWithValue("@produto", cod);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                i = new Item_Pedido();

                                i.NumPedido = Convert.ToInt32(dr["num_pedido"]);
                                i.CodProduto = Convert.ToInt32(dr["cod_prod"]);
                                i.Qtd = Convert.ToInt32(dr["quant"]);
                                i.Produto = dao.SelecionarPorCod(i.CodProduto);
                            }
                        }
                        return i;
                    }
                }
            }
        }

        public int Atualizar(Item_Pedido i)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("UPDATE Item_Pedido SET ");
                sql.AppendLine("quant = @qtd ");
                sql.AppendLine("WHERE num_pedido = @pedido AND cod_prod = @produto");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@pedido", i.NumPedido);
                    cmd.Parameters.AddWithValue("@produto", i.CodProduto);
                    cmd.Parameters.AddWithValue("@qtd", i.Qtd);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public int Deletar(int num, int cod)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE FROM Item_Pedido ");
                sql.AppendLine("WHERE num_pedido = @pedido AND cod_prod = @produto ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@pedido", num);
                    cmd.Parameters.AddWithValue("@produto", cod);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }
    }
}
