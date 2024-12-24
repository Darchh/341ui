using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class AgentsController : MvcController
    {
        // Service injections:
        private readonly IService<Agent, AgentModel> _agentService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public AgentsController(
			IService<Agent, AgentModel> agentService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _agentService = agentService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Agents
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _agentService.Query().ToList();
            return View(list);
        }

        // GET: Agents/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _agentService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // GET: Agents/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Agents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AgentModel agent)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _agentService.Create(agent.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = agent.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(agent);
        }

        // GET: Agents/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _agentService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Agents/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AgentModel agent)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _agentService.Update(agent.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = agent.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(agent);
        }

        // GET: Agents/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _agentService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Agents/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _agentService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
