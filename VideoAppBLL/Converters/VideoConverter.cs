using VideoAppBLL.BO;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converters
{
    class VideoConverter
    {
        internal Video Convert(VideoBO vid)
        {
            return new Video()
            {
                Id = vid.Id,
                Name = vid.Name
            };
        }

        internal VideoBO Convert(Video vid)
        {
            return new VideoBO()
            {
                Id = vid.Id,
                Name = vid.Name
            };
        }
    }
}
