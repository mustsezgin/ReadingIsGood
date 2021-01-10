using ReadingIsGood.DataTransferObjects;
using ReadingIsGood.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReadingIsGood.Commands
{
    public class CreateSalesOrderCommandHandler
    {
        private readonly InventoryContext _context;
        public CreateSalesOrderCommandHandler(InventoryContext context)
        {
            _context = context;
        }
        public async Task<CreateSalesOrderResponse> CreateSalesOrder(CreateSalesOrderRequest request, ClaimsPrincipal user)
        {
            var response = new CreateSalesOrderResponse();

            var product = await _context.Product.Where(x => x.IsActive && x.ProductCode == request.ProductCode).SingleOrDefaultAsync();
            var userId = user.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
            var userInfo = await _context.UserInfo.Where(x => x.UserId.ToString().Equals(userId)).SingleOrDefaultAsync();
            #region Validations
            if (product == null)
            {
                response.Success = false;
                response.Message = "Items must be products already defined in the system.";
                return response;
            }
            #endregion

            var item = await _context.InventoryItem.Include(x => x.Product)
                                                      .Where(x => x.Product.IsActive &&
                                                                    x.Product.ProductCode == request.ProductCode &&
                                                                    x.Quantity >= request.Quantity).FirstOrDefaultAsync();

            #region check inventory
            if (item == null)
            {
                response.Success = false;
                response.Message = "A Sales Order requiring more stock than the available stock for that product in the warehouse cannot be created. ";
                return response;
            }
            #endregion

            #region add SalesOrder
            var order = new SalesOrder();
            order.UserInfoUserId = new Guid(userId);
            order.OrderDate = DateTime.Now;
            order.ProductId = item.ProductId.Value;
            order.Quantity = request.Quantity;
            var orderNumber = await _context.SalesOrder.CountAsync();
            order.OrderNumber = orderNumber.ToString();
            _context.SalesOrder.Add(order);
            #endregion

            #region update inventory
            item.Quantity -= request.Quantity;
            _context.InventoryItem.Update(item);
            #endregion

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Order created.";
            }

            return response;
        }
    }
}
