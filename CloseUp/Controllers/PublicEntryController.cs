using CloseUp.Data;
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
        
        public ActionResult Index(PublicOrPrivate publicPost) 
        {

            var service = new PublicPostServices();

            var model = service.GetPublicPosts(publicPost);

            return View(model);
        }
    }
}