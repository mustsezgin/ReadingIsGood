using System;
using System.Collections.Generic;

namespace ReadingIsGood.Models
{
    public partial class SalesOrder
    {
        public SalesOrder()
        {
        }

        public Guid Id { get; set; }
        public Guid UserInfoUserId { get; set; }
        public Guid ProductId { get; set; }
        public string OrderNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual Product Product { get; set; }
        public virtual UserInfo UserInfo { get; set; }

    }
}
