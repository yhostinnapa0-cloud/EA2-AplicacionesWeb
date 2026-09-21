using EcoStore.Entidades;
using EcoStore.Negocio.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoStore.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoService _service;
        private readonly ICategoriaService _categoriaService;
        private readonly ILogger<ProductosController> _logger;

        public ProductosController(
       IProductoService service,
       ICategoriaService categoriaService,
       ILogger<ProductosController> logger)
        {
            _service = service;
            _categoriaService = categoriaService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<Producto> productos = await _service.ListarAsync();
                return View(productos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar los productos.");
                return View(new List<Producto>());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            if (!PuedeGestionarProductos())
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Categorias = await _categoriaService.ListarAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Producto producto)
        {
            if (!PuedeGestionarProductos())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = await _categoriaService.ListarAsync();

                return View(producto);
            }

            try
            {
                await _service.CrearAsync(producto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar el producto.");

                ModelState.AddModelError(
                    "",
                    "No se pudo registrar el producto.");

                ViewBag.Categorias = await _categoriaService.ListarAsync();

                return View(producto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            if (!PuedeGestionarProductos())
            {
                return RedirectToAction("Index", "Login");
            }

            var producto = await _service.ObtenerPorIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }
            ViewBag.Categorias = await _categoriaService.ListarAsync();
            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Producto producto)
        {
            if (!PuedeGestionarProductos())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = await _categoriaService.ListarAsync();
                return View(producto);
            }

            try
            {
                await _service.EditarAsync(producto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el producto.");

                ModelState.AddModelError(
                    "",
                    "No se pudo actualizar el producto.");

                ViewBag.Categorias = await _categoriaService.ListarAsync();
                return View(producto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (!PuedeGestionarProductos())
            {
                return RedirectToAction("Index", "Login");
            }

            try
            {
                await _service.EliminarAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el producto.");

                return RedirectToAction(nameof(Index));
            }
        }

        private bool PuedeGestionarProductos()
        {
            var rol = HttpContext.Session.GetString("Rol");

            return rol == "Administrador" || rol == "Ventas";
        }
    }
}