using ReadingIsGood.Commands;
using ReadingIsGood.DataTransferObjects;
using ReadingIsGood.Models;
using ReadingIsGood.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingIsGood.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly InventoryContext _context;

        public UserController(InventoryContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Register new user.
        /// </summary>
        /// <remarks>
        /// Enter valid information to register as a new user.
        /// </remarks>
        [HttpPost]
        public async Task<CreateUserInfoResponse> Create([FromBody] CreateUserInfoRequest request)
        {
            var response = await new CreateUserInfoCommandHandler(_context).CreateUserInfo(request);
            return response;
        }

        /// <summary>
        /// Returns user information.
        /// </summary>
        [HttpPost]
        public async Task<GetUserInfoResponse> GetUser()
        {
            var response = await new GetUserInfoQueryHandler(_context).GetUserInfo(User);
            return response;
        }
    }
}
