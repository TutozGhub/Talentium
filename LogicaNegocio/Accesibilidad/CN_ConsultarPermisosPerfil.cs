using AccesoDatos;
using AccesoDatos.Accesibilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Accesibilidad
{
    public class CN_ConsultarPermisosPerfil
    {
        public DataTable ConsultarPermisosPerfil(int id_perfil)
        {
            CD_ConsultarPermisosPerfil cpp = new CD_ConsultarPermisosPerfil();
            return cpp.ConsultarPermisosPerfil(id_perfil);
        }
    }
}
