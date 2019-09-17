using CoreMVC2.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC2.Models.Entities
{
    public class Catalog : BaseEntity
    {
        public Catalog()
        {
            Products = new List<Product>();
        }

        #region Properties
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        #endregion
    }
}
