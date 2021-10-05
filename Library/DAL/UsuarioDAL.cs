using Library.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class UsuarioDAL
    {
        public int Login(Usuario u)
        {
            int Result = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("EXEC procLogin @Email = '" + u.Email + "', @Senha = '"+ u.Senha +"' ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Result = Convert.ToInt32(dr["resultado"]);
                            if(Result != 3)
                            {
                                u.Cod = Convert.ToInt32(dr["cod"]);
                            }
                        }                        
                        return Result;
                    }
                }
            }
        }

        public int Registrar(Usuario u)
        {
            int Result = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("EXEC procRegistrar @Email = '" + u.Email + "', @CPF = '" + u.Cpf + "' ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Result = Convert.ToInt32(dr["resultado"]);                            
                        }
                        return Result;
                    }
                }
            }
        }
    }
}
