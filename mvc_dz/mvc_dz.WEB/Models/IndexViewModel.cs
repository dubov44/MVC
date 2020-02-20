using mvc_dz.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc_dz.Bll.BusinessModels;

namespace mvc_dz.WEB.Models
{
    public class IndexViewModel<T, V> 
        where T : class 
        where V : class
    {
        public IEnumerable<T> Posts { get; set; }
        public Pager Pager { get; set; }
        public T Model { get; set; }
        public V Additionary { get; set; }
    }
}