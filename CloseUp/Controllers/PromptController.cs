using CloseUp.Models;
using CloseUp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloseUp.Controllers
{
    public class PromptController : Controller
    {
        // GET: Prompt
        public ActionResult Index()
        {
            var service = new PromptServices();
            var model = service.GetPrompts();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PromptCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = new PromptServices();
            service.CreatePrompt(model);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = new PromptServices();

            var prompt = service.GetPromptById(id);

            var model =
                new PromptEdit
                {
                    PromptId = prompt.PromptId,
                    Prompt = prompt.Prompt
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, PromptEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.PromptId != id)
            {
                ModelState.AddModelError("", "Sorry, looks like we didn't find a Prompt with that Id.");
                return View(model);
            }
            var service = new PromptServices();

            if (service.UpdatePrompt(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Prompt could not be updated.");
            return View(model);
        }
    }
}