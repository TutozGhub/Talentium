using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public interface IPersona
    {
        void InsertarPersona(Persona insert);
        void EliminarPersona (Persona insert);
        void ConsultarPersona(Persona insert);


    }
}
