using BanList.Models;
using CsvHelper;
using System.Collections.Generic;
using System.Linq;

namespace BanList.Rules
{
	public class DeckMinSize : Rule
	{
		public string DeckName;
		public int MinSize;

		public override void Parse(CsvReader csv)
		{
			RuleName = csv.GetField(0);
			DeckName = csv.GetField(1);
			MinSize = csv.GetField<int>(2);
		}

		public override string generateRuleText()
		{
			return $"{DeckName} deck minimum size of {MinSize}";
		}

		public override bool isDeckValid(IList<Card> deck)
		{
			return deck
				.Where(x => x.DeckName == DeckName)
				.Sum(x => x.Amount) >= MinSize;
		}
	}
}