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
    public class SqlAuthorRepository : IRepository<Author>
    {
        private ProjectContext db;

        public SqlAuthorRepository(ProjectContext db)
        {
            this.db = new ProjectContext();
        }

        public IEnumerable<Author> GetItemList()
        {
            return db.Authors;
        }

        public Author GetItem(int id)
        {
            return db.Authors.Find(id);
        }

        public void Create(Author author)
        {
            db.Authors.Add(author);
        }

        public void Update(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Author author = db.Authors.Find(id);
            if (author != null)
                db.Authors.Remove(author);
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
