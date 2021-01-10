using System;
using System.Collections.Generic;

namespace ReadingIsGood.Models
{
    public partial class InventoryItem
    {
        public InventoryItem()
        {
        }
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
