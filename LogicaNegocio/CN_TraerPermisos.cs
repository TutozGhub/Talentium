using AccesoDatos;
using Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class CN_TraerPermisos
    {
        public void TraerPermisos()
        {
            CD_TraerPermisos tp = new CD_TraerPermisos();

            DataTable dt;

            if (UserCache.idPerfil != -1)
            {
                dt = tp.TraerPermisos();
            }
            else
            {
                dt = tp.TraerPermisos(UserCache.id);
            }

            PermisosCache pc = new PermisosCache();
            PermisosCache.Clear();
            for (int i = 0, len = dt.Rows.Count; i < len; i++)
            {
                pc.Id = (int)dt.Rows[i][0];
                pc.Permiso = dt.Rows[i][1].ToString();
                pc.addPermiso();
            }
        }
    }
}
