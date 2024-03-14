using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class CN_AsignarCapacitaciones
    {
        public object IdPersona { get; set; }
        public object IdArea { get; set; }
        public DataTable Capacitaciones { get; set; }

        CD_AccesoBD acceso = new CD_AccesoBD();
        CD_AsignarCapacitaciones cd_asignar = new CD_AsignarCapacitaciones();
        public DataTable ConsultarAreas()
        {
            DataTable dt = acceso.ConsultaAreas();
            DataRow dr = dt.NewRow();
            dt.Rows.Add(new Object[] { -1, "Todas" });
            return dt;
        }
        public DataTable ConsultarCapacitaciones(bool dePersona = false)
        {
            DataTable dt;

            if (dePersona)
            {
                cd_asignar.IdPersona = (int)IdPersona;
                dt = cd_asignar.ConsultarCapacitacionesPersona();
            }
            else
            {
                cd_asignar.IdArea = (int)IdArea;
                dt = cd_asignar.ConsultarCapacitacionesLst();
            }

            for (int i = 0, len = dt.Rows.Count; i < len; i++)
            {
                if (dt.Rows[i][1].ToString().Contains("))0(("))
                {
                    dt.Columns[1].ReadOnly = false;
                    dt.Rows[i][1] = dt.Rows[i]["capacitacion"].ToString().Replace("))0((", $"({Niveles.cmbNivel0})");
                }
                if (dt.Rows[i][1].ToString().Contains("))1(("))
                {
                    dt.Columns[1].ReadOnly = false;
                    dt.Rows[i][1] = dt.Rows[i]["capacitacion"].ToString().Replace("))1((", $"({Niveles.cmbNivel1})");
                }
                if (dt.Rows[i][1].ToString().Contains("))2(("))
                {
                    dt.Columns[1].ReadOnly = false;
                    dt.Rows[i][1] = dt.Rows[i]["capacitacion"].ToString().Replace("))2((", $"({Niveles.cmbNivel2})");
                }
            }
            return dt;
        }
        public DataTable ConsultarPersonal(string cuit, string nombre, string apellido, object area)
        {
            return cd_asignar.ConsultarPersonal(cuit, nombre, apellido, (int)area);
        }
        public void AsignarCapacitaciones()
        {
            cd_asignar.IdPersona = (int)IdPersona;
            LimpiarCapacitaciones();
            for (int i = 0; i < Capacitaciones.Rows.Count; i++)
            {
                cd_asignar.IdCapacitacion = (int)Capacitaciones.Rows[i][0];
                cd_asignar.AsignarCapacitaciones();
            }
        }
        private void LimpiarCapacitaciones()
        {
            DataTable _capsBD = cd_asignar.ConsultarCapacitacionesPersona();
            List<int> capsBD = new List<int>();
            List<int> capsMem = new List<int>();

            for (int i = 0, len = _capsBD.Rows.Count; i < len; i++)
            {
                capsBD.Add((int)_capsBD.Rows[i][0]);
            }
            for (int i = 0, len = Capacitaciones.Rows.Count; i < len; i++)
            {
                capsMem.Add((int)Capacitaciones.Rows[i][0]);
            }

            int[] caps = capsBD.Except(capsMem).ToArray();
            foreach (int idCap in caps)
            {
                cd_asignar.IdCapacitacion = idCap;
                cd_asignar.BorrarCapacitacionPersona();
            }
        }
    }
}
