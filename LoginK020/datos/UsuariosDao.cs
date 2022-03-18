using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LoginK020.datos
{
    internal class UsuariosDao
    {
        private const string ConnString = "server=(localdb)\\MSSQLLocalDB; database=proyectok20; Trusted_Connection=True";
        private const string sqlLogin = "select * from Usuarios where username = @nombreUsuario;";

        public Usuario buscarUsuarioPorUsername(string username, string password)
        {
            Usuario user = null;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConnString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = sqlLogin;
                command.Connection = connection;
                SqlParameter usernameParameter = new SqlParameter("@nombreUsuario", username);
                command.Parameters.Add(usernameParameter);
                SqlDataReader dr = command.ExecuteReader();
                Console.WriteLine("Se encontro registro" + dr.HasRows);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (password == dr.GetString("password"))
                        {
                            user = new Usuario();
                            user.Id = dr.GetInt32("id");
                            user.Password = dr.GetString("password");
                            user.NombreCompleto = dr.GetString("Nombre_Completo");
                            break;
                        }
                    }
                }
            }
            return user;
        }
    }
}
