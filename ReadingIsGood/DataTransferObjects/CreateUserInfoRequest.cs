using FluentValidation;

namespace ReadingIsGood.DataTransferObjects
{
    public class CreateUserInfoRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
    public class CreateUserInfoRequestValidator : AbstractValidator<CreateUserInfoRequest>
    {
        public CreateUserInfoRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name is required");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Enter a valid e-mail address.");
            RuleFor(x => x.Password).MinimumLength(4).WithMessage("Enter minimum 4 characters for password.");
        }
    }
}
