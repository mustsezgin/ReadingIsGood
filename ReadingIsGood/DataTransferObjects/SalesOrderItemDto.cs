using System;

namespace ReadingIsGood.DataTransferObjects
{
    public class SalesOrderItemDto
    {
        public DateTime? OrderDate { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAdress { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string OrderNumber { get; set; }
        public int Quantity { get; set; }
    }
}
