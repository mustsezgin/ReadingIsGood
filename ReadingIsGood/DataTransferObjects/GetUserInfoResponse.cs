using System.Collections.Generic;

namespace ReadingIsGood.DataTransferObjects
{
    public class GetUserInfoResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public List<SalesOrderItemDto> OrderList { get; set; }

    }
}
