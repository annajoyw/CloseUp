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

        [HttpGet]
        
        public ActionResult Index() 
        {

            var service = new PublicPostServices();

            var model = service.GetPublicPosts();

            return View(model);
        }
    }
}