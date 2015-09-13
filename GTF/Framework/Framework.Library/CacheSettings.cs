﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Cache
{
    public class CacheSettings
    {
        public CacheSettings()
        {
            TimeToLive = -1;
        }

        public string Name { get; set; }

        public int TimeToLive { get; set; }

        public CacheType CacheType { get; set; }

        public ExpirationType ExpirationType { get; set; }
    }
}
