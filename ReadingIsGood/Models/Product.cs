using System;
using System.Collections.Generic;

namespace ReadingIsGood.Models
{
    public partial class Product
    {
        public Product()
        {
            InventoryItem = new HashSet<InventoryItem>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<InventoryItem> InventoryItem { get; set; }
        public virtual ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
