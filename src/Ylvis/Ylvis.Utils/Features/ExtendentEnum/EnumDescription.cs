using System;
using System.ComponentModel;

namespace Ylvis.Utils.Features.ExtendentEnum
{
    /// <summary>
    /// Provides a description for an enumerated type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute : DescriptionAttribute
    {
        //private string description;
        //public string Description
        //{
        //    get { return this.description; }
        //}

        public EnumDescriptionAttribute(string description) : base(description)
        {
            //base.DescriptionValue = description;
        }
    }
}
