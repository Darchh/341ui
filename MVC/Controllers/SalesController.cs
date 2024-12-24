using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class SalesController : MvcController
    {
        // Service injections:
        private readonly IService<Sale, SaleModel> _saleService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public SalesController(
			IService<Sale, SaleModel> saleService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _saleService = saleService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Sales
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _saleService.Query().ToList();
            return View(list);
        }

        // GET: Sales/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _saleService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SaleModel sale)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _saleService.Create(sale.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = sale.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(sale);
        }

        // GET: Sales/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _saleService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Sales/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SaleModel sale)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _saleService.Update(sale.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = sale.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(sale);
        }

        // GET: Sales/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _saleService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Sales/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _saleService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
