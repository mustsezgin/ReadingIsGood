using FluentValidation;

namespace ReadingIsGood.DataTransferObjects
{
    public class GetByOrderNumberSalesOrderRequest
    {
        public string OrderNumber { get; set; }
    }
    public class GetByOrderNumberSalesOrderRequestValidator : AbstractValidator<GetByOrderNumberSalesOrderRequest>
    {
        public GetByOrderNumberSalesOrderRequestValidator()
        {
            RuleFor(x => x.OrderNumber).NotEmpty().WithMessage("Order Number is required");
        }
    }
}
