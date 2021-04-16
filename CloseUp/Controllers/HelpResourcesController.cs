using CloseUp.Models;
using CloseUp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloseUp.Controllers
{
    public class HelpResourcesController : Controller
    {
        // GET: HelpResources
        public ActionResult Index()
        {
            var service = new ResourceServices();
            var model = service.GetResources();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ResourceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new ResourceServices();

            if (service.CreateResource(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Resource could not be created.");
            return View(model);
        }
    }
}