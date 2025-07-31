using El_Almacen.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiendas.Domain.Aggregates;

namespace El_Almacen.Controllers
{
    public class ArticulosVentasController : Controller
    {
        private readonly ApiService _apiService;
        public ArticulosVentasController(ApiService apiService)
        {
            _apiService = apiService;
        }
        // GET: ArticulosVentasController
        public async Task<ActionResult> Index()
        {
            var result = await _apiService.ObtenerArticulosVentasAsync();
            return View(result);
        }

        // GET: ArticulosVentasController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            IEnumerable<ArticulosVentas>? result = await  _apiService.ObtenerDetailsVentas(id);
            return View(result);
        }

        // GET: ArticulosVentasController/Create
        public ActionResult Create(long IdArticulo)
        {
            var ventas = new AgregarVentasDto();
            ventas.IdArticulo= IdArticulo;
            
            return View(ventas);
        }

        // POST: ArticulosVentasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AgregarVentasDto collection)
        {
            try
            {
                foreach (var item in collection.Tallas)
                {
                    var ventas = new ArticulosVentas(1, collection.IdArticulo, collection.PrecioVenta, "", item.Cantidad, 1, item.Talla);
                    await _apiService.AgregarVentas(ventas);
                }
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticulosVentasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticulosVentasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticulosVentasController/Delete/5
        public ActionResult Delete(int id)
        {
            
            var result = _apiService.Delete(id, "tiendas/ArticulosVentas/");
            return RedirectToAction(nameof(Index));
        }

        // POST: ArticulosVentasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
