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

        //get create
        public ActionResult Create()
        {
                return View();
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

            service.CreateEntry(model);

            return RedirectToAction("Index");

        }
    }
}