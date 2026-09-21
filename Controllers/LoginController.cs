using EcoStore.Models;
using EcoStore.Negocio.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _service;

        public LoginController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuario = await _service.ValidarLoginAsync(
                model.Email,
                model.Password);

            if (usuario == null)
            {
                ModelState.AddModelError(
                    "",
                    "Correo o contraseña incorrectos.");

                return View(model);
            }

            HttpContext.Session.SetString(
                "Usuario",
                usuario.Nombre);

            HttpContext.Session.SetString(
                "Rol",
                usuario.Rol);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}