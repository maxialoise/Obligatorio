using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Evaluacion
    {
        #region Propiedades
        public Evaluador Evaluador { get; set; }

        public int Puntaje { get; set; }

        public string Justificacion { get; set; }

        public DateTime FechaEvaluacion { get; set; }

        #endregion

        #region Constructor
        public Evaluacion()
        {
        }
        #endregion

        #region Metodos

        public bool AltaEvaluacion(int idEmprendimiento, out string message)
        {
            bool result = false;
            message = string.Empty;

            try
            {
                using (SqlConnection cnn = new SqlConnection(@"Server=PC-102717\FARRIOLA; Database = Emprendimientos;Integrated Security=SSPI"))
                {
                    SqlCommand cmd = new SqlCommand("Alta_Evaluacion", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@evaluador", this.Evaluador.Id);
                    cmd.Parameters.AddWithValue("@idEmprendimiento", idEmprendimiento);
                    cnn.Open();

                    int res = cmd.ExecuteNonQuery();

                    if (res == -1)
                    {
                        message = "Ya se encuentra asignado el evaluador a el emprendimiento seleccionado";
                    }
                    else if (res == -2)
                    {
                        message = "El emprendimiento seleccionado ya cuenta con 3 evaluadores";
                    }
                    else if (res > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        message = "Error inesperado";
                    }

                    cmd.Dispose();
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
