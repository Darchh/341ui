using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class DocumentsController : MvcController
    {
        // Service injections:
        private readonly IService<Document, DocumentModel> _documentService;
        private readonly IService<Residence, ResidenceModel> _residenceService;
        private readonly IService<Sale, SaleModel> _saleService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public DocumentsController(
			IService<Document, DocumentModel> documentService
            , IService<Residence, ResidenceModel> residenceService
            , IService<Sale, SaleModel> saleService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _documentService = documentService;
            _residenceService = residenceService;
            _saleService = saleService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["ResidenceId"] = new SelectList(_residenceService.Query().ToList(), "Record.Id", "Name");
            ViewData["SaleId"] = new SelectList(_saleService.Query().ToList(), "Record.Id", "Name");
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Documents
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _documentService.Query().ToList();
            return View(list);
        }

        // GET: Documents/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _documentService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Documents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DocumentModel document)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _documentService.Create(document.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = document.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(document);
        }

        // GET: Documents/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _documentService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Documents/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DocumentModel document)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _documentService.Update(document.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = document.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(document);
        }

        // GET: Documents/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _documentService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Documents/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _documentService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
