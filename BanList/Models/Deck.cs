using System.Collections;
using System.Collections.Generic;

namespace BanList.Models
{
	public class Deck : IEnumerable<Card>
	{
		private List<Card> DeckList { get; set; }

		public int Count
		{
			get
			{
				return DeckList.Count;
			}
		}

		public Deck()
		{
			DeckList = new List<Card>();
		}

		public void Add(Card card)
		{
			DeckList.Add(card);
		}

		public bool Remove(Card card)
		{
			return DeckList.Remove(card);
		}

		public IEnumerator<Card> GetEnumerator()
		{
			return ((IEnumerable<Card>)DeckList).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Card>)DeckList).GetEnumerator();
		}
	}
}