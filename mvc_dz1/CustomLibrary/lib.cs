using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLibrary
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Autor { get; set; }

    }

    public class Review
    {
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ReviewText { get; set; }
    }
}
