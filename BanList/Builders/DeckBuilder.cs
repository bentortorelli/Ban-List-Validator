﻿using BanList.Models;
using CsvHelper;
using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace BanList.Builders
{
	public class DeckBuilder
	{
		public static Deck Build(CsvReader cardReader)
		{
			const string apiEndpoint = "https://www.ygohub.com/api/card_info?name=";
			Deck deck = new Deck();

			cardReader.Read();
			cardReader.ReadHeader();
			while (cardReader.Read())
			{
				string cardName = cardReader.GetField("Name");
				int cardAmount = cardReader.GetField<int>("Amount");
				string deckName = cardReader.GetField("Deck");

				var client = new WebClient();
				var response = client.DownloadString(apiEndpoint + Uri.EscapeDataString(cardName));

				var card = JObject.Parse(response).GetValue("card").ToObject<Card>();
				card.Amount = cardAmount;
				card.DeckName = deckName;

				deck.Add(card);
			};

			return deck;
		}
	}
}