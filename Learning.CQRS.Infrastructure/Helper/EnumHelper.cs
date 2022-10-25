using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.CQRS.Infrastructure.Helper
{
    public static class EnumHelper
    {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        private static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            if (memInfo.Length == 0)
                return null;
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            if (attributes.Length == 0)
                return null;
            return (T)attributes[0];
        }

        public static string GetDescription(this Enum src)
        {
            DescriptionAttribute attribute = src.GetAttributeOfType<DescriptionAttribute>();
            if (attribute == null)
                return src.ToString();

            return attribute.Description;
        }
    }
}
