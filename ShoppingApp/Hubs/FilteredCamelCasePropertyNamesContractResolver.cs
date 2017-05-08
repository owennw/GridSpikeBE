using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ShoppingApp.Hubs
{
    public class FilteredCamelCasePropertyNamesContractResolver : DefaultContractResolver
    {
        public FilteredCamelCasePropertyNamesContractResolver()
        {
            AssembliesToInclude = new HashSet<Assembly>();
            TypesToInclude = new HashSet<Type>();
        }

        // Identifies assemblies to include in camel-casing
        public HashSet<Assembly> AssembliesToInclude { get; set; }

        // Identifies types to include in camel-casing
        public HashSet<Type> TypesToInclude { get; set; }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);
            Type declaringType = member.DeclaringType;
            if (TypesToInclude.Contains(declaringType) || AssembliesToInclude.Contains(declaringType.Assembly))
            {
                jsonProperty.PropertyName = ToCamelCase(jsonProperty.PropertyName);
            }

            return jsonProperty;
        }

        private static string ToCamelCase(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var firstChar = value[0];

            if (char.IsLower(firstChar))
            {
                return value;
            }

            firstChar = char.ToLowerInvariant(firstChar);
            return firstChar + value.Substring(1);
        }
    }
}