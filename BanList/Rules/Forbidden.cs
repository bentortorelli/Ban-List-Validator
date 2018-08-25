using BanList.Models;
using CsvHelper;
using System.Collections.Generic;

namespace BanList.Rules
{
	public class Forbidden : Rule
	{
		public string CardName;

		public override void Parse(CsvReader csv)
		{
			RuleName = csv.GetField(0);
			CardName = csv.GetField(1);
		}

		public override string generateRuleText()
		{
			return $"{CardName} is Forbidden";
		}

		public override bool isDeckValid(IList<Card> deck)
		{
			MaxCardAmount maxAmountRule = new MaxCardAmount
			{
				CardName = this.CardName,
				MaxAmount = 0
			};
			return maxAmountRule.isDeckValid(deck);
		}
	}
}