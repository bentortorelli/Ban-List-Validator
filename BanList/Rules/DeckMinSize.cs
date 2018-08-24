using BanList.Models;
using CsvHelper;
using System;
using System.Linq;

namespace BanList.Rules
{
	public class DeckMinSize : IRule
	{
		public string RuleName;
		public string DeckName;
		public int MinSize;

		public Tuple<bool, String> Validate(Deck deck)
		{
			bool pass = deck.Where(x => x.DeckName == DeckName)
				.Sum(x => x.Amount) >= MinSize;

			String returnString = $"{RuleName}: {DeckName} deck minimum size of {MinSize}: {(pass ? "Pass" : "Fail")}";
			return Tuple.Create(pass, returnString);
		}

		public void Parse(CsvReader csv)
		{
			RuleName = csv.GetField(0);
			DeckName = csv.GetField(1);
			MinSize = csv.GetField<int>(2);
		}
	}
}