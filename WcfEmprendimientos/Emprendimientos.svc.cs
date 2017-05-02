using System;
using System.Collections.Generic;
using System.Configuration;
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
            List<DTOEvaluador> lstEv = null;
            List<DTOPersona> lstPersona = null;

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString))
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

                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("ObtenerEvaluadoresPorEmprendimiento", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    lstEv = new List<DTOEvaluador>();

                    while (reader.Read())
                    {
                        DTOEvaluador ev = new DTOEvaluador();

                        if (reader["Id"] != DBNull.Value)
                            ev.IdEmprendimiento = (int)reader["Id"];

                        if (reader["Nombre"] != DBNull.Value)
                            ev.NombreEvaluador = (string)reader["Nombre"];

                        if (reader["Justificacion"] != DBNull.Value)
                            ev.Justificacion = (string)reader["Justificacion"];

                        lstEv.Add(ev);
                    }
                    cmd.Dispose();

                }

                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("ObtenerIntegrantesPorEmprendimiento", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    lstPersona = new List<DTOPersona>();

                    while (reader.Read())
                    {
                        DTOPersona persona = new DTOPersona();

                        if (reader["Id"] != DBNull.Value)
                            persona.IdEmprendimiento = (int)reader["Id"];

                        if (reader["Nombre"] != DBNull.Value)
                            persona.Nombre = (string)reader["Nombre"];

                        lstPersona.Add(persona);
                    }

                }

                foreach (var emprendimiento in lst)
                {

                    foreach (var evaluador in lstEv)
                    {
                        if (emprendimiento.Id == evaluador.IdEmprendimiento)
                        {
                            if (emprendimiento.Evaluadores == null)
                            {
                                emprendimiento.Evaluadores = new List<DTOEvaluador>();
                            }
                            emprendimiento.Evaluadores.Add(evaluador);
                        }
                    }

                    foreach (var persona in lstPersona)
                    {
                        if (emprendimiento.Id == persona.IdEmprendimiento)
                        {
                            if (emprendimiento.Intregrantes == null)
                            {
                                emprendimiento.Intregrantes = new List<DTOPersona>();
                            }
                            emprendimiento.Intregrantes.Add(persona);
                        }
                    }

                }

                return lst;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return lst;
            }
        }
    }
}
