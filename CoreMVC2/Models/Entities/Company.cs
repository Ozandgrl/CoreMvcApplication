using CoreMVC2.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC2.Models.Entities
{
    public class Company : BaseEntity
    {
        #region Properties
        public string Department { get; set; }
        public string ImagePath { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Fax { get; set; }
        public string MapPath { get; set; }
        public string DetailInformation { get; set; }
        #endregion
    }
}
