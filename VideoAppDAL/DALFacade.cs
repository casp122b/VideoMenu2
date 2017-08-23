using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Repositories;

namespace VideoAppDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            //get { return new VideoRepositoryFakeDB(); }
            get
            {
                return new VideoRepositoryEFMemory(new Context.InMemoryContext());
            }
        }
    }
}
