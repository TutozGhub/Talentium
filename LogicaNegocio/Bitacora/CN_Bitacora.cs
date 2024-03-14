using AccesoDatos.Bitacora;
using Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Bitacora
{
    public static class CN_Bitacora
    {
        public static void AltaBitacora(string mensaje, string accion, string lugar,string tipo = "Información")
        {
            CD_Bitacora bitacora = new CD_Bitacora();

            bitacora.tipo = tipo;
            bitacora.idUsuario = UserCache.id;
            bitacora.mensaje = mensaje;
            bitacora.accion = accion;
            bitacora.lugar = lugar;
            bitacora.AltaBitacora();
        }
        public static DataTable ConsultarBitacora()
        {
            CD_Bitacora bitacora = new CD_Bitacora();

            DataTable dt = bitacora.ConsultarBitacora();
            for (int i = 0, len = dt.Rows.Count; i < len; i++)
            {
                if (dt.Rows[i][2] != null)
                {
                    dt.Rows[i][2] = Seguridad.DesEncriptar(dt.Rows[i][2].ToString());
                }
            }
            return dt;
        }
    }

}
