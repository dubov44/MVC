using mvc_dz.DAL.Interfaces;
using mvc_dz.DAL.Repository;
using mvc_dz.DAL.Tables;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_dz.DAL.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Post>>().To<SqlPostRepository>();
            Bind<IRepository<Author>>().To<SqlAuthorRepository>();
            Bind<IRepository<Review>>().To<SqlReviewRepository>();
        }
    }
}
