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
    public class SqlReviewRepository : IRepository<Review>
    {
        private ProjectContext db;

        public SqlReviewRepository(ProjectContext db)
        {
            this.db = new ProjectContext();
        }

        public IEnumerable<Review> GetItemList()
        {
            return db.Reviews;
        }

        public Review GetItem(int id)
        {
            return db.Reviews.Find(id);
        }

        public void Create(Review review)
        {
            db.Reviews.Add(review);
        }

        public void Update(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Review review = db.Reviews.Find(id);
            if (review != null)
                db.Reviews.Remove(review);
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
