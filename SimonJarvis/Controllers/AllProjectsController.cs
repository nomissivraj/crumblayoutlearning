using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimonJarvis.Models.ViewModels;
using PagedList;

namespace SimonJarvis.Controllers
{
    public class AllProjectsController : Controller
    {
        // GET: AllProjects
        public ActionResult Index()
        {

            return View();
        }
        
    }
}