using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPI_BDContext context = new SGPI_BDContext();
        public IActionResult Login()
        {/*
            // Create
            TblUsuario usr = new TblUsuario();
            usr.PrimerNombre = "Mauricio";
            usr.SegundoNombre = String.Empty;
            usr.PrimerApellido = "Amariles";
            usr.SegundoApellido = "Camacho";
            usr.Email = "mauricio.amariles@tdea.edu.co";
            usr.Iddoc = 1;
            usr.Idgenero = 1;
            usr.Idrol = 1;
            usr.Idprograma = 1;
            usr.NumeroDocumento = "123456789";
            usr.VcPassword = "123456789";

            context.Add(usr);
            context.SaveChanges();
            
            // Query
            TblUsuario usuario = new TblUsuario();
            usuario = context.TblUsuarios
                .Single(b => b.NumeroDocumento == "123456789");

            List<TblUsuario> usuarios = new List<TblUsuario>();
            usuarios = context.TblUsuarios.ToList();
            
            // Update
            var usr = context.TblUsuarios
                .Where(cursor => cursor.Idusuario == 1)
                .FirstOrDefault();

            if(usr != null)
            {
                usr.SegundoNombre = "Diego";
                usr.SegundoApellido = "Camacho";

                context.TblUsuarios.Update(usr);
                context.SaveChanges();
            }
            

            */
            // Delete
            var usuarioEliminar = context.TblUsuarios
                .Where(cursor => cursor.Idusuario == 1)
                .FirstOrDefault();
            context.TblUsuarios.Remove(usuarioEliminar);
            return View();
        }

        [HttpPost]
        public IActionResult Login(TblUsuario user)
        {
            string numeroDoc = user.NumeroDocumento;
            string pass = user.VcPassword;

            var usuarioLogin = context.TblUsuarios
                .Where(consulta => consulta.NumeroDocumento == numeroDoc &&
                consulta.VcPassword == pass).FirstOrDefault();

            if (usuarioLogin !=null)
            {
                // Administrador
                if(usuarioLogin.Idrol == 1) {
                    CrearUsuario();
                    return View("CrearUsuario");
                }
                // Coordinador
                else if(usuarioLogin.Idrol == 2) {
                    return Redirect("Coordinador/BuscarCoordinador");
                }
                // Estudiante
                else if(usuarioLogin.Idrol == 3) {
                    return Redirect("Estudiante/Actualizar");
                }
                // No existe este rol
                else { }
            }
            else{
                return ViewBag.mensaje = "Usuario no existe" +
                    "o usuario y/o contraseña invalidad";
            }
            return View();
        }

        public IActionResult OlvidarContrasena()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            ViewBag.TblGenero = context.TblGeneros.ToList();
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