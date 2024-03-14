using System;
using System.Data;
using AccesoDatos;
using Comun;
using System.Windows.Forms;
using LogicaNegocio.Lenguajes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LogicaNegocio
{
    public class CN_CambiarPassword
    {
        CD_AccesoBD acceso = new CD_AccesoBD();
        public DataTable ObtenerTodasPregutasSeg()
        {
            return acceso.ConsultarTodasPregSeg();
        }
        public DataTable ObtenerPregutasUsuarios()
        {
            CN_CambiarPassword pass = new CN_CambiarPassword();
            int idPregunta;
            DataTable rtaUsuarios = pass.ObtenerRespuetasUsuarios(UserCache.id); //pasar el id por el userCache
            idPregunta = (int)rtaUsuarios.Rows[0][1];
            return acceso.Consulta1PgtaSeg(idPregunta);
            //return acceso.ConsultaPregSeg(id);
        }
        public DataTable ObtenerRespuetasUsuarios(int id)
        {
            return acceso.ConsultaRtaSeg(id);
        }
        public void insertarRta(int idUsuario, string rta, int idPregunta)
        {
            //user ya viene hasheado
            try
            {
                acceso.InsertarRespuestaSeg(idUsuario, rta, idPregunta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void insertarPass(string user, string pass) 
        {
            //user ya viene hasheado
            try 
            {
                string usrBd = Seguridad.DesEncriptar(UserCache.usuario);
                string psw = Seguridad.Hash(usrBd + pass);
                string dig = Seguridad.Hash(Seguridad.DigVerif(Seguridad.Hash(pass)).ToString());
                //el nueva es false porqe en el unico momento que va a ser true es cuando se crea el usuario.
                bool nueva = false;
                acceso.InsertarNuevaPass(user, psw, dig, nueva );
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool ValidarPass(bool esNuevo, bool allow, string contra1, string contra2, string respuesta, object idPregunta)
        {
            if (string.IsNullOrWhiteSpace(contra1) || string.IsNullOrWhiteSpace(contra2))
            {
                MessageBox.Show(Errores.CamposIncompletos, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (contra1 != contra2)
            {
                MessageBox.Show(Errores.PasNoIgual, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!allow)
            {
                MessageBox.Show(Errores.PasFaltaCriterio, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string dig = Seguridad.Hash(Seguridad.DigVerif(Seguridad.Hash(contra2)).ToString());
            string digBd = UserCache.digito.Trim();
            if (dig == digBd)
            {
                MessageBox.Show(Errores.PasRepetida, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            CN_CambiarPassword pass = new CN_CambiarPassword();

            if (!esNuevo)
            { 
                DataTable rtaUsuarios = pass.ObtenerRespuetasUsuarios(UserCache.id); //pasar el id por el userCache
                string respuestaBd = rtaUsuarios.Rows[0][3].ToString().Trim();
                if (respuestaBd != respuesta.Trim().ToUpper())
                {
                    MessageBox.Show(Errores.PasPregInvalida, Errores.Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if ((int?)idPregunta != null && allow)
            {
                pass.insertarPass(UserCache.usuario, contra2);
                CN_LogicaLogin login = new CN_LogicaLogin();
                login.CargarCache(UserCache.usuario);

                switch (esNuevo)
                {
                    default:
                        return true;
                    case true:
                        int id = (int)idPregunta;
                        string rta = respuesta.ToUpper();

                        // Se realiza el insert de las respuestas y preguntas.
                        pass.insertarRta(UserCache.id, rta, id);
                        return true;
                }
            }
            return false;
        }
    }
}
