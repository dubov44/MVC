using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_dz.DAL.Tables
{
    public class QuestionaryResult
    {
        public int QuestionaryResultId { get; set; }


        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please choose sex")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Please choose at least one language")]
        public string Languages { get; set; }
    }
}
