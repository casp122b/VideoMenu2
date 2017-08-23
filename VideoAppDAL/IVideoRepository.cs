using System;
using System.Collections.Generic;
using System.Text;
using VideoAppEntity;

namespace VideoAppDAL
{
    public interface IVideoRepository
    {
        Video Create(Video vid);
        List<Video> GetAll();
        Video Get(int Id);
        Video Delete(int Id);
    }
}
