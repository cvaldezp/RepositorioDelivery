﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDelivery.Models
{
    public class UserResponseGeneric
    {
        public bool status { get; set; }
        public string dato { get; set; }
        public string message { get; set; }
    }
}