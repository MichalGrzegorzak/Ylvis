using System;
using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.Validators;

namespace Ylvis.Utils.Features.Validation
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, DateTime?> GreaterThanNullableDate<T>(this IRuleBuilder<T, DateTime?> ruleBuilder, Expression<Func<T, DateTime?>> expression) //Expression<PropertySelector<T, DateTime?>> expression)//Expression<Func<T, DateTime?>> expression) 
        {
            return ruleBuilder.SetValidator(new GreaterThanNullableDate<T>(expression));
        }

        public static IRuleBuilderOptions<T, string> Numeric<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator((IPropertyValidator)new NumericValidator());
        }
        public static IRuleBuilderOptions<T, string> Iban<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator((IPropertyValidator)new IbanValidator());
        }
    }
}