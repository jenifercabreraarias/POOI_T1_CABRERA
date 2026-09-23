using POOI_T1_CABRERA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POOI_T1_CABRERA.Controllers
{
    public class EmpleadoController : Controller
    {
        private static List<Empleado> Planilla = new List<Empleado>
        {
            new Empleado("E001", "Perez Diaz, Juan",  "E1", 2, "Indefinido"),
            new Empleado("E002", "Lopez Ruiz, Maria", "E2", 1, "Contratado"),
            new Empleado("E003", "Garcia Soto, Luis", "E3", 0, "Indefinido"),
            new Empleado("E004", "Torres Vega, Ana",  "E4", 3, "Contratado")
        };

        public ActionResult RegistrarEmpleado()
        {
            CargarListasEmpleado();
            Empleado empleado = new Empleado();
            return View(empleado);
        }

        [HttpPost]
        public ActionResult RegistrarEmpleado(Empleado empleado)
        {
            CargarListasEmpleado();

            return View(empleado);
        }

        public ActionResult RegistrarAdministrativo()
        {
            CargarListasEmpleado();
            Administrativo administrativo = new Administrativo();
            return View(administrativo);
        }

        [HttpPost]
        public ActionResult RegistrarAdministrativo(Administrativo administrativo)
        {
            CargarListasEmpleado();
            return View(administrativo);
        }

        public ActionResult Index()
        {
            return View(Planilla);
        }

        public ActionResult Agregar()
        {
            CargarListasEmpleado();
            Empleado empleado = new Empleado();
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Agregar(Empleado empleado)
        {
            CargarListasEmpleado();

            bool existe = Planilla.Exists(e => e.IdEmpleado == empleado.IdEmpleado);

            if (existe)
            {
                ViewBag.Mensaje = "No se guardo: el idEmpleado '" + empleado.IdEmpleado + "' ya esta registrado.";
            }
            else
            {
                Planilla.Add(empleado);
                ViewBag.Mensaje = "Empleado guardado correctamente.";
            }

            return View(empleado);
        }

        private void CargarListasEmpleado()
        {
            ViewBag.Categorias = new SelectList(new[] { "E1", "E2", "E3", "Otros" });
            ViewBag.TiposContrato = new SelectList(new[] { "Indefinido", "Contratado" });
        }
    }
}
