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
            

            
            // Delete
            var usuarioEliminar = context.TblUsuarios
                .Where(cursor => cursor.Idusuario == 1)
                .FirstOrDefault();
            context.TblUsuarios.Remove(usuarioEliminar);
            */
            return View();
        }

        [HttpPost]
        public IActionResult Login(TblUsuario user)
        {
            string numeroDoc = user.NumeroDocumento;
            string pass = user.VcPassword;

            var usuarioLogin = context.TblUsuarios.Where(consulta => consulta.NumeroDocumento == numeroDoc &&
                consulta.VcPassword == pass).FirstOrDefault();

            if (usuarioLogin !=null)
            {
                // Administrador
                if(usuarioLogin.Idrol == 1) {
                    CrearUsuario();
                    return Redirect("/Administrador/CrearUsuario");
                }
                // Coordinador
                else if(usuarioLogin.Idrol == 2) {
                    CoordinadorController coordi = new CoordinadorController();
                    coordi.BuscarCoordinador();
                    return Redirect("/Coordinador/BuscarCoordinador");
                }
                // Estudiante
                else if(usuarioLogin.Idrol == 3) {
                    EstudianteController estudi = new EstudianteController();
                    estudi.Actualizar();
                    return Redirect("/Estudiante/Actualizar");
                }
            }
            else{
                ViewBag.mensaje = "Usuario no existe" +
                    "o usuario y/o contraseña invalido";
            }
            return View();
        }

        public IActionResult OlvidarContrasena()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            ViewBag.TblPrograma = context.TblProgramas.ToList();
            ViewBag.TblGenero = context.TblGeneros.ToList();
            ViewBag.TblRol = context.TblRols.ToList();
            ViewBag.TblTipoDocumento = context.TblTipoDocumentos.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CrearUsuario(TblUsuario usuario)
        {
            context.TblUsuarios.Add(usuario);
            context.SaveChanges();
            ViewBag.mensaje = "Usuario creado con exito";
            ViewBag.TblPrograma = context.TblProgramas.ToList();
            ViewBag.TblGenero = context.TblGeneros.ToList();
            ViewBag.TblRol = context.TblRols.ToList();
            ViewBag.TblTipoDocumento = context.TblTipoDocumentos.ToList();
            return View();
        }

        public IActionResult BuscarUsuario()
        {
            TblUsuario us = new TblUsuario();
            return View(us);
        }
        [HttpPost]
        public IActionResult BuscarUsuario(TblUsuario usuario)
        {
            String numeroDoc = usuario.NumeroDocumento;
            var user = context.TblUsuarios.Where(consulta => consulta.NumeroDocumento == numeroDoc).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return View();
            }
        }

        public IActionResult EliminarUsuario()
        {
            return View();
        }

        public IActionResult ModificarUsuario()
        {
            ViewBag.TblPrograma = context.TblProgramas.ToList();
            ViewBag.TblTipoDocumento = context.TblTipoDocumentos.ToList();
            ViewBag.TblGenero = context.TblGeneros.ToList();
            ViewBag.TblRol = context.TblRols.ToList();
            return View();
        }

        public IActionResult Reportes()
        {
            return View();
        }
    }
}