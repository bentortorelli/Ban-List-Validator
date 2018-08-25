using BanList.Models;
using BanList.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CardAmount
{
	[TestClass]
	public class MaxCardAmountTest
	{
		private readonly int CardLimit = 10;
		private readonly string RuleName = "MaxCardAmount";
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
		public void MaxCardAmount_EqualToLimit_Passes()
		{
			MaxCardAmount maxCardRule = new MaxCardAmount()
			{
				RuleName = RuleName,
				CardName = CardName,
				MaxAmount = CardLimit
			};

			List<Card> deck = buildDeck();

			Assert.IsTrue(maxCardRule.isDeckValid(deck));
		}

		[TestMethod]
		public void MaxCardAmount_LessThanLimit_Passes()
		{
			MaxCardAmount maxCardRule = new MaxCardAmount()
			{
				RuleName = RuleName,
				CardName = CardName,
				MaxAmount = CardLimit + 1
			};

			List<Card> deck = buildDeck();

			Assert.IsTrue(maxCardRule.isDeckValid(deck));
		}

		[TestMethod]
		public void MaxCardAmount_MoreThanLimit_Fails()
		{
			MaxCardAmount maxCardRule = new MaxCardAmount()
			{
				RuleName = RuleName,
				CardName = CardName,
				MaxAmount = CardLimit - 1
			};

			List<Card> deck = buildDeck();

			Assert.IsFalse(maxCardRule.isDeckValid(deck));
		}
	}
}