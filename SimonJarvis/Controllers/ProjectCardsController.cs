using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimonJarvis.Models.ViewModels;
using PagedList;

namespace SimonJarvis.Controllers
{
    public class ProjectCardsController : Controller
    {
        // GET: ProjectCards
        [HttpGet]
        public PartialViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

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


            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return PartialView("_ProjectCards", projects.ToPagedList(pageNumber, pageSize));
        }
    }
}