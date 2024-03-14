using Comun;
using LogicaNegocio.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicaNegocio
{
    public class CN_LogicaLogout
    {
        private void limpiarCache()
        {
            UserCache.Clear();
            PermisosCache.Clear();
        }
        public void Logout(Form frm)
        {
            CN_Bitacora.AltaBitacora("Logout manual", "Logout", frm.Name);
            limpiarCache();
            frm.DialogResult = DialogResult.OK;
            frm.Dispose();
        }
        public void Logout(Form frm, bool porInactividad)
        {
            CN_Bitacora.AltaBitacora("Logout por inactividad", "Logout", frm.Name);
            limpiarCache();
            frm.DialogResult = DialogResult.OK;
            frm.Dispose();
        }
    }
}
