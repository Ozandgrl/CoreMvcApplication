using CoreMVC2.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC2.Models.Entities
{
    public class Product : BaseEntity
    {
        #region Properties
        public int CatalogId { get; set; }
        public virtual Catalog Catalog { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        #endregion
    }
}
