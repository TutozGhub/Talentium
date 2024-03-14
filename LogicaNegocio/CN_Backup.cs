using AccesoDatos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicaNegocio
{
    public class CN_Backup
    {
        CD_Backup bk = new CD_Backup();
        private string path = @"c:\TalentiumBaks\";
        public string Path
        {
            get => path;
        }
        public CN_Backup()
        {
            bk.Path = Path;
            // Verificar si el directorio existe
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Directorio creado exitosamente.");
            }
        }
        public void HacerBackup()
        {
            try
            {
                bk.HacerBackup();
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
                bk.CargarBackup(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
