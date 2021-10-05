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
    public class ProdutoDAL
    {
        public int CadProd(Produto p)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("INSERT INTO Produto ");
                sql.AppendLine("(nome, descricao, val_unit, estoque, img, nome_cat) ");
                sql.AppendLine("VALUES (@nome, @descricao, @valor, @estoque, @img, @categoria); ");
                sql.AppendLine("SELECT SCOPE_IDENTITY() as cod");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome", p.Nome);
                    cmd.Parameters.AddWithValue("@descricao", p.Descricao);
                    cmd.Parameters.AddWithValue("@valor", p.Val_unit);        
                    cmd.Parameters.AddWithValue("@img", p.Foto);        
                    cmd.Parameters.AddWithValue("@estoque", p.Estoque);        
                    cmd.Parameters.AddWithValue("@categoria", p.Categoria);        

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr != null)
                        {
                            while (dr.Read())
                            {
                                p.Cod = Convert.ToInt32(dr["cod"]);
                            }                            
                        }                        
                    }
                    con.Close();
                }
                return reg;
            }
        }

        public List<Produto> SelecionarTodos()
        {
            List<Produto> listaProdutos = new List<Produto>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT cod_prod, nome, descricao, val_unit, img, estoque, nome_cat ");
                sql.AppendLine("FROM Produto ");
                sql.AppendLine("WHERE estoque != 0 AND desativado != 1");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Produto p = new Produto();
                                p.Cod = Convert.ToInt32(dr["cod_prod"]);
                                p.Nome = dr["nome"].ToString();
                                p.Descricao = dr["descricao"].ToString();                                
                                p.Val_unit = Convert.ToDecimal(dr["val_unit"]);
                                p.Foto = dr["img"].ToString();
                                p.Estoque = Convert.ToInt32(dr["estoque"]);
                                p.Categoria = dr["nome_cat"].ToString();

                                listaProdutos.Add(p);//Adicionando o objeto para a lista
                            }
                        }
                        return listaProdutos;
                    }
                }
            }
        }

        public Produto SelecionarPorCod(int cod)
        {
            Produto p = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT cod_prod, nome, descricao, val_unit, img, estoque, nome_cat ");
                sql.AppendLine("FROM Produto ");
                sql.AppendLine("WHERE cod_prod = @cod_prod ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@cod_prod", cod); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                p = new Produto();
                                p.Cod = Convert.ToInt32(dr["cod_prod"]);
                                p.Nome = dr["nome"].ToString();
                                p.Descricao = dr["descricao"].ToString();
                                p.Val_unit = Convert.ToDecimal(dr["val_unit"]);
                                p.Foto = dr["img"].ToString();
                                p.Estoque = Convert.ToInt32(dr["estoque"]);
                                p.Categoria = dr["nome_cat"].ToString();
                            }
                        }
                        return p;
                    }
                }
            }
        }

        public int Atualizar(Produto p)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("UPDATE Produto SET ");
                sql.AppendLine("nome = @nome, ");
                sql.AppendLine("descricao = @descricao, ");
                sql.AppendLine("val_unit = @valor, ");
                sql.AppendLine("img = @img, ");
                sql.AppendLine("estoque = @estoque, ");
                sql.AppendLine("desativado = @desativo, ");
                sql.AppendLine("nome_cat = @categoria ");
                sql.AppendLine("WHERE cod_prod = @cod_prod");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome", p.Nome);
                    cmd.Parameters.AddWithValue("@descricao", p.Descricao);
                    cmd.Parameters.AddWithValue("@valor", p.Val_unit);
                    cmd.Parameters.AddWithValue("@img", p.Foto);
                    cmd.Parameters.AddWithValue("@estoque", p.Estoque);
                    cmd.Parameters.AddWithValue("@categoria", p.Categoria);
                    cmd.Parameters.AddWithValue("@desativo", p.Desativado);
                    cmd.Parameters.AddWithValue("@cod_prod", p.Cod);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public int Deletar(int cod)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Produto SET ");
                sql.AppendLine("desativado = @desativado ");
                sql.AppendLine("WHERE cod_prod = @cod_prod ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@desativado", 1);
                    cmd.Parameters.AddWithValue("@cod_prod", cod);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }
    }
}

   