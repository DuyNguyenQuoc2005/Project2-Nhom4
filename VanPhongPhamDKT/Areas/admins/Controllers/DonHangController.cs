using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VanPhongPhamDKT.Areas.admins.Controllers
{
    public class DonHangController : Controller
    {
        // GET: DonHangController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DonHangController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DonHangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonHangController/Create
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

        // GET: DonHangController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DonHangController/Edit/5
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

        // GET: DonHangController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DonHangController/Delete/5
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
