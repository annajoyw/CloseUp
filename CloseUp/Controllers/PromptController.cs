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
            if (service.CreatePrompt(model))
            {
                TempData["SaveResult"] = "Your entry was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Prompt could not be created.");
            return View(model);
        }


        public ActionResult Details(int id)
        {
            
            var service = new PromptServices();

            var model = service.GetPromptById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new PromptServices();

            var prompt = service.GetPromptById(id);

            var model =
                new PromptEdit
                {
                    PromptId = prompt.PromptId,
                    Category = prompt.Category,
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

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
         
            var service = new PromptServices();

            var model = service.GetPromptById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
 
            var service = new PromptServices();

            service.DeletePrompt(id);
            return RedirectToAction("Index");
        }

    }
}