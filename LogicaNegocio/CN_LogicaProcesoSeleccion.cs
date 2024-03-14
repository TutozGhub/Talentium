using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.Accesibilidad;
using System.Data;

namespace LogicaNegocio
{
    public class CN_LogicaProcesoSeleccion
    {
        CD_Seleccion seleccionDatos = new CD_Seleccion();
        CD_AccesoBD accesoDatos = new CD_AccesoBD();
        CD_Entrevista entrevistaDatos = new CD_Entrevista();

        public DataTable ConsultarCandidato(int id_persona)
        {
            return seleccionDatos.ConsultarCandidato(id_persona);
        }
        public DataTable ObtenerCandidatosFiltros(string cuil)
        {
            return seleccionDatos.ConsultarCandidatoFiltros(cuil);
        }

        public DataTable ObtenerEmpleados(int id_area)
        {
            return accesoDatos.ConsultarPersonaConArea(id_area);
        }

        public DataTable ObtenerAreas()
        {
            return accesoDatos.ConsultaAreas();
        }
        public bool ModificarEtapa(int id_persona, int id_entrevista, DateTime fechaEntrevista, string entrevistador, string estado, string patologias)
        {
            return entrevistaDatos.ModificarEtapa(id_persona, id_entrevista, fechaEntrevista, entrevistador, estado, null);
        }
        public bool InsertarEtapa(int id_candidato, int id_entrevista, DateTime fecha_etapa, string entrevistador,
            string estado, string patologias)
        {
            return seleccionDatos.InsertarEtapa(id_candidato, id_entrevista, fecha_etapa, entrevistador, estado, patologias);
        }
        public DataTable ObtenerDatosEtapas(int id)
        {
            return seleccionDatos.ConsultarDatosEtapas(id);
        }
        public int ObtenerIDEntrevistas(string entrevista)
        {
            return entrevistaDatos.ObtenerIDEntrevistas(entrevista);
        }
        public int ObtenerIDPersona(string cuil)
        {
            return seleccionDatos.ConsultarIDporCuil(cuil);
        }
    }
}
