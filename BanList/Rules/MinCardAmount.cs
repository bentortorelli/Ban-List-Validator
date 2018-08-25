using BanList.Models;
using CsvHelper;
using System.Collections.Generic;
using System.Linq;

namespace BanList.Rules
{
	public class MinCardAmount : Rule
	{
		public string CardName;
		public int MaxAmount;

		public override string generateRuleText()
		{
			return $"{CardName} amount greater than {MaxAmount}";
		}

		public override bool isDeckValid(IList<Card> deck)
		{
			return deck
				.Where(x => x.Name == CardName)
				.Sum(x => x.Amount) >= MaxAmount;
		}

		public override void Parse(CsvReader csv)
		{
			RuleName = csv.GetField(0);
			CardName = csv.GetField(1);
			MaxAmount = csv.GetField<int>(2);
		}
	}
}