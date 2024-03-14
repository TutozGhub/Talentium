using System;
using System.Data;
using System.Data.SqlClient;


namespace AccesoDatos
{
    public class CD_EjecutarSP : CD_Conexion
    {
        public DataTable EjecutarConsultas(string NombreSP, SqlParameter[] sqlParameters, bool Directa = true)
        {
            DataTable DT = new DataTable();
            try
            {
                using (SqlConnection CNN = GetConnection())
                {
                    CNN.Open();
                    using (SqlCommand comando = new SqlCommand(NombreSP, CNN))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddRange(sqlParameters);
                        if (!Directa)
                        {
                            DT.Load(comando.ExecuteReader());
                        }
                        else
                        {
                            comando.ExecuteNonQuery();
                        }
                    }
                }
                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar procedimiento almacenado o Conexion a la Base de Datos. \n \n" + ex.Message);
            }
            finally
            {

            }
        }
       public DataTable EjecutarConsultasSinParam(string NombreSP, bool Directa = true )
        {
            DataTable DT = new DataTable();
            try
            {
                using (SqlConnection CNN = GetConnection())
                {
                    CNN.Open();
                    using (SqlCommand comando = new SqlCommand(NombreSP, CNN))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        if (!Directa)
                        {
                            DT.Load(comando.ExecuteReader());
                        }
                        else
                        {
                            comando.ExecuteNonQuery();
                        }
                    }
                }
                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar procedimiento almacenado o Conexion a la Base de Datos. \n \n" + ex.Message);
            }
            finally
            {

            }
        }
    }
}
