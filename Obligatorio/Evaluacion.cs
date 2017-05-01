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
                    SqlParameter outputParam = cmd.Parameters.Add("@retorno", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;

                    cnn.Open();

                    int res = cmd.ExecuteNonQuery();                    

                    if (res != -1)
                    {
                        result = true;
                        message = "Exito";
                    }
                    else
                    {
                        int retorno = int.Parse(outputParam.Value.ToString());
                        if (retorno == -3)
                        {
                            message = "Ya se encuentra asignado ese evaluador al emprendimiento";
                        }
                        else if (retorno == -2)
                        {
                            message = "El emprendimiento seleccionado ya cuenta con 3 evaluadores";
                        }

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
