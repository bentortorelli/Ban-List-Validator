using BanList.Models;
using BanList.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DeckSize
{
	[TestClass]
	public class MaxDeckSizeTest
	{
		private readonly int DeckLimit = 10;
		private readonly string RuleName = "MaxDeckSize";
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
		public void MaxDeckSize_EqualToLimit_Passes()
		{
			MaxDeckSize mainDeckRule = new MaxDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MaxSize = DeckLimit
			};
			MaxDeckSize sideDeckRule = new MaxDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MaxSize = DeckLimit
			};
			List<Card> deck = buildDeck();

			Assert.IsTrue(mainDeckRule.isDeckValid(deck));
			Assert.IsTrue(sideDeckRule.isDeckValid(deck));
		}

		[TestMethod]
		public void MaxDeckSize_LessThanLimit_Passes()
		{
			MaxDeckSize mainDeckRule = new MaxDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MaxSize = DeckLimit + 1
			};
			MaxDeckSize sideDeckRule = new MaxDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MaxSize = DeckLimit
			};
			List<Card> deck = buildDeck();

			Assert.IsTrue(mainDeckRule.isDeckValid(deck));
			Assert.IsTrue(sideDeckRule.isDeckValid(deck));
		}

		[TestMethod]
		public void MaxDeckSize_GreaterThanLimit_Fails()
		{
			MaxDeckSize mainDeckRule = new MaxDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MaxSize = DeckLimit - 1
			};
			MaxDeckSize sideDeckRule = new MaxDeckSize()
			{
				RuleName = RuleName,
				DeckName = MainDeckName,
				MaxSize = DeckLimit
			};
			List<Card> deck = buildDeck();

			Assert.IsFalse(mainDeckRule.isDeckValid(deck));
			Assert.IsTrue(sideDeckRule.isDeckValid(deck));
		}
	}
}