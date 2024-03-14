using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Accesibilidad;
using System.Data;

namespace LogicaNegocio.Accesibilidad
{
    public class CN_LogicaEntrevista
    {
        CD_Entrevista entrevistaDatos = new CD_Entrevista();
        public bool ValidarEntrevista(int instancia, string entrevista)
        {
            DataTable dt = entrevistaDatos.ConsultarEntrevistaRepetida(instancia, entrevista);
            if ((int)dt.Rows[0][0] == 0)
            {
                entrevistaDatos.InsertarEntrevista(instancia, entrevista);
                return false;
            }

            return true;
        }

        public DataTable ConsultarEntrevistas()
        {
            return entrevistaDatos.ConsultarEntrevistas();
        }
        public bool VerificarExistenciaEntrevista(int id_persona, int id_entrevista)
        {
            return entrevistaDatos.VerificarExistenciaEntrevista(id_persona, id_entrevista);
        }
        public bool ModificarEntrevista(int idRegistroSeleccionado, int etapa, string nuevaEntrevista)
        {
            DataTable dt = entrevistaDatos.ConsultarEntrevistaRepetidaMod(etapa, nuevaEntrevista, idRegistroSeleccionado);
            if ((int)dt.Rows[0][0] == 0)
            {
                entrevistaDatos.ModificarEntrevista(idRegistroSeleccionado, etapa, nuevaEntrevista);
                return false;
            }

            return true;
            //entrevistaDatos.ModificarEntrevista(idRegistroSeleccionado, etapa, nuevaEntrevista);
            //return true;
        }
        public bool EntrevistaAsociadaAPersona(int id_entrevista)
        {
            return entrevistaDatos.ConsultarEntrevistaConPersona(id_entrevista);
        }
        public bool EliminarEntrevista(int id_entrevista)
        {
            return entrevistaDatos.EliminarEntrevista(id_entrevista);
        }
        public int CantidadEntrevista()
        {
            return entrevistaDatos.ConsultarCantidadEntrevistas();
        }

    }
}
