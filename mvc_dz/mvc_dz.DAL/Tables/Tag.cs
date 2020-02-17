using mvc_dz.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_dz.DAL.Tables
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public Tag()
        {
            Posts = new List<Post>();
        }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
