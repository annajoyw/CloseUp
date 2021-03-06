using CloseUp.Data;
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

        public ActionResult ResourceByTag(Tag tag)
        {
            var service = new ResourceServices();
            var model = service.GetResourcesByTag(tag);
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
                TempData["SaveResult"] = "Your resource was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Resource could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = new ResourceServices();

            var model = service.GetResourceById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new ResourceServices();

            var detail = service.GetResourceById(id);
            var model =
                new ResourceEdit
                {
                    ResourceId = detail.ResourceId,
                    ResourceInfo = detail.ResourceInfo,
                    URL = detail.URL
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, ResourceEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if(model.ResourceId != id)
            {
                ModelState.AddModelError("", "Sorry, looks like we didn't find a Resource with that Id.");
                return View(model);
            }

            var service = new ResourceServices();

            if (service.UpdateResource(model))
            {
                TempData["SaveResult"] = "Your resource has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Resource could not be updated.");
            return View(model);
        }


        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new ResourceServices();

            var model = service.GetResourceById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteResource(int id)
        {
            var service = new ResourceServices();

            if (service.DeleteResource(id))
            {
                TempData["SaveResult"] = "Resource has been deleted.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your entry could not be deleted.");
            return View();

        }


    }
}