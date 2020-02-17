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
    public class SqlQuestionaryResultRepository : IRepository<QuestionaryResult>
    {
        private ProjectContext db;

        public SqlQuestionaryResultRepository(ProjectContext db)
        {
            this.db = new ProjectContext();
        }

        public IEnumerable<QuestionaryResult> GetItemList()
        {
            return db.QuestionaryResults;
        }

        public QuestionaryResult GetItem(int id)
        {
            return db.QuestionaryResults.Find(id);
        }

        public void Create(QuestionaryResult questionaryResult)
        {
            db.QuestionaryResults.Add(questionaryResult);
        }

        public void Update(QuestionaryResult questionaryResult)
        {
            db.Entry(questionaryResult).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            QuestionaryResult questionaryResult = db.QuestionaryResults.Find(id);
            if (questionaryResult != null)
                db.QuestionaryResults.Remove(questionaryResult);
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

