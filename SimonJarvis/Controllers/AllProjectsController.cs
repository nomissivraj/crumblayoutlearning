using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimonJarvis.Models.ViewModels;
using PagedList;
using SimonJarvis.DAL.Services;

namespace SimonJarvis.Controllers
{
    public class AllProjectsController : Controller
    {
        // GET: AllProjects
        public ActionResult Index()
        {
            Service s = new Service();
            var model = s.GetFilesFromJSON("~/Content/data/insight/files.js", "Page Name");

            return View(null, null, model.Files);
        }

        

        // GET: ProjectCards
        [HttpGet]
        public PartialViewResult ProjectCards(string sortOrder, string filter, string searchString, int? page)
        {

            //STUFF
            List<ProjectInfoCard> projects = new List<ProjectInfoCard>();

            ProjectInfoCard pIC = new ProjectInfoCard();
            pIC.id = 1;
            pIC.Name = "One";
            pIC.status = "active";
            projects.Add(pIC);

            pIC = new ProjectInfoCard();
            pIC.id = 2;
            pIC.Name = "Two";
            pIC.status = "active";
            projects.Add(pIC);

            pIC = new ProjectInfoCard();
            pIC.id = 3;
            pIC.Name = "Three";
            pIC.status = "inactive";
            projects.Add(pIC);

            pIC = new ProjectInfoCard();
            pIC.id = 4;
            pIC.Name = "Four";
            pIC.status = "active";
            projects.Add(pIC);

            //STUFF END
            switch (sortOrder)
            {
                case "Name":
                    projects = projects.OrderBy(x => x.Name).ToList();
                    break;
                case "Id":
                    projects = projects.OrderByDescending(x => x.id).ToList();
                    break;
                case "Status":
                    projects = projects.OrderBy(x => x.status).ToList();
                    break;
                default:
                    break;
            }


            if (searchString != null)
            {
                page = 1;
                switch (filter.ToLower())
                {
                    case "name":
                        projects = projects.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
                        break;
                    case "status":
                        projects = projects.Where(x => x.status.ToLower().Contains(searchString.ToLower())).ToList();
                        break;
                    default:
                        break;
                }


            }



            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return PartialView("_ProjectCards", projects.ToPagedList(pageNumber, pageSize));
        }
    }
}