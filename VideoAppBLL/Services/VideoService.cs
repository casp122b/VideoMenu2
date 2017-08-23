using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL;
using VideoAppEntity;

namespace VideoAppBLL.Services
{
    class VideoService : IVideoService
    {
        IVideoRepository repo;

        public VideoService(IVideoRepository repo)
        {
            this.repo = repo;
        }

        public Video Create(Video vid)
        {
            return this.repo.Create(vid);
        }

        public Video Delete(int Id)
        {
            return repo.Delete(Id);
        }

        public Video Get(int Id)
        {
            return repo.Get(Id);
        }

        public List<Video> GetAll()
        {
            return repo.GetAll();
        }

        public Video Update(Video vid)
        {
            var videoFromDB = Get(vid.Id);
            if(videoFromDB == null)
            {
                throw new InvalidOperationException("Customer not found");
            }
            videoFromDB.Name = vid.Name;
            return videoFromDB;
        }
    }
}
