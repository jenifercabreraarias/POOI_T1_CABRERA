using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POOI_T1_CABRERA.Models
{
    public class Empleado
    {
        private string idEmpleado;
        private string nomapeEmpleado;
        private string categoriaEmpleado;
        private int nHijos;
        private string tipoContrato;

        public Empleado()
        {
        }
        public Empleado(string idEmpleado, string nomapeEmpleado, string categoriaEmpleado, int nHijos, string tipoContrato)
        {
            this.idEmpleado = idEmpleado;
            this.nomapeEmpleado = nomapeEmpleado;
            this.categoriaEmpleado = categoriaEmpleado;
            this.nHijos = nHijos;
            this.tipoContrato = tipoContrato;
        }

        public string IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        public string NomapeEmpleado
        {
            get { return nomapeEmpleado; }
            set { nomapeEmpleado = value; }
        }

        public string CategoriaEmpleado
        {
            get { return categoriaEmpleado; }
            set { categoriaEmpleado = value; }
        }

        public int NHijos
        {
            get { return nHijos; }
            set { nHijos = value; }
        }

        public string TipoContrato
        {
            get { return tipoContrato; }
            set { tipoContrato = value; }
        }
        public double SueldoBasico()
        {
            double sueldo;

            if (categoriaEmpleado == "E1")
            {
                sueldo = 5500;
            }
            else if (categoriaEmpleado == "E2")
            {
                sueldo = 2500;
            }
            else if (categoriaEmpleado == "E3")
            {
                sueldo = 2200;
            }
            else
            {
                sueldo = 1700;
            }

            return sueldo;
        }
        public double Escolaridad()
        {
            return nHijos * 108;
        }

        public virtual double Bonificacion()
        {
            double bonificacion = 0;

            if (tipoContrato == "Indefinido")
            {
                bonificacion = SueldoBasico() * 0.15;
            }
            else if (tipoContrato == "Contratado")
            {
                bonificacion = SueldoBasico() * 0.10;
            }

            return bonificacion;
        }

        public virtual double MontoAPagar()
        {
            return SueldoBasico() + Escolaridad() + Bonificacion();
        }
    }

}