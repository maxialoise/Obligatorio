using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dominio
{
    public class Evaluador : Persona
    {
        #region Propiedades

        public string Telefono { get; set; }

        public int Calificacion { get; set; }

        #endregion

        #region Constructor
        public Evaluador()
        {
        }
        #endregion

        #region Metodos

        //public static Usuario BuscarUsuario(string email, string password)
        //{
        //    Usuario usu = null;

        //    try
        //    {
        //        using (SqlConnection cnn = new SqlConnection(@"Server=MAXI; Database = Emprendimientos;Integrated Security=SSPI"))
        //        {
        //            SqlCommand cmd = new SqlCommand("Buscar_Usuario", cnn);
        //            cmd.Parameters.AddWithValue("@email", email);
        //            cmd.Parameters.AddWithValue("@password", password);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cnn.Open();

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                usu = new Usuario();

        //                while (reader.Read())
        //                {
        //                    if (reader["Email"] != DBNull.Value)
        //                        usu.Email = (string)reader["Email"];

        //                    if (reader["Email"] != DBNull.Value)
        //                        usu.Password = (string)reader["Password"];

        //                    if (reader["Email"] != DBNull.Value)
        //                        usu.Rol = (string)reader["Rol"];
        //                }

        //            }

        //            cmd.Dispose();
        //        }

        //        return usu;
        //    }
        //    catch (Exception ex)
        //    {
        //        string erro = ex.Message;
        //        return usu;
        //    }
        //}

        //public bool AltaUsuario()
        //{
        //    bool resultado = false;

        //    try
        //    {
        //        using (SqlConnection cnn = new SqlConnection(@"Server=MAXI; Database = Emprendimientos;Integrated Security=SSPI"))
        //        {
        //            SqlCommand cmd = new SqlCommand("Alta_Usuario", cnn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@email", this.Email);
        //            cmd.Parameters.AddWithValue("@password", this.Password);
        //            cmd.Parameters.AddWithValue("@rol", this.Rol);

        //            cnn.Open();

        //            int res = cmd.ExecuteNonQuery();

        //            if (res > 0)
        //                resultado = true;

        //            cmd.Dispose();
        //        }

        //        return resultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.Message;
        //        return resultado;
        //    }
        //}
        #endregion
    }
}
