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
    public class FuncionarioDAL
    {
        public int CadFun(Funcionario f)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("INSERT INTO Funcionario ");
                sql.AppendLine("(nome_fun, endereco, cidade, cep, uf, cpf, email, senha, nome_cargo, salario_fixo, dt_contrato, comissao) ");
                sql.AppendLine("VALUES (@nome, @endereco, @cidade, @cep, @uf, @cpf, @email, HASHBYTES('SHA1',@senha), @cargo, @salario, @contrato, @comissao) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY() as cod;");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome", f.Nome);
                    cmd.Parameters.AddWithValue("@endereco", f.Endereco);
                    cmd.Parameters.AddWithValue("@cidade", f.Cidade);
                    cmd.Parameters.AddWithValue("@cep", f.Cep);
                    cmd.Parameters.AddWithValue("@uf", f.Uf);
                    cmd.Parameters.AddWithValue("@cpf", f.Cpf);
                    cmd.Parameters.AddWithValue("@email", f.Email);
                    cmd.Parameters.AddWithValue("@senha", f.Senha);
                    cmd.Parameters.AddWithValue("@cargo", f.Cargo);
                    cmd.Parameters.AddWithValue("@salario", f.Salario_fixo);
                    cmd.Parameters.AddWithValue("@contrato", f.Dt_contrato);
                    cmd.Parameters.AddWithValue("@comissao", f.Comissao);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                f.Cod = Convert.ToInt32(dr["cod"]);
                            }
                        }
                    }
                    con.Close();
                }
                return reg;
            }
        }

        public List<Funcionario> SelecionarTodos()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT cod_fun, nome_fun, endereco, cidade, cep, uf, cpf, email, nome_cargo, salario_fixo, dt_contrato, comissao ");
                sql.AppendLine("FROM Funcionario ");
                sql.AppendLine("WHERE dt_demissao IS NULL");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Funcionario f = new Funcionario();
                                f.Cod = Convert.ToInt32(dr["cod_fun"]);
                                f.Nome = dr["nome_fun"].ToString();
                                f.Endereco = dr["endereco"].ToString();
                                f.Cidade = dr["cidade"].ToString();
                                f.Cep = dr["cep"].ToString();
                                f.Uf = dr["uf"].ToString();
                                f.Cpf = dr["cpf"].ToString();
                                f.Email = dr["email"].ToString();
                                f.Cargo = dr["nome_cargo"].ToString();
                                f.Salario_fixo = Convert.ToDecimal(dr["salario_fixo"]);
                                f.Dt_contrato = Convert.ToDateTime (dr["dt_contrato"]);
                                f.Comissao = dr["comissao"].ToString();

                                listaFuncionarios.Add(f);//Adicionando o objeto para a lista
                            }
                        }
                        return listaFuncionarios;
                    }
                }
            }
        }

        public Funcionario SelecionarPorCod(int cod)
        {
            Funcionario f = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT cod_fun, nome_fun, endereco, cidade, cep, uf, cpf, email, nome_cargo, salario_fixo, dt_contrato ");
                sql.AppendLine("FROM Funcionario WHERE cod_fun = @cod_fun AND dt_demissao IS NULL");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@cod_fun", cod); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                f = new Funcionario();
                                f.Cod = Convert.ToInt32(dr["cod_fun"]);
                                f.Nome = dr["nome_fun"].ToString();
                                f.Endereco = dr["endereco"].ToString();
                                f.Cidade = dr["cidade"].ToString();
                                f.Cep = dr["cep"].ToString();
                                f.Uf = dr["uf"].ToString();
                                f.Cpf = dr["cpf"].ToString();
                                f.Email = dr["email"].ToString();
                                f.Cargo = dr["nome_cargo"].ToString();
                                f.Salario_fixo = Convert.ToDecimal(dr["salario_fixo"]);
                                f.Dt_contrato = Convert.ToDateTime (dr["dt_contrato"]);
                            }
                        }
                        return f;
                    }
                }
            }
        }

        public int AtualizarAdmin(Funcionario f)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("UPDATE Funcionario SET ");                
                sql.AppendLine("cpf = @cpf, ");
                sql.AppendLine("email = @email, ");               
                sql.AppendLine("nome_cargo = @cargo, ");
                sql.AppendLine("salario_fixo = @salario, ");
                sql.AppendLine("comissao = @comissao "); 
                sql.AppendLine("WHERE cod_fun = @cod_fun");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;                   
                    cmd.Parameters.AddWithValue("@cpf", f.Cpf);
                    cmd.Parameters.AddWithValue("@email", f.Email);                   
                    cmd.Parameters.AddWithValue("@cargo", f.Cargo);
                    cmd.Parameters.AddWithValue("@salario", f.Salario_fixo);
                    cmd.Parameters.AddWithValue("@comissao", f.Comissao);                    
                    cmd.Parameters.AddWithValue("@cod_fun", f.Cod);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public int AtualizarUser(Funcionario f)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("UPDATE Funcionario SET ");
                sql.AppendLine("nome_fun = @nome, ");
                sql.AppendLine("endereco = @endereco, ");
                sql.AppendLine("cidade = @cidade, ");
                sql.AppendLine("cep = @cep, ");
                sql.AppendLine("uf = @uf, ");
                sql.AppendLine("cpf = @cpf, ");
                sql.AppendLine("email = @email, ");
                sql.AppendLine("senha = HASHBYTES('SHA1',@senha) ");               
                sql.AppendLine("WHERE cod_fun = @cod_fun");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome", f.Nome);
                    cmd.Parameters.AddWithValue("@endereco", f.Endereco);
                    cmd.Parameters.AddWithValue("@cidade", f.Cidade);
                    cmd.Parameters.AddWithValue("@cep", f.Cep);
                    cmd.Parameters.AddWithValue("@uf", f.Uf);
                    cmd.Parameters.AddWithValue("@cpf", f.Cpf);
                    cmd.Parameters.AddWithValue("@email", f.Email);
                    cmd.Parameters.AddWithValue("@senha", f.Senha);
                    cmd.Parameters.AddWithValue("@cod_fun", f.Cod);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public int Demitir(int cod)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("UPDATE Funcionario SET ");
                sql.AppendLine("dt_demissao = @demissao ");
                sql.AppendLine("WHERE cod_fun = @cod_fun");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@demissao", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@cod_fun", cod);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public List<Funcionario> RelatorioVendas()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("EXEC procVendas");                

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Funcionario f = new Funcionario();                                
                                f.Nome = dr["nome_fun"].ToString();
                                f.Vendas = Convert.ToInt32(dr["vendas"]);
                                f.ValorTotal = Convert.ToDecimal(dr["total"]);

                                listaFuncionarios.Add(f);//Adicionando o objeto para a lista
                            }
                        }
                        return listaFuncionarios;
                    }
                }
            }
        }
    }
}

   
