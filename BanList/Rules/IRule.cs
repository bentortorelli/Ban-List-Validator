using BanList.Models;
using CsvHelper;
using System;

namespace BanList.Rules
{
	public interface IRule
	{
		Tuple<bool, String> Validate(Deck deck);

		void Parse(CsvReader csv);
	}
}