﻿using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
namespace SGPI.Controllers
{
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
}
