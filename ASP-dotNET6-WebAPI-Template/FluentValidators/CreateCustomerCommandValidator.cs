using ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;
using FluentValidation;

namespace ASP_dotNET6_WebAPI_Template.FluentValidators;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
    }
}
