using System;
using System.Collections.Generic;
using System.IO;

namespace CSVWriter
{
	public static class FileOperations<T>
	{
		private static readonly string _filePath;

		static FileOperations()
		{
			_filePath = System.IO.Path.GetTempPath() + "Task" + ".csv";

			try
			{
				if (!File.Exists(_filePath))
				{
					using (var file = File.Create(_filePath))
					{
						file.Close();
					};
				}
			}
			catch(UnauthorizedAccessException)
			{
				Console.WriteLine("File access denied");
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("File not found");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void WriteDataToCSV(List<T> list, int hierarchyLimit = 1000)
		{
			list.WriteDataToCSV(list, _filePath, hierarchyLimit);
		}
	}
}
