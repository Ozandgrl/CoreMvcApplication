using CoreMVC2.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC2.Models.Entities
{
    public class Pages : BaseEntity
    {
        #region Properties
        public string Name { get; set; }
        public string Content { get; set; }
        #endregion
    }
}
