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
    public class Evaluador : Persona
    {
        #region Propiedades

        public int IdEvaluador { get; set; }

        public string Telefono { get; set; }

        public int Calificacion { get; set; }

        #endregion

        #region Constructor
        public Evaluador()
        {
        }

        #endregion

        #region Metodos

        public static List<Evaluador> ObtenerEvaluadores()
        {
            List<Evaluador> lstEvaluadores = null;

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Obtener_Evaluadores", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        lstEvaluadores = new List<Evaluador>();

                        while (reader.Read())
                        {
                            Evaluador ev = new Evaluador();

                            if (reader["IdEvaluador"] != DBNull.Value)
                                ev.IdEvaluador = (int)reader["IdEvaluador"];

                            if (reader["Telefono"] != DBNull.Value)
                                ev.Telefono = (string)reader["Telefono"];

                            if (reader["Calificacion"] != DBNull.Value)
                                ev.Calificacion = (int)reader["Calificacion"];

                            if (reader["Nombre"] != DBNull.Value)
                                ev.Nombre = (string)reader["Nombre"];

                            lstEvaluadores.Add(ev);
                        }
                    }

                    cmd.Dispose();
                }

                return lstEvaluadores;
            }
            catch (Exception)
            {
                return lstEvaluadores;
            }
        }

        public bool AltaEvaluador()
        {
            bool resultado = false;
            if (this.AltaPersona())
            {
                try
                {
                    using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT into EVALUADOR (Persona, Telefono, Calificacion) VALUES (@persona, @telefono, @calificacion)", cnn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@persona", this.Id);
                        cmd.Parameters.AddWithValue("@telefono", this.Telefono);
                        cmd.Parameters.AddWithValue("@calificacion", this.Calificacion);
                        cnn.Open();

                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                            resultado = true;
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }
            return resultado;
        }
        #endregion
    }
}
