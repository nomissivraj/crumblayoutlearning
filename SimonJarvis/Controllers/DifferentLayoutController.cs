using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimonJarvis.Models;
using SimonJarvis.Models.ViewModels;
using SimonJarvis.DAL;

namespace SimonJarvis.Controllers
{
    public class DifferentLayoutController : Controller
    {
        private AppDBContext _context;
        public DifferentLayoutController()
        {
            _context = new AppDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: DifferentLayout
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form_Save(TestModel model)
        {
            if (!ModelState.IsValid)
                return null;

            if (model.id == 0)
            {
                _context.TestTable.Add(model);
            } else
            {
                var testEntity = _context.TestTable.Single(t => t.id == model.id);
                testEntity.Name = model.Name;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "DifferentLayout");
        }

        public ActionResult Form_Edit(int id)
        {
            TestViewModel model = new TestViewModel();
            var test = _context.TestTable.Where(x => x.id == id).FirstOrDefault();
            if (test == null)
                return HttpNotFound();

            model.id = test.id;
            model.Name = test.Name;


            _context.SaveChanges();

            return PartialView("_Form", model);
        }

        public ActionResult Form_Add()
        {

            var viewModel = new TestViewModel();
            
            
            return PartialView("_Form", viewModel);
        }
    }
}