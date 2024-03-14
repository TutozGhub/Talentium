using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class Persona 

    {
        //ID

        public int id_persona { get; set; }
        public int id_informacion_academica1{ get; set; }
        public int id_informacion_academica2 { get; set; }
        public int id_informacion_academica3 { get; set; }
        public int id_informacion_laboral1{ get; set; }
        public int id_informacion_laboral2 { get; set; }
        public int id_informacion_laboral3 { get; set; }
        public int id_informacion_laboral4 { get; set; }

        //PERSONALES

        public string apellidos { get; set; }
        public string nombres { get; set; }
        public int id_tipo_doc { get; set; }
        public string nro_doc { get; set; }
        public string cuit_cuil { get; set; }
        public string calle { get; set; }
        public int nro { get; set; }
        public string dpto { get; set; }
        public string piso { get; set; }
        public int id_localidad { get; set; }
        public int id_partido { get; set; }
        public int id_provincia { get; set; }
     
        public int id_puesto { get; set; }
        public  int id_area { get; set; }
        public string email { get; set; }
        public int id_nacionalidad { get; set; }
        public int id_genero { get; set; } 
        public DateTime fecha_nacimiento { get; set; }
        public int id_estado_civil { get; set; } 
        public int hijos { get; set; }
        public int id_convenio { get; set; }

        public byte[] foto_perfil  { get; set; }

        public DateTime fecha_alta { get; set; }
        
        public string telefono { get; set; }
        public int id_tipo { get; set; }
        public string telefono_alternativo { get; set; }
        public int id_tipo_alternativo { get; set; }
        public string contacto   { get; set; }
        public bool candidato { get; set; }

        public bool id_baja { get; set; }

    }

}
