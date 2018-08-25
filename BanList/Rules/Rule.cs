using BanList.Models;
using CsvHelper;
using System;
using System.Collections.Generic;

namespace BanList.Rules
{
	public abstract class Rule
	{
		public string RuleName { get; set; }

		public Tuple<bool, String> Validate(IList<Card> deck)
		{
			bool pass = isDeckValid(deck);
			return Tuple.Create(pass, $"{RuleName}: {generateRuleText()}: {(pass ? "Pass" : "False")}");
		}

		public abstract void Parse(CsvReader csv);

		public abstract string generateRuleText();

		public abstract bool isDeckValid(IList<Card> deck);
	}
}