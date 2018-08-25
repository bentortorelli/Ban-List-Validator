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
			for (int i = 0; i < DeckLimit; i++)
			{
				deck.Add(new Card()
				{
					DeckName = MainDeckName,
					Amount = 1
				});
				deck.Add(new Card()
				{
					DeckName = SideDeckName,
					Amount = 1
				});
			}
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
			MinDeckSize sideDeckRule = new MinDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MinSize = DeckLimit
			};
			List<Card> deck = buildDeck();

			Assert.IsTrue(mainDeckRule.isDeckValid(deck));
			Assert.IsTrue(sideDeckRule.isDeckValid(deck));
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
			MinDeckSize sideDeckRule = new MinDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MinSize = DeckLimit
			};
			List<Card> deck = buildDeck();

			Assert.IsFalse(mainDeckRule.isDeckValid(deck));
			Assert.IsTrue(sideDeckRule.isDeckValid(deck));
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
			MinDeckSize sideDeckRule = new MinDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MinSize = DeckLimit
			};
			List<Card> deck = buildDeck();

			Assert.IsTrue(mainDeckRule.isDeckValid(deck));
			Assert.IsTrue(sideDeckRule.isDeckValid(deck));
		}
	}
}