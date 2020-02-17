using mvc_dz.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_dz.WEB.Models
{
    public class IndexViewModel<T> where T : class
    {
        public IEnumerable<T> Posts { get; set; }
        public Pager Pager { get; set; }
        public T Model { get; set; }
    }
}