using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class C_Asistencias
    {
        //filtros
        public int idAsistencia { get; set; }
        public int idPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; }
        public string Area { get; set; }

        public bool Periodo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Fecha_desde { get; set; }
        public DateTime Fecha_hasta { get; set; }
        public bool Justificada { get; set; }
        public int Id_motivo { get; set; }
        public string Otro_motivo { get; set; }
        public string Observaciones { get; set; }

        public bool Alta { get; set; }



    }
    public class Asistencia {

        public int idPersona { get; set; }
        public bool Periodo { get; set; }
        public DateTime Fecha { get; set; }/*
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }*/
        public bool Justificada { get; set; }
        public int idMotivo { get; set; }
        public string OtroMotivo { get; set; }
        public string Observaciones { get; set; }
    }
}