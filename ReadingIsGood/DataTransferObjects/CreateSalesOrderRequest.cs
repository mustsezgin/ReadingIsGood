using FluentValidation;

namespace ReadingIsGood.DataTransferObjects
{
    public class CreateSalesOrderRequest
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
    public class CreateSalesOrderRequestValidator : AbstractValidator<CreateSalesOrderRequest>
    {
        public CreateSalesOrderRequestValidator()
        {
            RuleFor(x => x.ProductCode).NotEmpty().WithMessage("Product Code is required");
            RuleFor(x => x.Quantity).NotNull().GreaterThan(0).WithMessage("Quantity cannot be negative or zero.");
        }
    }
}
