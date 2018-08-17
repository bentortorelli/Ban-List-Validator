using BanList.Models;
using BanList.Rules;
using CsvHelper;
using System;

namespace BanList.Builders
{
	public static class RuleBuilder
	{
		public static RuleSet Build(CsvReader rulesReader)
		{
			RuleSet rules = new RuleSet();

			while (rulesReader.Read())
			{
				var ruleType = rulesReader[0];
				var type = Type.GetType($"BanList.Rules.{ruleType}");
				var record = (IRule)Activator.CreateInstance(type);

				record.Parse(rulesReader);
				rules.Add(record);
			}

			return rules;
		}
	}
}