using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace El_Almacen.Controllers
{
    public class ArticulosVentasController : Controller
    {
        // GET: ArticulosVentasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ArticulosVentasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticulosVentasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticulosVentasController/Create
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
            return View();
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
