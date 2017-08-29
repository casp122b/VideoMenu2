using System.Collections.Generic;
using VideoAppDAL.Entities;

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
