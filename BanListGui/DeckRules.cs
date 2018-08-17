﻿using BanList.Builders;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using BanList.Models;
using BanList.Builders;

namespace BanListGui
{
	public class DeckRules
	{
		public Deck Deck { get; set; }
		public RuleSet Rules { get; set; }
		public IEnumerable<Tuple<bool, String>> Results { get; set; }

		public DeckRules()
		{
		}

		public void loadDeck(string deckFile)
		{
			var cardReader = new CsvReader(File.OpenText(deckFile));
			Deck = DeckBuilder.Build(cardReader);
		}

		public void loadRules(string rulesFile)
		{
			var rulesReader = new CsvReader(File.OpenText(rulesFile));
			Rules = RuleBuilder.Build(rulesReader);
		}

		public void validate()
		{
			if (Deck != null && Rules != null)
			{
				Results = Rules.Validate(Deck);
			}
		}
	}
}