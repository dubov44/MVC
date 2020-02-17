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
    public class SqlTagRepository : IRepository<Tag>
    {
        private ProjectContext db;

        public SqlTagRepository(ProjectContext db)
        {
            this.db = new ProjectContext();
        }

        public IEnumerable<Tag> GetItemList()
        {
            return db.Tags;
        }

        public Tag GetItem(int id)
        {
            return db.Tags.Find(id);
        }

        public void Create(Tag tag)
        {
            db.Tags.Add(tag);
        }

        public void Update(Tag tag)
        {
            db.Entry(tag).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag != null)
                db.Tags.Remove(tag);
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
