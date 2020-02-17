using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_dz.DAL.Tables
{
    public class Post
    {
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public virtual Author Autor { get; set; }

        public Post()
        {
            Tags = new List<Tag>();
        }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
