using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Properties;

namespace Vista.Lenguajes
{
    public class Idioma
    {
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public string Pais { get; set; }
        public string AbreviacionPais { get; set; }
        public string NombrePais { get => Nombre + "(" + Pais + ")"; }
        //public String NombrePais { get { return Nombre + "(" + Pais + ")"; } }
        public string InfoCultura { get => Abreviacion + "-" + AbreviacionPais; }

        public static List<Idioma> ObtenerIdiomas()
        {
            return new List<Idioma> {
                new Idioma
                {
                    Nombre = "Español",
                    Abreviacion = "es",
                    Pais = "Argentina",
                    AbreviacionPais = "AR"
                },
                new Idioma
                {
                    Nombre = "English",
                    Abreviacion = "en",
                    Pais = "Estados Unidos",
                    AbreviacionPais = "US"
                }
            };
        }

        public static void CargarIdioma(Control.ControlCollection controls, Form frm)
        {
            //Este metodo recibe dos parametros, 
            //Asigno el idioma a utilizar 
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Settings.Default.Idioma);
            //Llamo al metodo interno pasandole los parametros necesarios
            //para que cambie los nombres de los objetos
            CambiarTexto(controls, frm);
            frm.Icon = Properties.Resources.icono;
            frm.MaximizeBox= false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.BackColor = Color.White;
        }
        private static void CambiarTexto(Control.ControlCollection controls, Form frm)
        {
            frm.Text = Strings.ResourceManager.GetString(frm.Name);

            foreach (Control c in controls)
            {
                if (c is Panel | c is GroupBox | c is TabControl)
                {
                    CambiarTexto(c.Controls, frm);
                }
                else if (c is MenuStrip menuStrip)
                {
                    foreach (ToolStripMenuItem item in menuStrip.Items)
                    {
                        TraducirMenuItem(item);
                    }
                }
                string text = Strings.ResourceManager.GetString(c.Name);
                if (text != null)
                {
                    c.Text = text;
                }
            }
        }
        private static void TraducirMenuItem(ToolStripMenuItem menuItem)
        {
            menuItem.Text = Strings.ResourceManager.GetString(menuItem.Name);
            foreach (ToolStripMenuItem subItem in menuItem.DropDownItems)
            {
                TraducirMenuItem(subItem);
            }
        }

    }
}