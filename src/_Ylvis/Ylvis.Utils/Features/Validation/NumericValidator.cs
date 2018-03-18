using System;
using System.Linq.Expressions;
using FluentValidation.Validators;
using Ylvis.Utils.Features.TypesParsing;

namespace Ylvis.Utils.Features.Validation
{
    public class NumericValidator : PropertyValidator
    {
        public NumericValidator()
            : base((Expression<Func<string>>)(() => "Musi byc liczba"))
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string str1 = context.PropertyValue as string;
            if (str1 != null)
            {
                var number = str1.ParseSafe<long?>();
                if (number == null)
                    return false;
            }
            return true;
        }
    }
}