using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Servidor2.Models;
using Servidor2.SessionHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor2.Controllers
{

    
    public class LoginController : Controller
    {
        SessionHelper s = new SessionHelper();

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (s.UsuarioLogueado(HttpContext.Session))
            {
                ViewBag.Mensaje = "Pareceria logueado en el index?!";
            }
            else
            {
                ViewBag.Mensaje = "Usted no es eduardo todavia!";
            }
            return View();
        }

        [TypeFilter(typeof(CustomAuthorizationFilterAttribute))]
        public IActionResult Index2(LoginModel modelo)
        {
            ViewBag.Mensaje = "Pareceria logueado";
            return View("Index");
        }

        [AllowAnonymous]

        public IActionResult Loguearse(LoginModel modelo)
        {
            //no valido nada, solo inicio para mostrar funcionamiento
                
                s.SetUsuario(HttpContext.Session, modelo.Usuario);
                ViewBag.Mensaje = "Hola " + s.GetUsuario(HttpContext.Session);
            
            return View("Index");
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
