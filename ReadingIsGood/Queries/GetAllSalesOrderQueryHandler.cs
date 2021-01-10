using ReadingIsGood.DataTransferObjects;
using ReadingIsGood.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReadingIsGood.Queries
{
    public class GetAllSalesOrderQueryHandler
    {
        private readonly InventoryContext _context;
        public GetAllSalesOrderQueryHandler(InventoryContext context)
        {
            _context = context;
        }
        public async Task<GetAllSalesOrderResponse> GetAllSalesOrder(GetAllSalesOrderRequest request, ClaimsPrincipal user)
        {
            var response = new GetAllSalesOrderResponse();
            response.List = await _context.SalesOrder.Select(order => new SalesOrderItemDto
            {
                ReceiverAdress = order.UserInfo.Address,
                ReceiverName = order.UserInfo.FirstName + " " + order.UserInfo.LastName,
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                ProductName = order.Product.Name,
                ProductCode = order.Product.ProductCode,
                Quantity = order.Quantity
            }).ToListAsync();

            return response;
        }
    }
}
