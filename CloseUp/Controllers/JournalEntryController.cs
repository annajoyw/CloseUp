using CloseUp.Data;
using CloseUp.Models;
using CloseUp.Services;
using Microsoft.AspNet.Identity;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloseUp.Controllers
{
    public class JournalEntryController : Controller
    {
        // GET: JournalEntry
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalEntryServices(userId);

            var model = service.GetEntries();

            return View(model);
        }

        //get publicposts
        public ActionResult PublicJournalEntries(PublicOrPrivate publicPost)
        {
            var service = new PublicPostServices();

            var model = service.GetPublicPosts(publicPost);

            return View(model);
        }


        //get create
        public ActionResult Create(int id)
        {
            var model =
                new JournalEntryCreate
                {
                    PromptId = id
                };
                return View(model);
        }

        //post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JournalEntryCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalEntryServices(userId);

            if (service.CreateEntry(model))
            {
                TempData["SaveResult"] = "Your entry was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Resource could not be created.");
            return View(model);
            //GetPrompt();
        }

        public ActionResult Details(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalEntryServices(userId);

            var model = service.GetEntryById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalEntryServices(userId);

            var detail = service.GetEntryById(id);

            var model =
                new JournalEntryEdit
                {
                    JournalEntryId = detail.JournalEntryId,
                    Content = detail.Content,
                    PhotoUrl = detail.PhotoUrl,
                    PublicOrPrivate = detail.PublicOrPrivate,
                    Tag = detail.Tag
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JournalEntryEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.JournalEntryId != id)
            {
                ModelState.AddModelError("", "Sorry, looks like we didn't find a Journal Entry with that Id.");
                return View(model);
            }
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalEntryServices(userId);

            if (service.UpdateEntry(model))
            {
                TempData["SaveResult"] = "Your journal entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your entry could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalEntryServices(userId);

            var model = service.GetEntryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalEntryServices(userId);

           if(service.DeleteEntry(id))
            {
                TempData["SaveResult"] = "Your journal entry was deleted.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your entry could not be deleted.");
            return View();
        }

        public PromptItem GetPrompt(int id)
        {
            var service = new PromptServices();

            var model = service.GetPromptById(id);

            return new PromptItem
            {
                Prompt = model.Prompt
            };
        }
    }
}