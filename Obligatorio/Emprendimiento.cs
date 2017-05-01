﻿using System;
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

        public static List<Emprendimiento> ObtenerEmprendimientos()
        {
            List<Emprendimiento> lst = null;

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
                        lst = new List<Emprendimiento>();

                        while (reader.Read())
                        {
                            Emprendimiento emp = new Emprendimiento();

                            if (reader["Id"] != DBNull.Value)
                                emp.Id = (int)reader["Id"];

                            if (reader["Titulo"] != DBNull.Value)
                                emp.Titulo = (string)reader["Titulo"];

                            if (reader["Descripcion"] != DBNull.Value)
                                emp.Descripcion = (string)reader["Descripcion"];

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
                        integrante.AltaPersona(cnn, cmd, this.Id);
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
