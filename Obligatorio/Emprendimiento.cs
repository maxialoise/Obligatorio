using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Emprendimiento
    {
        #region Propiedades

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public int PuntajeFinal { get; set; }


        #endregion

        #region Constructor
        public Emprendimiento()
        {
        }
        #endregion

        #region Metodos

        public bool AltaEmprendimiento()
        {
            bool resultado = false;

            try
            {
                using (SqlConnection cnn = new SqlConnection(@"Server=PC-102717\FARRIOLA; Database = Emprendimientos;Integrated Security=SSPI"))
                {
                    SqlCommand cmd = new SqlCommand("Alta_Emprendimiento", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@titulo", this.Titulo);
                    cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
                    cmd.Parameters.AddWithValue("@puntajeFinal", this.PuntajeFinal);

                    cnn.Open();

                    var res = cmd.ExecuteScalar();

                    this.Id = int.Parse(res.ToString());

                    resultado = true;

                    cmd.Dispose();
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
