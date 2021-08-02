using System.Collections.Generic;

namespace CSVWriter
{
	public static class TestDataSets
	{
		public static List<string> GetNameData()
		{
			return new List<string>()
			{
				"Kalyan",
				"Yuvraj",
				"Libin",
				"Surya"
			};
		}

		public static List<char> GetCharData()
		{
			return new List<char>()
			{
				'Z',
				'X',
				'C',
				'V'
			};
		}

		public static List<double> GetTemperatureData()
		{
			return new List<double>()
			{
				20.55,
				33.21,
				19.18,
				22.01
			};
		}

		public static List<Person> GetPersonData()
		{
			var personList = new List<Person>();

			for(int i= 1; i <= 10;i++)
			{
				personList.Add(GetPerson(i));
			}

			return personList;
		}

		private static Person GetPerson(int i)
		{
			return new Person
			{
				Name = "Person" + i.ToString(),
				Age = 30 + i,
				AccountDetails = new AccountDetails()
				{
					AccountNumber = 1000 + i,
					BankName = "Canara" + i.ToString(),
					Nominee = new Nominee
					{
						NomineeName = "Nominee" + i.ToString(),
						NomineeAccountNumber = 2000 + i
					},
					CardDetail = new Card()
					{
						CardNumber = 3000 + i,
						CardSummary = new CardSummary()
						{
							Balance = 4000 + i,
							CardStatement = new CardStatement()
							{
								Statement = "Statement" + i.ToString()
							}
						},
						CVV = 5000 + i
					},
					IFSCCode = "IFSC" + i.ToString()
				}
			};
		}

		public static List<LeveL> GetLevelList(int MaxLevelToPrint)
		{
			return new List<LeveL>()
			{
				GetLevelData(new LeveL(), 1, MaxLevelToPrint),
			};
		}

		private static LeveL GetLevelData(LeveL level, int levelNumber, int MaxLevel)
		{
			if (levelNumber <= MaxLevel)
			{
				level.ChiildLeveL = new LeveL()
				{
					LevelNumber = levelNumber,
				};

				GetLevelData(level.ChiildLeveL, ++levelNumber, MaxLevel);
			}
			return level;
		}
	}
}