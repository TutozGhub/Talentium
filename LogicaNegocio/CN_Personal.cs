using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class CN_Personal
    {
        CD_AccesoBD accesoDatos = new CD_AccesoBD();
        public void AltaPersonal (string nombres, string apellidos, string dni, string cuil,
            string calle, string nro, string dpto, string piso, int id_localidad, int id_puesto, string email,
            int id_baja, int id_nacionalidad, int id_genero, DateTime fecha_nacimiento, int id_estado_civil,
            int hijos, string foto_perfil, int id_convenio, int id_tipo_doc)
        {
            try
            {
                accesoDatos.InsertarPersonal(nombres, apellidos, dni, cuil,
                    calle, nro, dpto, piso, id_localidad, id_puesto, email, id_baja, id_nacionalidad,
                    id_genero, fecha_nacimiento, id_estado_civil, hijos, foto_perfil, id_convenio, id_tipo_doc);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
