using System;
using System.Linq.Expressions;
using FluentValidation.Validators;

namespace Ylvis.Utils.Features.Validation
{
    public class GreaterThanNullableDate<T> : PropertyValidator
    {
        private Expression<Func<T, DateTime?>> mTarget;
        public GreaterThanNullableDate(Expression<Func<T, DateTime?>> expression)
            : base("Property {PropertyName} greater than another date!")
        {
            mTarget = expression;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            Func<T, DateTime?> oFunc = mTarget.Compile();
            //Type oType = mTarget.Parameters[0].Type;
            DateTime? oTargetDateTime = oFunc.Invoke((T)context.Instance);

            DateTime? oSource = context.PropertyValue as DateTime?;

            if (oSource != null && oTargetDateTime != null)
            {
                if (oSource < oTargetDateTime)
                    return false;
            }

            return true;
        }
    }
}