﻿using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.Services;
using VideoAppDAL;

namespace VideoAppBLL
{
    public class BLLFacade
    {
        public IVideoService VideoService
        {
            get { return new VideoService(new DALFacade()); }
        }

    }

}
