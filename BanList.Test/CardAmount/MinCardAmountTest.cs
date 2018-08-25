using BanList.Models;
using BanList.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CardAmount
{
	[TestClass]
	public class MinCardAmountTest
	{
		private readonly int CardLimit = 10;
		private readonly string RuleName = "MinCardAmount";
		private readonly string CardName = "Test Card";
		private readonly string OtherCardName = "Other Test Card";

		private List<Card> buildDeck()
		{
			List<Card> deck = new List<Card>();
			deck.Add(new Card()
			{
				Name = CardName,
				Amount = CardLimit
			});
			deck.Add(new Card()
			{
				Name = OtherCardName,
				Amount = CardLimit
			});
			return deck;
		}

		[TestMethod]
		public void MinCardAmount_EqualToLimit_Passes()
		{
			MinCardAmount maxCardRule = new MinCardAmount()
			{
				RuleName = RuleName,
				CardName = CardName,
				MaxAmount = CardLimit
			};

			List<Card> deck = buildDeck();

			Assert.IsTrue(maxCardRule.isDeckValid(deck));
		}

		[TestMethod]
		public void MinCardAmount_LessThanLimit_Fails()
		{
			MinCardAmount maxCardRule = new MinCardAmount()
			{
				RuleName = RuleName,
				CardName = CardName,
				MaxAmount = CardLimit + 1
			};

			List<Card> deck = buildDeck();

			Assert.IsFalse(maxCardRule.isDeckValid(deck));
		}

		[TestMethod]
		public void MinCardAmount_MoreThanLimit_Passes()
		{
			MinCardAmount maxCardRule = new MinCardAmount()
			{
				RuleName = RuleName,
				CardName = CardName,
				MaxAmount = CardLimit - 1
			};

			List<Card> deck = buildDeck();

			Assert.IsTrue(maxCardRule.isDeckValid(deck));
		}
	}
}