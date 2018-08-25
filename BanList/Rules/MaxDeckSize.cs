using BanList.Models;
using CsvHelper;
using System.Collections.Generic;
using System.Linq;

namespace BanList.Rules
{
	public class MaxDeckSize : Rule
	{
		public string DeckName;
		public int MaxSize;

		public override void Parse(CsvReader csv)
		{
			RuleName = csv.GetField(0);
			DeckName = csv.GetField(1);
			MaxSize = csv.GetField<int>(2);
		}

		public override string generateRuleText()
		{
			return $"{DeckName} deck maximum size of {MaxSize}";
		}

		public override bool isDeckValid(IList<Card> deck)
		{
			return deck
				.Where(x => x.DeckName == DeckName)
				.Sum(x => x.Amount) <= MaxSize;
		}
	}
}