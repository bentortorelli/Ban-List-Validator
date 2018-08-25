using BanList.Builders;
using BanList.Models;
using BanList.Rules;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BanListGui
{
	public class DeckRules
	{
		public IList<Card> Deck { get; set; }
		public IList<Rule> Rules { get; set; }
		public IList<Tuple<bool, String>> Results { get; set; }

		public DeckRules()
		{
			Deck = new List<Card>();
			Rules = new List<Rule>();
			Results = new List<Tuple<bool, String>>();
		}

		public void loadDeck(string deckFile)
		{
			Deck.Clear();

			var cardReader = new CsvReader(File.OpenText(deckFile));
			Deck = DeckBuilder.Build(cardReader);
			cardReader.Dispose();
		}

		public void loadRules(string rulesFile)
		{
			Rules.Clear();

			var rulesReader = new CsvReader(File.OpenText(rulesFile));
			Rules = RuleBuilder.Build(rulesReader);
			rulesReader.Dispose();
		}

		public void Validate()
		{
			if (Deck.Any() && Rules.Any())
			{
				Results.Clear();
				foreach (Rule rule in Rules)
				{
					Results.Add(rule.Validate(Deck));
				}
			}
		}
	}
}