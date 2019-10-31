using CoreMVC2.Admin.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC2.Admin.Models.Entities
{
    public class User : BaseEntity
    {
        #region Properties
        public string NameSurname { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }

        #endregion
    }
}
