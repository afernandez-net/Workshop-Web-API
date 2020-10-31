using Camones.Shop.Application.Adapters;
using FluentValidation;

namespace Camones.Shop.Api.Validation
{
    public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .Length(5,10);

            RuleFor(x => x.LastName)
                .NotNull();
            //RuleFor(x => x.Email).EmailAddress();
            //RuleFor(x => x.Age).InclusiveBetween(18, 60);
        }
    }
}