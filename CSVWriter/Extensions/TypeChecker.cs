using System;
using System.Collections.Generic;

namespace CSVWriter
{
	public static class TypeChecker
	{
		static TypeChecker()
		{
			AllowedValueTypes = new List<Type>()
			{
				typeof(int),
				typeof(double),
				typeof(long),
				typeof(string),
				typeof(char)
			};
		}
		private static List<Type> AllowedValueTypes { get; set; }

		public static bool IsValueType(Type type)
		{
			return 
				AllowedValueTypes.Contains(type);
		}

		public static bool IsReferenceType(Type type)
		{
			return 
				type != null &&
				type.BaseType.Equals(typeof(object)) && 
				type.GetType().IsClass && 
				type != typeof(string);
		}
	}
}