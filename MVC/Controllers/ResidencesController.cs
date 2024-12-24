using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class ResidencesController : MvcController
    {
        // Service injections:
        private readonly IService<Residence, ResidenceModel> _residenceService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public ResidencesController(
			IService<Residence, ResidenceModel> residenceService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _residenceService = residenceService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Residences
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _residenceService.Query().ToList();
            return View(list);
        }

        // GET: Residences/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _residenceService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // GET: Residences/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Residences/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResidenceModel residence)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _residenceService.Create(residence.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = residence.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(residence);
        }

        // GET: Residences/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _residenceService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Residences/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ResidenceModel residence)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _residenceService.Update(residence.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = residence.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(residence);
        }

        // GET: Residences/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _residenceService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Residences/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _residenceService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
