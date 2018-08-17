using BanList.Models;
using CsvHelper;
using System;
using System.Linq;

namespace BanList.Rules
{
	public class DeckMaxSize : IRule
	{
		public string RuleName;
		public string DeckName;
		public int MaxSize;

		public Tuple<bool, String> Validate(Deck deck)
		{
			bool pass = deck.Where(x => x.Name == DeckName)
				.Sum(x => x.Amount) <= MaxSize;

			String returnString = $"{RuleName}: {DeckName} deck maximum size of {MaxSize}: {(pass ? "Pass" : "Fail")}";
			return Tuple.Create(pass, returnString);
		}

		public void Parse(CsvReader csv)
		{
			RuleName = csv.GetField(0);
			DeckName = csv.GetField(1);
			MaxSize = csv.GetField<int>(2);
		}
	}
}