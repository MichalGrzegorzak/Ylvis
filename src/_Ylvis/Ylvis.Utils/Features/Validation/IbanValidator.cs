using System;
using System.Linq.Expressions;
using FluentValidation.Resources;
using FluentValidation.Validators;

namespace Ylvis.Utils.Features.Validation
{
    public class IbanValidator : PropertyValidator
    {
        public IbanValidator()
            : base((Expression<Func<string>>)(() => "Nie prawidlowy Iban"))
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string iban = context.PropertyValue as string;
            var status = Iban.CheckIban(iban, true);
            
            bool result = status.IsValid;
            if(!result)
                ErrorMessageSource = (IStringSource)new StaticStringSource(status.Message);
            return result;
        }
    }
}