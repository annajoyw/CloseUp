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

    }
}