using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SimonJarvis.Models;

namespace SimonJarvis.DAL.Services
{
    public class Service
    {
        //Returns List of objects From Json Array using path
        public List<FilesModel> GetFilesFromJSON(string path)
        {
            var _server = HttpContext.Current.Server;

            using (StreamReader sr = new StreamReader(_server.MapPath(path)))
            {
                string _jsonFromFile = sr.ReadToEnd();

                List<FilesModel> fml = new List<FilesModel>();

                fml = JsonConvert.DeserializeObject<List<FilesModel>>(_jsonFromFile);

                return fml;
            };

        }
        // Returns Specific Object from Json Array using page/id
        public FilesModel GetFilesFromJSON(string path, string page)
        {
            var _server = HttpContext.Current.Server;
            FilesModel model = null;

            using (StreamReader sr = new StreamReader(_server.MapPath("~/Content/data/insight/files.js")))
            {
                string _jsonFromFile = sr.ReadToEnd();

                List<FilesModel> fml = new List<FilesModel>();

                fml = JsonConvert.DeserializeObject<List<FilesModel>>(_jsonFromFile);

                foreach (var item in fml)
                {
                    if (item.Page == page)
                    {
                        model = item;
                    }
                }
                return model;
            };

        }
    }
}