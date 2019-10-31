using CoreMVC2.Admin.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC2.Admin.Models.Entities
{
    public class RequestForm : BaseEntity
    {
        #region Properties
        public string CompanyName { get; set; }
        public string CompanyRepresentative { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxNumber { get; set; }
        public string MailAddress { get; set; }
        public string ProductOfInterest { get; set; }
        public double Quantity { get; set; }
        public string City { get; set; }
        public string Explanation { get; set; }
        #endregion
    }
}
