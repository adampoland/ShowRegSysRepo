﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRegSys.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int ShowId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public virtual Show Shows { get; set; }
    }
}