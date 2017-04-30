using System;
using System.Collections.Generic;
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

        public int Id { get; set; }

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
                using (SqlConnection cnn = new SqlConnection(@"Server=PC-102717\FARRIOLA; Database = Emprendimientos;Integrated Security=SSPI"))
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

                            if (reader["Id"] != DBNull.Value)
                                ev.Id = (int)reader["Id"];

                            if (reader["Telefono"] != DBNull.Value)
                                ev.Telefono = (string)reader["Telefono"];

                            if (reader["Calificacion"] != DBNull.Value)
                                ev.Calificacion = (int)reader["Calificacion"];

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

        #endregion
    }
}
