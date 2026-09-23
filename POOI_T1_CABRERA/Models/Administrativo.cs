using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POOI_T1_CABRERA.Models
{
        public class Administrativo : Empleado
        {
            private int anioIngreso;
            private bool postGrado;

            public Administrativo()
            {
            }

            public Administrativo(string idEmpleado, string nomapeEmpleado, string categoriaEmpleado, int nHijos, string tipoContrato, int anioIngreso, bool postGrado)
                : base(idEmpleado, nomapeEmpleado, categoriaEmpleado, nHijos, tipoContrato)
            {
                this.anioIngreso = anioIngreso;
                this.postGrado = postGrado;
            }

            public int AnioIngreso
            {
                get { return anioIngreso; }
                set { anioIngreso = value; }
            }

            public bool PostGrado
            {
                get { return postGrado; }
                set { postGrado = value; }
            }

            public double Incentivo()
            {
                double incentivo = 0;

                if (postGrado == true)
                {
                    incentivo = 500;
                }

                return incentivo;
            }

            public override double Bonificacion()
            {
                int aniosServicio = DateTime.Now.Year - anioIngreso;
                double bonificacion;

                if (aniosServicio < 5)
                {
                    bonificacion = 200;
                }
                else if (aniosServicio >= 5 && aniosServicio <= 10)
                {
                    bonificacion = 450;
                }
                else
                {
                    bonificacion = 300;
                }

                return bonificacion;
            }

            public override double MontoAPagar()
            {
                return SueldoBasico() + Bonificacion() + Escolaridad() + Incentivo();
            }
        }
    
}
