using ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers;
using FluentValidation;

namespace ASP_dotNET6_WebAPI_Template.FluentValidators;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.ID).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty();
    }
}
