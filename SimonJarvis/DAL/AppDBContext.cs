using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SimonJarvis.Models;

namespace SimonJarvis.DAL
{
    public class AppDBContext : DbContext
    {
        public DbSet<TestModel> TestTable { get; set; }
    }
}