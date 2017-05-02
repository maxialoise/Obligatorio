using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        #region Propiedades

        public int Id { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public Usuario Usuario { get; set; }

        #endregion

        #region Constructor
        public Persona()
        {
        }

        #endregion

        #region Metodos

        public bool AltaPersona(SqlConnection cnn, SqlCommand cmd, int idEmprendimiento)
        {
            bool resultado = false;

            try
            {
                cmd.CommandText = "Alta_Persona";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cedula", this.Cedula);
                cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@idUsuario", this.Usuario.Id);
                cmd.Parameters.AddWithValue("@idEmprendimiento", idEmprendimiento);

                var res = cmd.ExecuteNonQuery();

                this.Id = int.Parse(res.ToString());

                resultado = true;

                return resultado;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                throw ex;
            }
        }
        public bool AltaPersona()
        {

            bool resultado = false;

            try
            {
                if (this.Usuario.AltaUsuario())
                {
                    using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT into PERSONA (Cedula, Nombre, Email, Usuario) VALUES (@cedula, @nombre, @email, @idUsuario) SELECT CAST(SCOPE_IDENTITY() as int)", cnn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@cedula", this.Cedula);
                        cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                        cmd.Parameters.AddWithValue("@email", this.Email);
                        cmd.Parameters.AddWithValue("@idUsuario", this.Usuario.Id);
                        cnn.Open();

                        var res = cmd.ExecuteScalar();
                        if (res != null)
                        {
                            this.Id = int.Parse(res.ToString());
                            resultado = true;
                        }
                                                 
                    }
                }
                return resultado;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return resultado;
            }
        }

        #endregion
    }
}
