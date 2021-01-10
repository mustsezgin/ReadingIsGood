using ReadingIsGood.DataTransferObjects;
using ReadingIsGood.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReadingIsGood.Queries
{
    public class GetUserInfoQueryHandler
    {
        private readonly InventoryContext _context;
        public GetUserInfoQueryHandler(InventoryContext context)
        {
            _context = context;
        }
        public async Task<GetUserInfoResponse> GetUserInfo(ClaimsPrincipal user)
        {
            var userId = user.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
            var userInfo = await _context.UserInfo
                                        .Include(x => x.SalesOrder)
                                        .ThenInclude(x => x.Product)
                                        .Where(x => x.UserId.ToString().Equals(userId))
                                        .SingleOrDefaultAsync();

            return new GetUserInfoResponse
            {
                Name = userInfo.FirstName,
                LastName = userInfo.LastName,
                Address = userInfo.Address,
                Email = userInfo.Email,
                UserName = userInfo.UserName,
                OrderList = userInfo.SalesOrder != null ? userInfo.SalesOrder.Select(x => new SalesOrderItemDto
                {
                    OrderDate = x.OrderDate,
                    OrderNumber = x.OrderNumber,
                    ProductCode = x.Product.ProductCode,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity
                }).ToList() : null
            };
        }
    }
}
