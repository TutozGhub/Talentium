using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using LogicaNegocio.Lenguajes;

namespace LogicaNegocio
{
    public class CN_Capacitaciones
    {
        CD_Capacitaciones capacitaciones = new CD_Capacitaciones();

        private object idCapacitacionesMod;
        private object idArea;
        private string capacitacion;
        private int idNivel;
        private int externaInterna;
        private string tiempoEstimado;
        private bool obligatorio;


        public object IdArea
        {
            get { return idArea; }
            set { idArea = value; }
        }
        public string Capacitacion
        {
            get { return capacitacion; }
            set { capacitacion = value; }
        }
        public int IdNivel
        {
            get { return idNivel; }
            set { idNivel = value; }
        }
        public int ExternaInterna
        {
            get { return externaInterna; }
            set { externaInterna = value; }
        }
        public string TiempoEstimado
        {
            get { return tiempoEstimado; }
            set { tiempoEstimado = value; }
        }

        public object IdCapacitacionesMod
        {
            get { return idCapacitacionesMod; }
            set { idCapacitacionesMod = value; }
        }
        public bool Obligatorio
        {
            get { return obligatorio; }
            set { obligatorio = value; }
        }



        public int revisarMotivo(object idMotivo)
        {
            return Convert.ToInt32(idMotivo);
        }
        public DataTable area()
        {
            DataTable dt = capacitaciones.Areas();
            DataRow dr = dt.NewRow();
            dr[0] = -1;
            dr[1] = Niveles.cmbAreaCap;
            dt.Rows.Add(dr);
            return dt;
        }


            public bool esCero(string numero)
        {
            bool esCero = false;
            for (int i = 0; i < numero.Length; i++)
            {
                if (numero[i] is '0' || numero[i] is ' ')
                {
                    esCero = true;
                }
                else
                {
                    return false;
                }
            }
            return esCero;
        }
        public void AltaCapacitaciones()
        {
            capacitaciones.IdArea = (int)idArea;
            capacitaciones.Capacitacion = capacitacion;
            capacitaciones.IdNivel = IdNivel;
            capacitaciones.ExternaInterna = externaInterna;
            capacitaciones.TiempoEstimado = Convert.ToInt32(tiempoEstimado.Replace(" ",""));
            capacitaciones.Obligatorio = obligatorio;
            capacitaciones.AltaCapacitaciones();
        }
        public DataTable ConsultaCapacitaciones()
        {
            try
            {
                DataTable cap = capacitaciones.ConsultaCapacitaciones();
                cap.Columns.Add("Nivel", typeof(string));
                cap.Columns.Add("Externo/Interno", typeof(string));
                foreach (DataRow dr in cap.Rows)
                {
                    switch ((int)dr.ItemArray[2])
                    {
                        case 0:
                            dr["Nivel"] = Niveles.cmbNivel0;
                            break;
                        case 1:
                            dr["Nivel"] = Niveles.cmbNivel1;
                            break;
                        case 2:
                            dr["Nivel"] = Niveles.cmbNivel2;
                            break;
                    }
                    switch ((int)dr.ItemArray[5])
                    {
                        case 0:
                            dr["Externo/Interno"] = Niveles.cmbExternaInterna0;
                            break;
                        case 1:
                            dr["Externo/Interno"] = Niveles.cmbExternaInterna1;
                            break;
                    }
                }
                return cap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;    
            }
            
        } 
        public DataTable filtrarCapacitaciones(string capacitacion)
        {
            try
            {
                DataTable cap = capacitaciones.FiltrarCapacitaciones(capacitacion);
                cap.Columns.Add("Nivel2", typeof(string));
                cap.Columns.Add("Externo/Interno2", typeof(string));
                foreach (DataRow dr in cap.Rows)
                {
                    switch ((int)dr.ItemArray[2])
                    {
                        case 0:
                            dr["Nivel2"] = Niveles.cmbNivel0;
                            break;
                        case 1:
                            dr["Nivel2"] = Niveles.cmbNivel1;
                            break;
                        case 2:
                            dr["Nivel2"] = Niveles.cmbNivel2;
                            break;
                    }
                    switch ((int)dr.ItemArray[5])
                    {
                        case 0:
                            dr["Externo/Interno2"] = Niveles.cmbExternaInterna0;
                            break;
                        case 1:
                            dr["Externo/Interno2"] = Niveles.cmbExternaInterna1;
                            break;
                    }
                }
                return cap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Errores.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;    
            }
            
        }
        public void ModificarCapacitaciones()
        {
            capacitaciones.IdArea = Convert.ToInt32(idArea);
            capacitaciones.IdCapacitaciones = Convert.ToInt32(idCapacitacionesMod);
            capacitaciones.IdNivel = idNivel;
            capacitaciones.Capacitacion = capacitacion.ToString();
            capacitaciones.ExternaInterna = Convert.ToInt32(externaInterna);
            capacitaciones.TiempoEstimado = Convert.ToInt32(tiempoEstimado.Replace(" ", ""));
            capacitaciones.Obligatorio = obligatorio;

            capacitaciones.ModificarCapacitaciones();

        }

        public void EliminarCapacitaciones()
        {
            capacitaciones.IdCapacitaciones = Convert.ToInt32(idCapacitacionesMod);

            capacitaciones.EliminarCapacitaciones();

        }
    }
    
}
