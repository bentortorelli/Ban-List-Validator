using BanList.Models;
using CsvHelper;
using System;
using System.Linq;

namespace BanList.Rules
{
	public class CardMaxAmount : IRule
	{
		public string RuleName;
		public string CardName;
		public int MaxAmount;

		public Tuple<bool, String> Validate(Deck deck)
		{
			bool pass = deck.Where(x => x.Name == CardName)
				.Sum(x => x.Amount) <= MaxAmount;

			String returnString = $"{RuleName}: {CardName} total amount less than {MaxAmount}: {(pass ? "Pass" : "Fail")}";
			return Tuple.Create(pass, returnString);
		}

		public void Parse(CsvReader csv)
		{
			RuleName = csv.GetField(0);
			CardName = csv.GetField(1);
			MaxAmount = csv.GetField<int>(2);
		}
	}
}