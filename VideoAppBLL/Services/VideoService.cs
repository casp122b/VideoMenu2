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
        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public Video Create(Video vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(vid);
                uow.Complete();
                return newVid;
            }; 
        }

        public Video Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return newVid;
            };
        }

        public Video Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.Get(Id);
            };
        }

        public List<Video> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll();
            };
        }

        public Video Update(Video vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoFromDB = uow.VideoRepository.Get(vid.Id);
                if (videoFromDB == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }
                videoFromDB.Name = vid.Name;
                uow.Complete();
                return videoFromDB;
            }
        }
    }
}
