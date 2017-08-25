using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Repositories;

namespace VideoAppDAL.UOW
{
    public class UnitOfWorkMemory : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        private InMemoryContext context;

        public UnitOfWorkMemory()
        {
            context = new InMemoryContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
