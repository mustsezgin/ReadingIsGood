using ReadingIsGood.DataTransferObjects;
using ReadingIsGood.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReadingIsGood.Queries
{
    public class GetByOrderNumberSalesOrderQueryHandler
    {
        private readonly InventoryContext _context;
        public GetByOrderNumberSalesOrderQueryHandler(InventoryContext context)
        {
            _context = context;
        }
        public async Task<GetByOrderNumberSalesOrderResponse> GetByOrderNumber(GetByOrderNumberSalesOrderRequest request, ClaimsPrincipal user)
        {
            var userId = user.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
            var salesOrder = await _context.SalesOrder.Include(x => x.Product).Include(x => x.UserInfo)
                                        .Where(x => x.UserInfoUserId.ToString().Equals(userId)
                                                 && x.OrderNumber == request.OrderNumber)
                                        .SingleOrDefaultAsync();
            if (salesOrder == null)
            {
                return new GetByOrderNumberSalesOrderResponse();
            }

            return new GetByOrderNumberSalesOrderResponse
            {
                Item = new SalesOrderItemDto
                {
                    OrderDate = salesOrder.OrderDate,
                    ReceiverAdress = salesOrder.UserInfo.Address,
                    ReceiverName = salesOrder.UserInfo.FirstName + " " + salesOrder.UserInfo.LastName,
                    OrderNumber = salesOrder.OrderNumber,
                    ProductCode = salesOrder.Product.ProductCode,
                    ProductName = salesOrder.Product.Name,
                    Quantity = salesOrder.Quantity
                }
            };
        }
    }
}
