using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace El_Almacen.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly ApiService _apiService;

        public ArticulosController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: ArticulosController
        public async Task<ActionResult> Index()
        {
            var model = await _apiService.ObtenerArticulosStockAsync();
            return View(model);
            
        }

        // GET: ArticulosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticulosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticulosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ArticulosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticulosController/Edit/5
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

        // GET: ArticulosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticulosController/Delete/5
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
