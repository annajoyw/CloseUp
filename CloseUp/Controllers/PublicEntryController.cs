using CloseUp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloseUp.Controllers
{
    public class PublicEntryController : Controller
    {
        // GET: PublicEntry
        public ActionResult Index(bool isPublic)
        {
            var service = new PublicPostServices();

            var model = service.GetPublicPosts(isPublic);

            return View(model);
        }
    }
}