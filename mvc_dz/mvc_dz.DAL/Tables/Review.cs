using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_dz.DAL.Tables
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Review()
        {
            Date = DateTime.Now;
        }

        [Required(ErrorMessage = "Please enter a comment")]
        public string ReviewText { get; set; }
    }
}
