using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class InterviewsController : MvcController
    {
        // Service injections:
        private readonly IService<Interview, InterviewModel> _interviewService;
        private readonly IService<Agent, AgentModel> _agentService;
        private readonly IService<Customer, CustomerModel> _customerService;
        private readonly IService<Sale, SaleModel> _saleService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public InterviewsController(
			IService<Interview, InterviewModel> interviewService
            , IService<Agent, AgentModel> agentService
            , IService<Customer, CustomerModel> customerService
            , IService<Sale, SaleModel> saleService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _interviewService = interviewService;
            _agentService = agentService;
            _customerService = customerService;
            _saleService = saleService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["AgentId"] = new SelectList(_agentService.Query().ToList(), "Record.Id", "Name");
            ViewData["CustomerId"] = new SelectList(_customerService.Query().ToList(), "Record.Id", "Name");
            ViewData["SaleId"] = new SelectList(_saleService.Query().ToList(), "Record.Id", "Name");
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Interviews
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _interviewService.Query().ToList();
            return View(list);
        }

        // GET: Interviews/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _interviewService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // GET: Interviews/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Interviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InterviewModel interview)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _interviewService.Create(interview.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = interview.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(interview);
        }

        // GET: Interviews/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _interviewService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Interviews/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InterviewModel interview)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _interviewService.Update(interview.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = interview.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(interview);
        }

        // GET: Interviews/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _interviewService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Interviews/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _interviewService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
