using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadingIsGood.Models;
using ReadingIsGood.DataTransferObjects;
using ReadingIsGood.Commands;
using ReadingIsGood.Queries;
using Microsoft.AspNetCore.Authorization;

namespace ReadingIsGood.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SalesOrderController : ControllerBase
    {
        private readonly InventoryContext _context;

        public SalesOrderController(InventoryContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creates new sales order.
        /// </summary>
        /// <remarks>
        /// Enter a valid Product Code and Quantity for the order.
        /// </remarks>
        [Authorize]
        [HttpPost]
        public async Task<CreateSalesOrderResponse> Create([FromBody]CreateSalesOrderRequest request)
        {
            var response = await new CreateSalesOrderCommandHandler(_context).CreateSalesOrder(request, User);
            return response;
        }
        /// <summary>
        /// Returns all orders.
        /// </summary>
        [HttpPost]
        public async Task<GetAllSalesOrderResponse> GetAll([FromBody]GetAllSalesOrderRequest request)
        {
            var response = await new GetAllSalesOrderQueryHandler(_context).GetAllSalesOrder(request, User);
            return response;
        }

        /// <summary>
        /// Returns order details by order number.
        /// </summary>
        [HttpPost]
        public async Task<GetByOrderNumberSalesOrderResponse> GetByOrderNumber([FromBody] GetByOrderNumberSalesOrderRequest request)
        {
            var response = await new GetByOrderNumberSalesOrderQueryHandler(_context).GetByOrderNumber(request, User);
            return response;
        }
    }
}
