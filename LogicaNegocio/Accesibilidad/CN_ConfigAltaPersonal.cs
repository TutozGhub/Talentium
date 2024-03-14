using AccesoDatos.Accesibilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Accesibilidad
{
    public class CN_ConfigAltaPersonal
    {
        CD_ConfigAltaPersonal configAltaPersonal = new CD_ConfigAltaPersonal();

        /////////////////// Tipo de documento ///////////////////
        public bool ValidarTipoDoc(string tipoDoc)
        {
            if (!configAltaPersonal.ConsultarTipoDocRepetido(tipoDoc))
            {
                configAltaPersonal.InsertarTipoDoc(tipoDoc);
                return false;
            }
            return true;
        }
        public DataTable ObtenerTipoDoc()
        {
            return configAltaPersonal.ObtenerTipoDoc();
        }
        public bool ModificarTipoDoc(int id_tipo_doc, string tipo_doc)
        {
            if (!configAltaPersonal.ConsultarTipoDocRepetido(tipo_doc))
            {
                configAltaPersonal.ModificarTipoDoc(id_tipo_doc, tipo_doc);
                return false;
            }
            return true;
        }
        public bool TipoDocAsociadoAPersona(int id_tipo_doc)
        {
            return configAltaPersonal.ConsultarTipoDocConPersona(id_tipo_doc);
        }
        public bool EliminarTipoDoc(int id_tipo_doc)
        {
            return configAltaPersonal.EliminarTipoDoc(id_tipo_doc);
        }

        /////////////////// Tipo de teléfono ///////////////////
        public bool ValidarTipoTel(string tipoTel)
        {
            if (!configAltaPersonal.ConsultarTipoTelRepetido(tipoTel))
            {
                configAltaPersonal.InsertarTipoTel(tipoTel);
                return false;
            }
            return true;
        }
        public DataTable ObtenerTipoTel()
        {
            return configAltaPersonal.ObtenerTipoTel();
        }
        public bool ModificarTipoTel(int id_tipo_tel, string tipo_tel)
        {
            if (!configAltaPersonal.ConsultarTipoTelRepetido(tipo_tel))
            {
                configAltaPersonal.ModificarTipoTel(id_tipo_tel, tipo_tel);
                return false;
            }
            return true;
        }
        public bool TipoTelAsociadoAPersona(int id_tipo_tel)
        {
            return configAltaPersonal.ConsultarTipoTelConPersona(id_tipo_tel);
        }
        public bool EliminarTipoTel(int id_tipo_tel)
        {
            return configAltaPersonal.EliminarTipoTel(id_tipo_tel);
        }

        /////////////////// Nacionalidad ///////////////////
        public bool ValidarNacionalidad(string nacionalidad)
        {
            if (!configAltaPersonal.ConsultarNacionalidadRepetida(nacionalidad))
            {
                configAltaPersonal.InsertarNacionalidad(nacionalidad);
                return false;
            }
            return true;
        }
        public DataTable ObtenerNacionalidad()
        {
            return configAltaPersonal.ObtenerNacionalidad();
        }
        public bool ModificarNacionalidad(int id_nacionalidad, string nacionalidad)
        {
            if (!configAltaPersonal.ConsultarNacionalidadRepetida(nacionalidad))
            {
                configAltaPersonal.ModificarNacionalidad(id_nacionalidad, nacionalidad);
                return false;
            }
            return true;
        }
        public bool NacionalidadAsociadaAPersona(int id_nacionalidad)
        {
            return configAltaPersonal.ConsultarNacionalidadConPersona(id_nacionalidad);
        }
        public bool EliminarNacionalidad(int id_nacionalidad)
        {
            return configAltaPersonal.EliminarNacionalidad(id_nacionalidad);
        }

        /////////////////// Género ///////////////////
        public bool ValidarGenero(string genero)
        {
            if (!configAltaPersonal.ConsultarGeneroRepetido(genero))
            {
                configAltaPersonal.InsertarGenero(genero);
                return false;
            }
            return true;
        }
        public DataTable ObtenerGenero()
        {
            return configAltaPersonal.ObtenerGenero();
        }
        public bool ModificarGenero(int id_genero, string genero)
        {
            if (!configAltaPersonal.ConsultarGeneroRepetido(genero))
            {
                configAltaPersonal.ModificarGenero(id_genero, genero);
                return false;
            }
            return true;
        }
        public bool GeneroAsociadoAPersona(int id_genero)
        {
            return configAltaPersonal.ConsultarGeneroConPersona(id_genero);
        }
        public bool EliminarGenero(int id_genero)
        {
            return configAltaPersonal.EliminarGenero(id_genero);
        }
        /////////////////// Idioma ///////////////////
        public bool ValidarIdioma(string idioma)
        {
            if (!configAltaPersonal.ConsultarIdiomaRepetido(idioma))
            {
                configAltaPersonal.InsertarIdioma(idioma);
                return false;
            }
            return true;
        }
        public DataTable ObtenerIdioma()
        {
            return configAltaPersonal.ObtenerIdioma();
        }
        public bool ModificarIdioma(int id_idioma, string idioma)
        {
            if (!configAltaPersonal.ConsultarIdiomaRepetido(idioma))
            {
                configAltaPersonal.ModificarIdioma(id_idioma, idioma);
                return false;
            }
            return true;
        }
        public bool IdiomaAsociadoAPersona(int id_idioma)
        {
            return configAltaPersonal.ConsultarIdiomaConPersona(id_idioma);
        }
        public bool EliminarIdioma(int id_idioma)
        {
            return configAltaPersonal.EliminarIdioma(id_idioma);
        }

        /////////////////// Area ///////////////////
        public bool ValidarArea(string area)
        {
            if (!configAltaPersonal.ConsultarAreaRepetido(area))
            {
                configAltaPersonal.InsertarArea(area);
                return false;
            }
            return true;
        }
        public DataTable ObtenerArea()
        {
            return configAltaPersonal.ObtenerArea();
        }
        public bool ModificarArea(int id_area, string area)
        {
            if (!configAltaPersonal.ConsultarAreaRepetido(area))
            {
                configAltaPersonal.ModificarArea(id_area, area);
                return false;
            }
            return true;
        }
        public bool AreaAsociadoAPersona(int id_area)
        {
            return configAltaPersonal.ConsultarAreaConPersona(id_area);
        }
        public bool EliminarArea(int id_area)
        {
            return configAltaPersonal.EliminarArea(id_area);
        }
        /////////////////// Puesto ///////////////////
        public bool ValidarPuesto(string puesto)
        {
            if (!configAltaPersonal.ConsultarPuestoRepetido(puesto))
            {
                configAltaPersonal.InsertarPuesto(puesto);
                return false;
            }
            return true;
        }
        public DataTable ObtenerPuesto()
        {
            return configAltaPersonal.ObtenerPuesto();
        }
        public bool ModificarPuesto(int id_puesto, string puesto)
        {
            if (!configAltaPersonal.ConsultarPuestoRepetido(puesto))
            {
                configAltaPersonal.ModificarPuesto(id_puesto, puesto);
                return false;
            }
            return true;
        }
        public bool PuestoAsociadoAPersona(int id_puesto)
        {
            return configAltaPersonal.ConsultarPuestoConPersona(id_puesto);
        }
        public bool EliminarPuesto(int id_puesto)
        {
            return configAltaPersonal.EliminarPuesto(id_puesto);
        }
    }
}
