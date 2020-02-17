using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_dz.DAL.Tables
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Login { get; set; }
        public string Bio { get; set; }


        public virtual ICollection<Post> Posts { get; set; }
    }
}
