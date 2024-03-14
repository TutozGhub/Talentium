using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Data;

namespace LogicaNegocio
{
    public class CN_LogicaEvaluacionDesempenio
    {
        CD_AccesoBD accesoDatos = new CD_AccesoBD();
        public DataTable ObtenerAreas()
        {
            return accesoDatos.ConsultaAreas();
        }

        public DataTable ObtenerPersonaConArea(int idArea)
        {
            return accesoDatos.ConsultarPersonaConArea(idArea);

        }
        public bool ValidarEvaluacion(string anio, string mes, int efectTareas, int puntualidad,
            int relSup, int disciplina, int desempEquipo, int id_persona, int id_area)
        {
            if (!accesoDatos.ConsultarEvaluacionRepetida(anio, mes, id_persona))
            {
                accesoDatos.InsertarEvaluacionDesempenio(anio, mes, efectTareas, puntualidad, relSup, disciplina, desempEquipo, 
                      id_persona, id_area);
                return false;
            }

            return true;
        }

        public DataTable ObtenerEvaluacion(string anio, int id_persona)
        {
            return accesoDatos.ConsultarEvaluacion(anio, id_persona);
        }

        public DataTable ObtenerEvaluacionPersona(int id_persona)
        {
            return accesoDatos.ConsultarEvaluacionSoloPersona(id_persona);
        }
    }
}
