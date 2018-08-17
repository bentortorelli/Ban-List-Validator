using BanList.Rules;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BanList.Models
{
	public class RuleSet : IEnumerable<IRule>
	{
		private List<IRule> RuleList { get; set; }

		public int Count
		{
			get
			{
				return RuleList.Count;
			}
		}

		public RuleSet()
		{
			RuleList = new List<IRule>();
		}

		public void Add(IRule rule)
		{
			RuleList.Add(rule);
		}

		public bool Remove(IRule rule)
		{
			return RuleList.Remove(rule);
		}

		public IEnumerable<Tuple<bool, String>> Validate(Deck deck)
		{
			List<Tuple<bool, String>> validations = new List<Tuple<bool, string>>();

			foreach (IRule rule in RuleList)
			{
				validations.Add(rule.Validate(deck));
			}

			return validations;
		}

		public IEnumerator<IRule> GetEnumerator()
		{
			return ((IEnumerable<IRule>)RuleList).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IRule>)RuleList).GetEnumerator();
		}
	}
}