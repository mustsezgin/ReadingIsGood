using ReadingIsGood.DataTransferObjects;
using ReadingIsGood.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReadingIsGood.Commands
{
    public class CreateUserInfoCommandHandler
    {
        private readonly InventoryContext _context;
        public CreateUserInfoCommandHandler(InventoryContext context)
        {
            _context = context;
        }
        public async Task<CreateUserInfoResponse> CreateUserInfo(CreateUserInfoRequest request)
        {
            var response = new CreateUserInfoResponse();

            #region Validations
            var userCheck = await _context.UserInfo.Where(x => x.UserName == request.UserName || x.Email == request.Email).AnyAsync();

            if (userCheck)
            {
                response.Success = false;
                response.Message = "Username/Email is already defined in the system.";
                return response;
            }
            #endregion

            #region add User
            var order = new UserInfo
            {
                Email = request.Email,
                UserName = request.UserName,
                Role = "Customer",
                Password = request.Password,
                Address = request.Address,
                FirstName = request.Name,
                LastName = request.LastName,
                CreatedDate = DateTime.Now
            };
            _context.UserInfo.Add(order);
            #endregion

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "User created.";
            }

            return response;
        }
    }
}
