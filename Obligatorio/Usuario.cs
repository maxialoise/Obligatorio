using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Dominio
{
    public class Usuario
    {
        #region Propiedades

        public int Id { get; set; }

        public string Rol { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        #endregion

        #region Constructor

        public Usuario()
        {

        }

        #endregion

        #region Metodos

        public static Usuario BuscarUsuario(string email, string password)
        {
            Usuario usu = null;

            try
            {
                using (SqlConnection cnn = new SqlConnection(@"Server=PC-102717\FARRIOLA; Database = Emprendimientos;Integrated Security=SSPI"))
                {
                    SqlCommand cmd = new SqlCommand("Buscar_Usuario", cnn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        usu = new Usuario();

                        while (reader.Read())
                        {
                            if (reader["Email"] != DBNull.Value)
                                usu.Email = (string)reader["Email"];

                            if (reader["Password"] != DBNull.Value)
                                usu.Password = (string)reader["Password"];

                            if (reader["Rol"] != DBNull.Value)
                                usu.Rol = (string)reader["Rol"];
                        }

                    }

                    cmd.Dispose();
                }

                return usu;
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                return usu;
            }
        }

        public bool AltaUsuario(SqlConnection cnn, SqlCommand cmd)
        {
            bool resultado = false;

            try
            {

                cmd.CommandText = "Alta_Usuario";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@password", this.Password);
                cmd.Parameters.AddWithValue("@rol", this.Rol);

                var res = cmd.ExecuteScalar();

                this.Id = int.Parse(res.ToString());

                resultado = true;

                return resultado;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return resultado;
            }
        }
        public bool AltaUsuario()
        {
            SqlConnection cnn = new SqlConnection(@"Server=PC-102717\FARRIOLA; Database = Emprendimientos;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand("Alta_Usuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cnn.Open();
            bool res = AltaUsuario(cnn, cmd);
            cnn.Close();
            return res;
        }
    }
    #endregion
}

