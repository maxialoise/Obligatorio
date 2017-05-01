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

        public List<Persona> Intregrantes { get; set; }

        public List<Evaluacion> Evaluaciones { get; set; }

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
            SqlTransaction trn = null;

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
                    trn = cnn.BeginTransaction();
                    cmd.Transaction = trn;

                    var res = cmd.ExecuteScalar();

                    this.Id = int.Parse(res.ToString());

                    foreach (var integrante in this.Intregrantes)
                    {
                        integrante.Usuario.AltaUsuario(cnn, cmd);
                        integrante.AltaPersona(cnn, cmd,this.Id);
                    }

                    trn.Commit();

                    resultado = true;

                    cmd.Dispose();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                trn.Rollback();
                return resultado;
            }
        }

        #endregion
    }
}
