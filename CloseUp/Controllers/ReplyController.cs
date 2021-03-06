using CloseUp.Data;
using CloseUp.Models;
using CloseUp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloseUp.Controllers
{
    public class ReplyController : Controller
    {
     

        [HttpGet]
        public ActionResult PublicJournalEntries(PublicOrPrivate publicPost)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReplyServices(userId);

            var model = service.GetPublicPosts(publicPost);

            return View(model);
        }
        //get create
        public ActionResult Create(int id)
        {
            var model =
                new ReplyCreate
                {
                    JournalEntryId = id
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReplyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReplyServices(userId);

            if (service.CreateReply(model))
            {
                TempData["SaveResult"] = "Your reply has been saved.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Resource could not be created.");
            return View(model);
        }

        public ActionResult ViewEntryReplies(int journalEntryId)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReplyServices(userId);

            var model = service.GetEntryReplies(journalEntryId);

            return View(model);
        }


        //ID HERE DOES NOT CAPTURE VALUE, (BECAUSE VALUE IS IN OTHER CONTROLLER POSSIBLY?)
        public ActionResult Details(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReplyServices(userId);
            var model = service.GetEntryById(id);

            return View(model);
        }
    }
}