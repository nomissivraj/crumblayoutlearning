using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimonJarvis.Models
{
    public class FilesModel
    {
        [JsonProperty("Page")]
        public string Page { get; set; }
        
        [JsonProperty("Files")]
        public File[] Files { get; set; }
    }

    public class File
    {
        [JsonProperty("FileName")]
        public string FileName { get; set; }
        [JsonProperty("FilePath")]
        public string FilePath { get; set; }
    }
}