using AccesoDatos.Accesibilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Accesibilidad
{
    public class CN_LogicaPerfiles
    {
        CD_Perfiles cd_perfil = new CD_Perfiles();

        public void AltaPerfil(string nombrePerfil, string descripcion, int[] permisos)
        {
            try
            {
                int id_perfil = cd_perfil.InsertarPerfil(nombrePerfil, descripcion);

                foreach (int id_permiso in permisos)
                {
                    cd_perfil.InsertarNuevoPermisoPerfil(id_perfil, id_permiso);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BajaPerfil(int id_perfil)
        {
            cd_perfil.BajaPerfil(id_perfil);
        }
        public int ConsultarPerfil(int id_perfil)
        {
            int cantidadUsuarios = (int)cd_perfil.ConsultarPerfil(id_perfil).Rows[0][0];
            return cantidadUsuarios;
        }
        public void UpPerfil(int id_perfil, string nombrePerfil, string descripcion, int[] permisos)
        {
            try
            {
                cd_perfil.UpPerfil(id_perfil, nombrePerfil, descripcion);

                foreach (int id_permiso in permisos)
                {
                    cd_perfil.InsertarNuevoPermisoPerfil(id_perfil, id_permiso);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
