using Microsoft.AspNetCore.Mvc;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult OlvidarContrasena()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            return View();
        }

        public IActionResult BuscarUsuario()
        {
            return View();
        }

        public IActionResult EliminarUsuario()
        {
            return View();
        }

        public IActionResult ModificarUsuario()
        {
            return View();
        }

        public IActionResult Reportes()
        {
            return View();
        }
    }

    public class CoordinadorController : Controller
    {
        public IActionResult BuscarCoordinador()
        {
            return View();
        }

        public IActionResult ProgramarAsignacion()
        {
            return View();
        }

        public IActionResult Homologacion()
        {
            return View();
        }

        public IActionResult Entrevistas()
        {
            return View();
        }

        public IActionResult CooReportes()
        {
            return View();
        }
    }

    public class EstudianteController : Controller
    {
        public IActionResult Actualizar()
        {
            return View();
        }

        public IActionResult Pagos()
        {
            return View();
        }
    }
}