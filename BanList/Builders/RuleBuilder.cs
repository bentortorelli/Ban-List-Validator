using BanList.Models;
using BanList.Rules;
using CsvHelper;
using System;
using System.Collections.Generic;

namespace BanList.Builders
{
	public static class RuleBuilder
	{
		public static IList<Rule> Build(CsvReader rulesReader)
		{
			List<Rule> rules = new List<Rule>();

			while (rulesReader.Read())
			{
				var ruleType = rulesReader[0];
				var type = Type.GetType($"BanList.Rules.{ruleType}");
				var record = (Rule)Activator.CreateInstance(type);

				record.Parse(rulesReader);
				rules.Add(record);
			}

			return rules;
		}
	}
}