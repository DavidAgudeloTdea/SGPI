using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPI_BDContext context = new SGPI_BDContext();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(TblUsuario user)
        {
            string numeroDoc = user.NumeroDocumento;
            string pass = user.VcPassword;

            var usuarioLogin = context.TblUsuarios.Where(consulta => consulta.NumeroDocumento == numeroDoc &&
                consulta.VcPassword == pass).FirstOrDefault();

            if (usuarioLogin != null)
            {
                // Administrador
                if (usuarioLogin.Idrol == 1)
                {
                    CrearUsuario();
                    return Redirect("/Administrador/CrearUsuario");
                }
                // Coordinador
                else if (usuarioLogin.Idrol == 2)
                {
                    CoordinadorController coordi = new CoordinadorController();
                    coordi.BuscarCoordinador();
                    return Redirect("/Coordinador/BuscarCoordinador");
                }
                // Estudiante
                else if (usuarioLogin.Idrol == 3)
                {
                    EstudianteController estudi = new EstudianteController();
                    return Redirect("/Estudiante/Actualizar/?Idusuario="+usuarioLogin.Idusuario);
                }
            }
            else
            {
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

        public IActionResult EliminarUsuario(int? Idusuario)
        {
            TblUsuario user = context.TblUsuarios.Find(Idusuario);
            if(user != null)
            {
                context.Remove(user);
                context.SaveChanges();
            }
            return Redirect("/Administrador/BuscarUsuario");
        }

        public IActionResult ModificarUsuario(int? Idusuario)
        {
            TblUsuario usuario = context.TblUsuarios.Find(Idusuario);
            if (usuario != null)
            {
                ViewBag.mensaje = "Usuario Actualizado con exito";
                ViewBag.TblPrograma = context.TblProgramas.ToList();
                ViewBag.TblGenero = context.TblGeneros.ToList();
                ViewBag.TblRol = context.TblRols.ToList();
                ViewBag.TblTipoDocumento = context.TblTipoDocumentos.ToList();
                return View(usuario);
            }
            else
            {
                return Redirect("/Administrador/BuscarUsuario");
            }

        }

        [HttpPost]
        public IActionResult ModificarUsuario(TblUsuario usuario)
        {
            context.Update(usuario);
            context.SaveChanges();
            return Redirect("/Administrador/BuscarUsuario");
        }

        public IActionResult Reportes()
        {
            return View();
        }
    }
}