using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace SimonJarvis.Controllers
{
    public class DownloadController : Controller
    {
        // GET: Download
        public ActionResult Index(string path, string file)
        {
            string fp = AppDomain.CurrentDomain.BaseDirectory + path;
            string ext = System.IO.Path.GetExtension(path);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fp);
            return File(fileBytes, MediaTypeNames.Application.Octet, file + ext);
        }
    }
}