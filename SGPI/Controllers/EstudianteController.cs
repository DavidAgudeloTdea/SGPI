using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {
        SGPI_BDContext context = new SGPI_BDContext();
        public IActionResult Actualizar(int? Idusuario)
        {
            TblUsuario usuario = context.TblUsuarios.Find(Idusuario);
            if (usuario != null)
            {
                ViewBag.mensaje = "Tus datos fueron actualizados con exito";
                ViewBag.TblPrograma = context.TblProgramas.ToList();
                ViewBag.TblGenero = context.TblGeneros.ToList();
                ViewBag.TblTipoDocumento = context.TblTipoDocumentos.ToList();
                return View(usuario);
            }
            else
            {
                return Redirect("/Estudiante/Actualizar");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(TblUsuario usuario)
        {
            var usuarioActualizar = context.TblUsuarios.Where(consulta => consulta.Idusuario == usuario.Idusuario).FirstOrDefault();

            usuarioActualizar.Idprograma = usuario.Idprograma;
            usuarioActualizar.Idgenero = usuario.Idgenero;
            usuarioActualizar.Iddoc = usuario.Iddoc;
            usuarioActualizar.NumeroDocumento = usuario.NumeroDocumento;
            usuarioActualizar.Email = usuario.Email;
            usuarioActualizar.PrimerNombre = usuario.PrimerNombre;
            usuarioActualizar.SegundoNombre = usuario.SegundoNombre;
            usuarioActualizar.PrimerApellido = usuario.PrimerApellido;
            usuarioActualizar.SegundoApellido = usuario.SegundoApellido;
            context.Update(usuarioActualizar);
            context.SaveChanges();
            return Redirect("/Estudiante/Actualizar/?Idusuario=" + usuarioActualizar.Idusuario);
        }

        public IActionResult Pagos()
        {
            return View();
        }
    }
}
