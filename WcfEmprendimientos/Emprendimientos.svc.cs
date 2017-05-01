using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfEmprendimientos.DTOS;

namespace WcfEmprendimientos
{
    public class Emprendimientos : IEmprendimientos
    {
        public List<DTOEmprendimiento> ObtenerEmprendimientos()
        {
            List<DTOEmprendimiento> lst = null;
            try
            {
                using (SqlConnection cnn = new SqlConnection(@"Server=PC-102717\FARRIOLA; Database = Emprendimientos;Integrated Security=SSPI"))
                {
                    SqlCommand cmd = new SqlCommand("Obtener_Emprendimientos", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        lst = new List<DTOEmprendimiento>();

                        while (reader.Read())
                        {
                            DTOEmprendimiento emp = new DTOEmprendimiento();

                            if (reader["Id"] != DBNull.Value)
                                emp.Id = (int)reader["Id"];

                            if (reader["Titulo"] != DBNull.Value)
                                emp.Titulo = (string)reader["Titulo"];

                            if (reader["Descripcion"] != DBNull.Value)
                                emp.Descripcion = (string)reader["Descripcion"];

                            if (reader["TiempoPrevisto"] != DBNull.Value)
                                emp.TiempoPrevisto = (int)reader["TiempoPrevisto"];

                            if (reader["Costo"] != DBNull.Value)
                                emp.Costo = (int)reader["Costo"];

                            if (reader["PuntajeFinal"] != DBNull.Value)
                                emp.PuntajeFinal = (int)reader["PuntajeFinal"];

                            lst.Add(emp);
                        }
                    }

                    cmd.Dispose();
                }

                return lst;
            }
            catch (Exception)
            {
                return lst;
            }
        }
    }
}
