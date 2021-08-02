using System.Collections.Generic;

namespace CSVWriter
{
	public class AccountDetails
	{
		public string BankName { get; set; }

		public long AccountNumber { get; set; }

		public string IFSCCode { get; set; }

		public Card CardDetail { get; set; }

		public Nominee Nominee { get; set; }
	}
}