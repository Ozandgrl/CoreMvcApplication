﻿using CoreMVC2.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC2.Models.Entities
{
    public class Reference : BaseEntity
    {
        #region Properties
        public string CustomerName { get; set; }
        public string ImagePath { get; set; }
        #endregion
    }
}
