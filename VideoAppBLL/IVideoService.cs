using System.Collections.Generic;
using VideoAppBLL.BO;

namespace VideoAppBLL
{
    public interface IVideoService
    {
        VideoBO Create(VideoBO vid);
        List<VideoBO> GetAll();
        VideoBO Get(int Id);
        VideoBO Update(VideoBO vid);
        VideoBO Delete(int Id);
    }
}
