using mvc_dz.DAL.Context;
using mvc_dz.DAL.Interfaces;
using mvc_dz.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_dz.DAL.Repository
{
    public class SqlPostRepository : IRepository<Post>
    {
        private ProjectContext db;

        public SqlPostRepository(ProjectContext db)
        {
            this.db = db;
        }

        public IEnumerable<Post> GetItemList()
        {
            return db.Posts;
        }

        public Post GetItem(int id)
        {
            return db.Posts.Find(id);
        }

        public void Create(Post post)
        {
            db.Posts.Add(post);
        }

        public void Update(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Post post = db.Posts.Find(id);
            if (post != null)
                db.Posts.Remove(post);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
