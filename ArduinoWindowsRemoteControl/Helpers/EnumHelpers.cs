using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Helpers
{
    #region Reserved Attribute

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class ReservedAttribute : Attribute { }

    #endregion

    public static class EnumHelpers
    {
        /// <summary>
        /// Get user friendly enum value description
        /// </summary>
        /// <param name="enumValue">Enum value</param>
        /// <returns>String representation</returns>
        public static string ToDisplayName(this Enum enumValue)
        {
            var displayNameAttribute = enumValue.GetType().GetField(enumValue.ToString()).GetAttribute<DescriptionAttribute>();
            return displayNameAttribute != null ? displayNameAttribute.Description : enumValue.ToString();
        }

        /// <summary>
        /// Returns specific attribute (via reflection)
        /// </summary>
        /// <typeparam name="T">Type of attribute</typeparam>
        /// <param name="member">Member to retrieve attribute</param>
        /// <returns>Attribute value</returns>
        public static T GetAttribute<T>(this MemberInfo member)
        {
            return member.GetCustomAttributes(typeof(T), true).Cast<T>().SingleOrDefault();
        }

        /// <summary>
        /// Returns a list of pairs: 1 string representation, 2 value
        /// for all enum values that do not have Reserved attribute
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <returns>List of pairs: 1 string representation, 2 value </returns>
        public static List<Tuple<string, Enum>> GetAvailableEnumValues<T>()
        {
            var result = new List<Tuple<string, Enum>>();
            foreach (var enumValue in Enum.GetValues(typeof(T)).Cast<Enum>())
            {
                if (enumValue.GetType().GetField(enumValue.ToString()).GetAttribute<ReservedAttribute>() != null)
                    continue;

                result.Add(new Tuple<string, Enum>(enumValue.ToDisplayName(), enumValue));
            }

            return result;
        }
    }
}
