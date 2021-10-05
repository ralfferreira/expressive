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
    public class ClienteDAL
    {
        public int CadClie(Cliente c)
        {
            int reg = 0;
            using(SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("INSERT INTO Cliente ");
                sql.AppendLine("(nome_clie, endereco, cidade, cep, uf, cpf, email, senha) ");
                sql.AppendLine("VALUES (@nome, @endereco, @cidade, @cep, @uf, @cpf, @email, HASHBYTES('SHA1',@senha)) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY() as cod; ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome", c.Nome);
                    cmd.Parameters.AddWithValue("@endereco", c.Endereco);
                    cmd.Parameters.AddWithValue("@cidade", c.Cidade);
                    cmd.Parameters.AddWithValue("@cep", c.Cep);
                    cmd.Parameters.AddWithValue("@uf", c.Uf);
                    cmd.Parameters.AddWithValue("@cpf", c.Cpf);
                    cmd.Parameters.AddWithValue("@email", c.Email);
                    cmd.Parameters.AddWithValue("@senha", c.Senha);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                c.Cod = Convert.ToInt32(dr["cod"]);
                            }
                        }
                    }
                    con.Close();
                }
                return reg;
            }
        }

        public List<Cliente> SelecionarTodos()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT cod_clie, nome_clie, endereco, cidade, cep, uf, cpf, email ");
                sql.AppendLine("FROM Cliente");                

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Cliente c = new Cliente();
                                c.Cod = Convert.ToInt32(dr["cod_clie"]);
                                c.Nome = dr["nome_clie"].ToString();
                                c.Endereco = dr["endereco"].ToString();
                                c.Cidade = dr["cidade"].ToString();
                                c.Cep = dr["cep"].ToString();
                                c.Uf = dr["uf"].ToString();
                                c.Cpf = dr["cpf"].ToString();
                                c.Email = dr["email"].ToString();
                                
                                listaClientes.Add(c);//Adicionando o objeto para a lista
                            }
                        }
                        return listaClientes;
                    }
                }
            }
        }

        public Cliente SelecionarPorCod(int cod)
        {
            Cliente c = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT cod_clie, nome_clie, endereco, cidade, cep, uf, cpf, email ");
                sql.AppendLine("FROM Cliente WHERE cod_clie = @cod");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@cod", cod); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                c = new Cliente();
                                c.Cod = Convert.ToInt32(dr["cod_clie"]);
                                c.Nome = dr["nome_clie"].ToString();
                                c.Endereco = dr["endereco"].ToString();
                                c.Cidade = dr["cidade"].ToString();
                                c.Cep = dr["cep"].ToString();
                                c.Uf = dr["uf"].ToString();
                                c.Cpf = dr["cpf"].ToString();
                                c.Email = dr["email"].ToString();
                            }
                        }
                        return c;
                    }
                }
            }
        }

        public int Atualizar(Cliente c)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("UPDATE Cliente SET ");
                sql.AppendLine("nome_clie = @nome, ");
                sql.AppendLine("endereco = @endereco, ");
                sql.AppendLine("cidade = @cidade, ");
                sql.AppendLine("cep = @cep, ");
                sql.AppendLine("uf = @uf, ");
                sql.AppendLine("cpf = @cpf, ");
                sql.AppendLine("email = @email, ");
                sql.AppendLine("senha = HASHBYTES('SHA1',@senha) ");
                sql.AppendLine("WHERE cod_clie = @cod");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome", c.Nome);
                    cmd.Parameters.AddWithValue("@endereco", c.Endereco);
                    cmd.Parameters.AddWithValue("@cidade", c.Cidade);
                    cmd.Parameters.AddWithValue("@cep", c.Cep);
                    cmd.Parameters.AddWithValue("@uf", c.Uf);
                    cmd.Parameters.AddWithValue("@cpf", c.Cpf);
                    cmd.Parameters.AddWithValue("@email", c.Email);
                    cmd.Parameters.AddWithValue("@senha", c.Senha);
                    cmd.Parameters.AddWithValue("@cod", c.Cod);

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
                sql.AppendLine("DELETE FROM Cliente ");
                sql.AppendLine("WHERE cod_clie = @cod_clie ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@cod_clie", cod);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }
    }
}
