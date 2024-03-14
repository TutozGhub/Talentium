using AccesoDatos;
using AccesoDatos.Accesibilidad;
using Comun;
using LogicaNegocio.Bitacora;
using LogicaNegocio.Lenguajes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicaNegocio
{
    public class CN_LogicaUsuarios
    {
        public int IdUsuario { get; set; }
        public string UsrName { get; set; }
        public string Contrasenia { get; set; }
        public string Mail { get; set; }
        public decimal CambiaCada { get; set; }
        public object IdPerfil { get; set; }
        public int IdPersona { get; set; }
        public int RowIndex { get; set; }

        CD_Usuario cd_usuario = new CD_Usuario();
        CD_AccesoBD accesoDatos = new CD_AccesoBD();
        public DataTable ConsultarPersonalAltaUsuario(string cuil, string nombre, string apellido, int area)
        {
            if (string.IsNullOrEmpty(cuil)) cuil = "\0";
            if (string.IsNullOrEmpty(nombre)) nombre = "\0";
            if (string.IsNullOrEmpty(apellido)) apellido = "\0";

            try
            {
                return cd_usuario.ConsultarPersonalAltaUsuario(cuil, nombre, apellido, area);
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        private void InsertarNuevoUsuario(int id_persona, string usuario, string password, int cambia_cada, int[] permisos, string mail)
        {
            string digito = Seguridad.Hash(Seguridad.DigVerif(Seguridad.Hash(password)).ToString());
            int _idPerfil = (int)IdPerfil;
            password = Seguridad.Hash(usuario + password);
            usuario = Seguridad.Encriptar(usuario);

            try
            {
                int id_usuario = cd_usuario.InsertarNuevoUsuario(id_persona, usuario, password, cambia_cada, digito, mail, _idPerfil);
                if (_idPerfil == -1 && permisos.Length > 0)
                {
                    foreach (int id_permiso in permisos)
                    {
                        cd_usuario.InsertarNuevoPermisoUsuario(id_usuario, id_permiso);
                    }
                }
                CN_Bitacora.AltaBitacora($"Usuario dado de alta ID: {id_usuario}", "INSERT", "frmAltaUsuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ConsultarAreas()
        {
            try
            {
                DataTable dt = accesoDatos.ConsultaAreas();
                DataRow dr = dt.NewRow();
                dt.Rows.Add(new Object[] { -1, Errores.Todas });
                return dt;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public DataTable ConsultarPermisosLst()
        {
            try
            {
                return cd_usuario.ConsultarPermisosLst();
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public DataTable ConsultarPerfiles(bool cmb = true)
        {
            try
            {
                DataTable dt = accesoDatos.ConsultarPerfiles();
                if (cmb)
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(new Object[] { -1, Errores.Personalizado });
                }
                return dt;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public DataTable ConsultarPermisosPerfil()
        {
            try
            {
                cd_usuario.IdPerfil = IdPerfil;
                return cd_usuario.ConsultarPermisosPerfil();
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        private string MandarMail(int id_persona, string psw, string mail)
        {
            CN_EnviarEmail email = new CN_EnviarEmail();
            return email.EnviarContraseña(mail, psw);
        }
        private (bool, string) ValidarAltaUsuario(string usr, string psw, DataGridView dtg, int rowIndex)
        {
            if (string.IsNullOrWhiteSpace(usr) | string.IsNullOrWhiteSpace(psw))
            {
                return (false, Errores.CamposIncompletos);
            }

            if (usr.Contains(" "))
            {
                return (false, Errores.UsrEspacios);
            }

            if (dtg.DataSource == null)
            {
                return (false, Errores.RegNoSelec);
            }

            if (!string.IsNullOrEmpty(dtg.Rows[rowIndex].Cells[5].Value.ToString()))
            {
                return (false, Errores.UsrYaAsignado);
            }

            if (cd_usuario.ConsultarUsuarioRepetido(Seguridad.Encriptar(usr)).Rows.Count > 0)
            {
                return (false, Errores.UsrYaEnUso);
            }


            return (true, "");
        }
        public bool AltaUsuario(DataTable dtListaMem, DataGridView dtg)
        {
            int len;
            string msg;
            List<int> permisos = new List<int>();
            Tuple<bool, string> verif = ValidarAltaUsuario(UsrName, Contrasenia, dtg, RowIndex).ToTuple();

            if (verif.Item1)
            {
                // lista de permisos
                len = dtListaMem.Rows.Count;

                if ((int)IdPerfil == -1)
                {
                    for (int i = 0; i < len; i++)
                    {
                        // carga todos los permisos del dtListaMem en la lista permisos
                        permisos.Add(Convert.ToInt32(dtListaMem.Rows[i][0]));
                    }
                }
                // Intenta enviar un mail (si se puede manda la contraseña y devuelve un mensaje vacio, sino devuelve un mensaje de error)
                msg = MandarMail(IdPersona, Contrasenia, Mail);
                if (string.IsNullOrEmpty(msg))
                {
                    InsertarNuevoUsuario(IdPersona, UsrName, Contrasenia, (int)CambiaCada, permisos.ToArray(), Mail);
                    return true;
                }
                else
                {
                    MessageBox.Show(msg, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(verif.Item2, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }
        public void ModificarUsuario(DataTable dtListaMem)
        {
            if (IdPerfil != null)
            {
                List<int> permisos = new List<int>();
                int len = dtListaMem.Rows.Count;

                if ((int)IdPerfil == -1)
                {
                    for (int i = 0; i < len; i++)
                    {
                        // carga todos los permisos del dtListaMem en la lista permisos
                        permisos.Add(Convert.ToInt32(dtListaMem.Rows[i][0]));
                    }
                }
                // Hace la modificacion
                UpUsuario(permisos.ToArray());
            }
        }
        private void UpUsuario(int[] permisos)
        {
            try
            {
                cd_usuario.IdUsuario = IdUsuario;
                cd_usuario.CambiaCada = (int)CambiaCada;
                cd_usuario.Mail = Mail;
                cd_usuario.IdPerfil = IdPerfil;

                if (cd_usuario.UpUsuario() && (int)IdPerfil == -1 && permisos.Length > 0)
                {
                    foreach (int id_permiso in permisos)
                    {
                        cd_usuario.InsertarNuevoPermisoUsuario(IdUsuario, id_permiso);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ConsultarPersonaMod()
        {
            cd_usuario.IdUsuario = IdUsuario;
            return cd_usuario.ConsultarPersonaMod();
        }
        public DataTable ConsultarPermisosUsuario()
        {
            cd_usuario.IdUsuario = IdUsuario;

            if ((int)IdPerfil != -1)
            {
                cd_usuario.IdPerfil = IdPerfil;
                return cd_usuario.ConsultarPermisosPerfilUsuario();
            }
            return cd_usuario.ConsultarPermisosUsuario();
        }
        public DataTable ConsultarUsuario(string usuario, string nombre, string apellido, int area, bool estado)
        {
            if (string.IsNullOrEmpty(usuario)) usuario = "\0";
            else usuario = Seguridad.Encriptar(usuario);
            if (string.IsNullOrEmpty(nombre)) nombre = "\0";
            if (string.IsNullOrEmpty(apellido)) apellido = "\0";

            DataTable dt = cd_usuario.ConsultarUsuario(usuario, nombre, apellido, area, estado);

            for (int i = 0, len = dt.Rows.Count; i < len; i++)
            {
                dt.Rows[i][1] = Seguridad.DesEncriptar(dt.Rows[i][1].ToString());
                if (dt.Rows[i][5].ToString() == "")
                {
                    dt.Rows[i][5] = Errores.Personalizado;
                }
            }

            return dt;
        }
        public void BajaUsuario()
        {
            cd_usuario.IdUsuario = IdUsuario;
            cd_usuario.BajaUsuario();
        }
        public void ReactivarUsuario()
        {
            cd_usuario.IdUsuario = IdUsuario;
            cd_usuario.ReactivarUsuario();
        }
    }
}
