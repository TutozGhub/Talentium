using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AccesoDatos
{
    public class CD_Backup : CD_Conexion
    {
        public string Path { get; set; }
        public void HacerBackup()
        {
            string fecha = DateTime.Now.ToFileTime().ToString();
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string backupQuery = $@"BACKUP DATABASE Talentium TO DISK= N'{Path}Talentium {fecha}.bak'";
                    SqlCommand command = new SqlCommand(backupQuery, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("¡Respaldo realizado con éxito!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargarBackup(string filePath)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string restoreQuery = $"USE master RESTORE DATABASE Talentium FROM DISK='{filePath}' WITH REPLACE";
                    SqlCommand command = new SqlCommand(restoreQuery, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("¡Restauración realizada con éxito!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
