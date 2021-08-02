using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVWriter
{
	public static class ListExtensions
	{
		public static void WriteDataToCSV<T>(this List<T> list, List<T> items, string path, int hierarchyLimit = 1000)
		{
			try
			{
				Type type = list[0].GetType();

				if (TypeChecker.IsValueType(type))
				{
					ProcessValueTypes(items, path);
				}
				else if (TypeChecker.IsReferenceType(type))
				{
					ProcessReferenceTypes(list, path, hierarchyLimit);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private static void ProcessReferenceTypes<T>(List<T> list, string path, int hierarchyLimit)
		{
			for (int k = 0; k < list.Count; k++)
			{
				var result = PropertyRetriever.Retrieve(list[k], hierarchyLimit);

				if (k == 0)
				{
					WriteHeaderRow(result, path);
				}
				WriteRows(result, path);
			}
		}

		private static void ProcessValueTypes<T>(List<T> items, string path)
		{
			string stringSeparator = ",";
			var stringBuilder = new StringBuilder();

			for (int i = 0; i < items.Count; i++)
				stringBuilder.AppendLine(string.Join(stringSeparator, items[i]));

			stringBuilder.AppendLine();
			WriteCSV(path, stringBuilder);
		}

		private static void WriteHeaderRow(List<Tuple<string, object>> result, string path)
		{
			var stringBuilder = new StringBuilder();
			for (int i = 0; i < result.Count; i++)
			{
				stringBuilder.Append(string.Format($"\"{ result[i].Item1.ToString()}\","));
			}
			stringBuilder.AppendLine();
			WriteCSV(path, stringBuilder);
		}

		private static void WriteRows(List<Tuple<string, object>> result, string path)
		{
			var stringBuilder = new StringBuilder();
			for (int i = 0; i < result.Count; i++)
			{
				stringBuilder.Append(string.Format($"\"{ result[i].Item2.ToString()}\","));
			}
			stringBuilder.AppendLine();
			WriteCSV(path, stringBuilder);
		}

		private static void WriteCSV(string path, StringBuilder stringBuilder)
		{
			File.AppendAllText(path, stringBuilder.ToString());
		}
	}
}