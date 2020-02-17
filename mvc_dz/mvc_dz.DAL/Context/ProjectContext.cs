using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using mvc_dz.DAL.Tables;

namespace mvc_dz.DAL.Context
{
    public class ProjectContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<QuestionaryResult> QuestionaryResults { get; set; }
    }
}
