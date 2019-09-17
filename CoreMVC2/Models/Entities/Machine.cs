﻿using CoreMVC2.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC2.Models.Entities
{
    public class Machine : BaseEntity
    {
        #region Properties
        public int CompanyId { get; set; }
        public string Name { get; set; }
        #endregion
    }
}
