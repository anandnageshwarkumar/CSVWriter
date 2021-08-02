using System;

namespace CSVWriter
{
	public class Program
	{
		static void Main(string[] args)
		{
			// check for string datatype
			FileOperations<string>.WriteDataToCSV(TestDataSets.GetNameData());
			
			// check for double datatype
			FileOperations<double>.WriteDataToCSV(TestDataSets.GetTemperatureData());

			// check for char datatype
			FileOperations<char>.WriteDataToCSV(TestDataSets.GetCharData());

			// check for class type
			FileOperations<Person>.WriteDataToCSV(TestDataSets.GetPersonData());

			// check for class type with specifing how many levels of print needed
			//FileOperations<Person>.WriteDataToCSV(TestDataSets.GetPersonData(), 1);
			//FileOperations<Person>.WriteDataToCSV(TestDataSets.GetPersonData(), 2);
			//FileOperations<Person>.WriteDataToCSV(TestDataSets.GetPersonData(), 3);
			//FileOperations<Person>.WriteDataToCSV(TestDataSets.GetPersonData(), 4);
			//FileOperations<Person>.WriteDataToCSV(TestDataSets.GetPersonData(), 5);


			// Number of levels check
			/* 
			The Class Level is heirarchical and has recursive child levels, we can
			 construct the number of child levels by passing a parameter
			 if we pass 5 , upto 5 child levels are created upto 0
			 if we pass 2000, upto 2000 chld levels created, but only upto 1000 prints
			 due to default limitation of hierarchyLimit to 1000
			 Level Prints up to 20th child level 
			 */
			FileOperations<LeveL>.WriteDataToCSV(TestDataSets.GetLevelList(20));

			// Level Prints up to 200th child level
			//FileOperations<LeveL>.WriteDataToCSV(TestDataSets.GetLevelList(200));

			// Level Prints up to 1000th child level even though 2000 levels 
			//FileOperations<LeveL>.WriteDataToCSV(TestDataSets.GetLevelList(2000));
			Console.WriteLine("File write completed");
			Console.ReadKey();
		}
	}
}
