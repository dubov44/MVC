using mvc_dz.DAL.Context;
using mvc_dz.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_dz.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ProjectContext db = new ProjectContext();
        private SqlAuthorRepository authorRepository;
        private SqlPostRepository postRepository;
        private SqlReviewRepository reviewRepository;
        private SqlTagRepository tagRepository;
        private SqlQuestionaryResultRepository questionaryResultRepository;

        public SqlAuthorRepository Authors
        {
            get
            {
                if (authorRepository == null)
                    authorRepository = new SqlAuthorRepository(db);
                return authorRepository;
            }
        }

        public SqlPostRepository Posts
        {
            get
            {
                if (postRepository == null)
                    postRepository = new SqlPostRepository(db);
                return postRepository;
            }
        }

        public SqlReviewRepository Reviews
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new SqlReviewRepository(db);
                return reviewRepository;
            }
        }
        public SqlTagRepository Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new SqlTagRepository(db);
                return tagRepository;
            }
        }
        public SqlQuestionaryResultRepository QuestionaryResults
        {
            get
            {
                if (questionaryResultRepository == null)
                    questionaryResultRepository = new SqlQuestionaryResultRepository(db);
                return questionaryResultRepository;
            }
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
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
