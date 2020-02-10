using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CustomLibrary;

namespace mvc_dz1.Context
{
    public class ProjectContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}