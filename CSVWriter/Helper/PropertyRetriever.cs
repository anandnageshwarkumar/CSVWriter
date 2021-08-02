using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSVWriter
{
	public static class PropertyRetriever
	{
		private static List<Tuple<string, object>> _result = new List<Tuple<string, object>>();

		public static List<Tuple<string, object>> Retrieve(object instanceOfAType, int hierarchyLimit)
		{
			_result.Clear();
			var properties = instanceOfAType.GetType().GetProperties();
			foreach (var property in properties)
			{
				RetrieveChild(instanceOfAType, property, hierarchyLimit);
			}

			//_result.Sort();
			return _result;
		}

		private static void RetrieveChild(object InstanceOfAType, PropertyInfo currentProperty, int hierarchyLimit)
		{
			if (hierarchyLimit > 0)
			{
				var temp = new List<Tuple<string, object>>
				{
					new Tuple<string, object>(currentProperty.Name, currentProperty.GetValue(InstanceOfAType))
				};

				if (TypeChecker.IsValueType(temp[0]?.Item2?.GetType()))
				{
					_result.Add(new Tuple<string, object>(temp[0]?.Item1, temp[0]?.Item2));
				}
				else if (TypeChecker.IsReferenceType(temp[0]?.Item2?.GetType()))
				{
					var properties = temp[0]?.Item2?.GetType().GetProperties();

					foreach (var property in properties)
					{
						RetrieveChild(temp[0]?.Item2, property, hierarchyLimit - 1);
					}
				}
			}
		}
	}
}