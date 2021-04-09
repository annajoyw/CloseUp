using CloseUp.Models;
using System;
using System.Collections.Generic;
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
            return View();
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}