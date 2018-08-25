using BanList.Models;
using BanList.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DeckSize
{
	[TestClass]
	public class MinDeckSizeTest
	{
		private readonly int DeckLimit = 10;
		private readonly string RuleName = "MinDeckSize";
		private readonly string MainDeckName = "Main";
		private readonly string SideDeckName = "Side";

		private List<Card> buildDeck()
		{
			List<Card> deck = new List<Card>();

			deck.Add(new Card()
			{
				DeckName = MainDeckName,
				Amount = DeckLimit
			});
			deck.Add(new Card()
			{
				DeckName = SideDeckName,
				Amount = DeckLimit
			});

			return deck;
		}

		[TestMethod]
		public void MinDeckSize_EqualToLimit_Passes()
		{
			MinDeckSize mainDeckRule = new MinDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MinSize = DeckLimit
			};

			List<Card> deck = buildDeck();

			Assert.IsTrue(mainDeckRule.isDeckValid(deck));
		}

		[TestMethod]
		public void MinDeckSize_LessThanLimit_Fails()
		{
			MinDeckSize mainDeckRule = new MinDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MinSize = DeckLimit + 1
			};

			List<Card> deck = buildDeck();

			Assert.IsFalse(mainDeckRule.isDeckValid(deck));
		}

		[TestMethod]
		public void MinDeckSize_GreaterThanLimit_Passes()
		{
			MinDeckSize mainDeckRule = new MinDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MinSize = DeckLimit - 1
			};

			List<Card> deck = buildDeck();

			Assert.IsTrue(mainDeckRule.isDeckValid(deck));
		}
	}
}