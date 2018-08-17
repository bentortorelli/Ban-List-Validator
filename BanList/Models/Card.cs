using Newtonsoft.Json;
using System.Collections.Generic;

namespace BanList.Models
{
	public class Card
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		public int Amount { get; set; }

		public string DeckName { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("number")]
		public int Number { get; set; }

		[JsonProperty("is_monster")]
		public bool IsMonster { get; set; }

		[JsonProperty("is_spell")]
		public bool IsSpell { get; set; }

		[JsonProperty("is_trap")]
		public bool IsTrap { get; set; }

		[JsonProperty("species")]
		public string Species { get; set; }

		[JsonProperty("monster_types")]
		public List<string> Types { get; set; }

		[JsonProperty("attack")]
		public string Attack { get; set; }

		[JsonProperty("defense")]
		public string Defense { get; set; }

		[JsonProperty("stars")]
		public string Stars { get; set; }

		[JsonProperty("attribute")]
		public string Attribute { get; set; }

		[JsonProperty("is_pendulum")]
		public bool IsPendulum { get; set; }

		[JsonProperty("is_xyz")]
		public bool IsXyz { get; set; }

		[JsonProperty("is_synchro")]
		public bool IsSynchro { get; set; }

		[JsonProperty("is_link")]
		public bool IsLink { get; set; }

		[JsonProperty("is_extra_deck")]
		public bool IsExtraDeck { get; set; }

		[JsonProperty("has_materials")]
		public bool HasMaterials { get; set; }
	}
}