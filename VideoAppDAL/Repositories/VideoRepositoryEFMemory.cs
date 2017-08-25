using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppEntity;

namespace VideoAppDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        InMemoryContext _context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            _context = context;
        }

        public Video Create(Video vid)
        {
            _context.Videos.Add(vid);
            return vid;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            _context.Videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return _context.Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return _context.Videos.ToList();
        }
    }
}
