using CoreMVC2.Admin.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC2.Admin.Models.Entities
{
    public class Logon : BaseEntity
    {
        #region Properties
        public string UserCode { get; set; }
        public string Password { get; set; }
        #endregion
    }
}
