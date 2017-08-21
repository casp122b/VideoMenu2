﻿using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.Services;

namespace VideoAppBLL
{
    public class BLLFacade
    {
        public IVideoService GetVideoService()
        {
            return new VideoService();
        }

        public IVideoService VideoService
        {
            get { return new VideoService(); }
        }

    }

}
