using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

namespace models {
	[Table("NPC")]
	public class NPC {
		[PrimaryKey, NotNull, MaxLength(20), Column("Name")]
		public string Name { get; set; }
		[ForeignKey(typeof(Campaign)), Column("Campaign")]
		public string Campaign { get; set; }
		[Column("Appearance")]
		public string Appearance { get; set; }
		[Column("Quote")]
		public string Quote { get; set; }
		[Column("Roleplaying")]
		public string Roleplaying { get; set; }
		[Column("Background")]
		public string Background { get; set; }
		[Column("Key Info")]
		public string KeyInfo { get; set; }
		[Column("Stat Block")]
		public string StatBlock { get; set; }

		[ManyToOne]
		public Campaign campaign { get; set; }
	}
}