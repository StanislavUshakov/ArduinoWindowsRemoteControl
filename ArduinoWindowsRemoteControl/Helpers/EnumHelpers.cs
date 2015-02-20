using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Helpers
{
    public static class EnumHelpers
    {
        /// <summary>
        /// Get user friendly enum value description
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string ToDisplayName(this Enum enumValue)
        {
            var displayNameAttribute = enumValue.GetType().GetField(enumValue.ToString()).GetAttribute<DescriptionAttribute>();
            return displayNameAttribute != null ? displayNameAttribute.Description : enumValue.ToString();
        }

        public static T GetAttribute<T>(this MemberInfo member)
        {
            return member.GetCustomAttributes(typeof(T), true).Cast<T>().SingleOrDefault();
        }
    }
}
