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
                ViewBag.TblPrograma = context.TblProgramas.ToList();
                ViewBag.TblGenero = context.TblGeneros.ToList();
                ViewBag.TblTipoDocumento = context.TblTipoDocumentos.ToList();
                return View(usuario);
            }
            else
            {
                return Redirect("/Estudiante/Actualizar/?Idusuario");
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
            ViewBag.estudiante = "Se ha modificado con exito";
            return Redirect("/Estudiante/Actualizar/?Idusuario=" + usuarioActualizar.Idusuario);
        }

        public IActionResult Pagos(int? Idusuario)
        {
            TblUsuario usuario = new TblUsuario();
            var usr = context.TblUsuarios.Where(consulta => consulta.Idusuario == Idusuario).FirstOrDefault();
            ViewBag.Idusuario = usr.Idusuario;
            
            return View();

        }
        [HttpPost]
        public IActionResult Pagos(int? Idusuario, TblPago usuario)
        {

            TblUsuario usr = context.TblUsuarios.Find(Idusuario);


            usuario.Estado = true;
            context.TblPagos.Add(usuario);
            context.SaveChanges();
            ViewBag.mensaje = "Pago enviado";

            TblEstudiante est = new TblEstudiante();
            est.Idusuario = usr.Idusuario;
            est.Idpago = usuario.IdPagos;
            est.Egresado = true;

            context.TblEstudiantes.Add(est);
            context.SaveChanges();


            return View();
        }
    }
}
