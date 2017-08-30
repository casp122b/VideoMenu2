using System;
using System.Collections.Generic;
using System.Linq;
using VideoAppBLL.BO;
using VideoAppBLL.Converters;
using VideoAppDAL;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Services
{
    class VideoService : IVideoService
    {

        VideoConverter vidCon = new VideoConverter();

        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(vidCon.Convert(vid));
                uow.Complete();
                return vidCon.Convert(newVid);
            }; 
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return vidCon.Convert(newVid);
            };
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return vidCon.Convert(uow.VideoRepository.Get(Id));
            };
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //return uow.VideoRepository.GetAll();
                return uow.VideoRepository.GetAll().Select(v => vidCon.Convert(v)).ToList();

            };
        }

        public VideoBO Update(VideoBO vid)
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
                return vidCon.Convert(videoFromDB);
            }
        }

        
    }
}
