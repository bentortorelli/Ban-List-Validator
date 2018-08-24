using BanList.Models;
using CsvHelper;
using System;
using System.Linq;

namespace BanList.Rules
{
	public class Forbidden : IRule
	{
		public string RuleName;
		public string CardName;
		public int MaxAmount;

		public Tuple<bool, String> Validate(Deck deck)
		{
			CardMaxAmount forbidden = new CardMaxAmount
			{
				CardName = this.CardName,
				MaxAmount = this.MaxAmount
			};
			bool pass = deck.Where(x => x.Name == CardName)
				.Sum(x => x.Amount) <= MaxAmount;

			String returnString = $"{RuleName}: {CardName} deck maximum size of {MaxAmount}: {(pass ? "Pass" : "Fail")}";
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