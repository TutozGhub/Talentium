using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class PermisosCache
    {
        #region Atributos
        private int id;
        private string permiso;
        private static List<PermisosCache> permisos = new List<PermisosCache>();
        #endregion
        #region Propiedades
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Permiso
        {
            get => permiso;
            set => permiso = value;
        }
        #endregion
        #region Metodos
        public static PermisosCache[] GetPermisos()
        {
            return permisos.ToArray();
        }
        public void addPermiso()
        {
            permisos.Add(new PermisosCache
            {
                id = id,
                permiso =permiso
            });
        }
        public static void Clear()
        {
            permisos.Clear();
        }
        #endregion
    }
}
