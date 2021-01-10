using System;
using System.Collections.Generic;

namespace ReadingIsGood.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            SalesOrder = new HashSet<SalesOrder>();
        }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<SalesOrder> SalesOrder { get; set; }

    }
}
