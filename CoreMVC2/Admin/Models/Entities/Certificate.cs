using CoreMVC2.Admin.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC2.Admin.Models.Entities
{
    public class Certificate : BaseEntity
    {
        #region Properties
        public string Text { get; set; }
        public string ImagePath { get; set; }
        #endregion
    }
}
