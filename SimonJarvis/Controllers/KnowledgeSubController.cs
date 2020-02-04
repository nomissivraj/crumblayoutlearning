using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimonJarvis.Models;

namespace SimonJarvis.Controllers
{
    
    [RoutePrefix("Knowledge/KnowledgeSub")]
    public class KnowledgeSubController : Controller
    {
        // GET: KnowledgeSub
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("One")]
        public ActionResult One(int id = 0)
        {
            TestModel test = new TestModel();

            if (id != 0)
            {
                test.id = id;
                return View("One", test);
            } else
            {
                return View("One");
            }

            
        }

        [HttpGet]
        [Route("Two")]
        public ActionResult Two()
        {
            return View();
        }

        [HttpGet]
        [Route("Three")]
        public ActionResult Three()
        {
            return View();
        }
    }
}