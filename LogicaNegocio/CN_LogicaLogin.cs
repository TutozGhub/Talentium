using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos.Accesibilidad;
using AccesoDatos.Login;
using Comun;
using LogicaNegocio.Bitacora;
using LogicaNegocio.Lenguajes;

namespace LogicaNegocio
{
    public class CN_LogicaLogin
    {
        public string Message { get; set; }
        public string MensajeError { get; set; }
        private DateTime horaBloqueo;

        CD_Login login = new CD_Login();
        private bool LoginUser(string usuario, string pass)
        {
            string usr = Seguridad.Encriptar(usuario);
            string psw = Seguridad.Hash(usuario + pass);
            string dig = Seguridad.Hash(Seguridad.DigVerif(Seguridad.Hash(pass)).ToString());
            Console.WriteLine(usr);
            Console.WriteLine(psw);
            Console.WriteLine(dig);
            try
            {
                CargarCache(usr);

                if (ValUsr(usuario, pass))
                {
                    CN_LogicaLogin logicaLogin = new CN_LogicaLogin();
                    logicaLogin.RestaurarIntentosUser();
                    return true;
                }
                else if (DateTime.Now < GetHoraDesbloqueo())
                {
                    MessageBox.Show($"{Errores.LiminteIntentos} {GetHoraDesbloqueo().ToLongTimeString()}.", Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    MessageBox.Show(MensajeError, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BloqueoUser(int id, DateTime? hBloqueo)
        {
            try
            {
                login.Bloquear(id, hBloqueo);
            }
            catch
            {
            }
        }
        private void RestarIntento()
        {
            try
            {
                login.RestarIntento(UserCache.id);
                CargarCache(UserCache.usuario);
            }
            catch
            {
            }
        }
        private void RestaurarIntentosUser()
        {
            try
            {
                login.RestaurarIntentos(UserCache.id, ConfigCache.Intentos);
                CargarCache(UserCache.usuario);
            }
            catch
            {
            }
        }
        public static bool LogIn(string usuario, string password)
        {
            if (camposVacios(usuario, password))
            {
                CN_LogicaLogin login = new CN_LogicaLogin();
                try
                {
                    if (login.LoginUser(usuario, password))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show(Errores.UsrPswIncorrecto, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void UsuarioEmail(string usuario)
        {
            string user = Seguridad.Encriptar(usuario);
            DataTable tabla = login.EmailDeRecupero(user);
            UserCache.id = Convert.ToInt32(tabla.Rows[0][2]);
            UserCache.usuario = (string)tabla.Rows[0][4];

            //se valida que el usuario sea ingresado correctamente
            if (tabla != null && tabla.Rows.Count > 0)
            {
                try
                {

                    CN_EnviarEmail email = new CN_EnviarEmail();

                    //el usuario es correcto, por ello debemos genear el codigo y enviar el email
                    string correo = Convert.ToString(tabla.Rows[0][0]);
                    //UserCache.id = Convert.ToInt32(tabla.Rows[0][2]);
                    var tup = email.ObtenerCod();
                    string cod = tup.Item1;
                    DateTime fhCaducidad = tup.Item2;

                    Message = email.Enviar(UserCache.id, correo, cod, fhCaducidad);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{Errores.ErrorMail}: " + e, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(Errores.UsrInvalido, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public bool ValidCode(string codEmail)
        {
            //se realiza el metodo para traer los campos de cod y fecha y validar ambos:
            DataTable tabla = login.ValidCode(UserCache.id);
            DateTime feHoy = DateTime.Now;
            DateTime fechaCaducidad = Convert.ToDateTime(tabla.Rows[0][0]);
            string cod = Convert.ToString(tabla.Rows[0][1]);
            DateTime feCad = Convert.ToDateTime(tabla.Rows[0][0]).AddHours(-1);
            if (feHoy >= feCad && feHoy <= fechaCaducidad)
            {
                if (codEmail == cod)
                {
                    return true;
                }
                else
                {
                    //codigo erroneo, porfavor intente
                    MessageBox.Show(Errores.CodigoIncorrecto, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                }
            }
            else
            {
                //el codigo caducó
                MessageBox.Show(Errores.CodigoExpirado, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public void CargarCache(string usuario)
        {
            DataTable dt = login.Buscar(usuario);
            UserCache.Clear();

            UserCache.id = (int)dt.Rows[0][0];
            UserCache.usuario = (string)dt.Rows[0][1];
            UserCache.password = (string)dt.Rows[0][2];
            UserCache.alta = (DateTime)dt.Rows[0][3];
            UserCache.baja = (DateTime)dt.Rows[0][4];
            UserCache.cambiaCada = (int)dt.Rows[0][5];
            UserCache.ultimoCambio = (DateTime)dt.Rows[0][6];
            UserCache.bloqueo = (DateTime)dt.Rows[0][7];
            UserCache.digito = (string)dt.Rows[0][9];
            UserCache.intentos = (int)dt.Rows[0][10];
            UserCache.nuevo = (bool)dt.Rows[0][13];
            UserCache.idPerfil = (int)dt.Rows[0][14];
        }

        public DateTime GetHoraDesbloqueo()
        {
            try
            {
                horaBloqueo = Convert.ToDateTime(UserCache.bloqueo);
                return horaBloqueo.AddMinutes(ConfigCache.LapsoBloqueo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void valIntentos()
        {
            if (UserCache.baja == ConfigCache.FechaDefecto)
            {
                CN_LogicaLogin logicaLogin = new CN_LogicaLogin();

                if (UserCache.intentos > 0 && UserCache.bloqueo == ConfigCache.FechaDefecto)
                {
                    try
                    {
                        logicaLogin.RestarIntento();
                    }
                    catch { }
                }
                else if (UserCache.intentos <= 0 && UserCache.bloqueo == ConfigCache.FechaDefecto)
                {
                    logicaLogin.BloqueoUser(UserCache.id, System.DateTime.Now);
                    CN_Bitacora.AltaBitacora($"Demasiados intentos", "Bloqueo", "frmLogin");
                    logicaLogin.CargarCache(UserCache.usuario);
                }
                else
                {
                    MensajeError = Errores.UsrReactivado;
                    reactivar(); // Chekea si ya paso el lapso de bloqueo.
                    CN_Bitacora.AltaBitacora($"Usuario reactivado", "Reactivación", "frmLogin");
                }
            }
        }
        // CHEKEA SI SE DEBE O NO DESBLOQUEAR EL USUARIO.
        private void reactivar()
        {
            CN_LogicaLogin logicaLogin = new CN_LogicaLogin();
            horaBloqueo = Convert.ToDateTime(UserCache.bloqueo);

            if (DateTime.Now > horaBloqueo.AddMinutes(ConfigCache.LapsoBloqueo) && UserCache.bloqueo != ConfigCache.FechaDefecto) // Si ya paso el tiempo de bloqueo;
            {
                logicaLogin.BloqueoUser(UserCache.id, ConfigCache.FechaDefecto);
                logicaLogin.RestaurarIntentosUser();
            }
        }
        // VALIDACION FINAL DE USUARIO Y CONTRASEÑA
        private bool ValUsr(string usuario, string password)
        {
            bool pswVal = false, pswDigVal = false, bloqVal = false, bajaVal = false;

            string usrForm = usuario;
            string usrBd = Seguridad.DesEncriptar(UserCache.usuario);

            string pswForm = Seguridad.Hash(Convert.ToString(usrBd + password));
            string pswBd = UserCache.password;

            // Se hashea el digito con solo la password (reveer)
            string digitoForm = Seguridad.Hash(Seguridad.DigVerif(Seguridad.Hash(password)).ToString());
            string digitoBd = UserCache.digito;

            MensajeError = "";
            if (UserCache.baja == ConfigCache.FechaDefecto)
            {
                bajaVal = true;

                if (string.Equals(usrForm, usrBd))
                {

                    if (string.Equals(pswBd.Trim(), pswForm))
                    {
                        pswVal = true;

                        if (string.Equals(digitoBd.Trim(), digitoForm))
                        {
                            pswDigVal = true;
                        }
                        // El mensaje de error es provisorio porque hay que bloquear el usuario
                        else
                        {
                            Properties.Terminal.Default.Estado_terminal = false;
                            Properties.Terminal.Default.Save();
                            CN_Bitacora.AltaBitacora($"LA BD FUE MODIFICADA DE FORMA EXTERNA", "BLOQUEO DE TERMINAL", "frmLogin", "ERROR");
                            MessageBox.Show(Errores.ModNoAutorizada, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    else
                    {
                        MensajeError = Errores.UsrPswIncorrecto;
                        valIntentos();
                    }
                }

                if (UserCache.bloqueo == ConfigCache.FechaDefecto)
                {
                    bloqVal = true;
                }
                else
                {
                    MensajeError = Errores.UsrBloqueado;
                    valIntentos();
                }
            }
            else MensajeError = Errores.UsrDadoDeBaja;

            return pswVal && pswDigVal && bloqVal && bajaVal;
        }
        // VALIDA SI HAY DATOS INGRESADOS
        private static bool camposVacios(string usr, string psw)
        {
            if (string.IsNullOrWhiteSpace(usr) | string.IsNullOrWhiteSpace(psw)) return false;
            else return true;
        }
        public static void Terminal()
        {
            if (Properties.Terminal.Default.Estado_terminal == false)
            {
                MessageBox.Show(Errores.TerminalBloqueada, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void RestoreTerminal()
        {
            Properties.Terminal.Default.Reset();
            Properties.Terminal.Default.Save();
        }
    }
}
