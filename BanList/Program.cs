using BanList.Builders;
using BanList.Models;
using BanList.Rules;
using CsvHelper;
using System;
using System.IO;

namespace BanList
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			string deckFile = "decklist.csv";
			string rulesFile = "rulelist.csv";

			var cardReader = new CsvReader(File.OpenText(deckFile));
			var deck = DeckBuilder.Build(cardReader);

			foreach (Card c in deck)
			{
				Console.WriteLine($"{c.Name}, {c.Amount}, {c.DeckName}");
			}

			var rulesReader = new CsvReader(File.OpenText(rulesFile));
			var rulesList = RuleBuilder.Build(rulesReader);

			foreach (Rule r in rulesList)
			{
				Console.WriteLine(r.Validate(deck).Item2);
			};

			Console.ReadKey(true);
		}
	}
}