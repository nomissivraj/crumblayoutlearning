using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimonJarvis.Models.ViewModels;

namespace SimonJarvis.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index(FormViewModel model)
        {

            FormViewModel m = new FormViewModel();
            m.Name = model.Name;
            m.Date = model.Date;

            return View();
        }
    }
}