using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

namespace models {
	class Notes {
		[PrimaryKey, NotNull, MaxLength(500), Column("Note")]
		public string Note { get; set; }
		[ForeignKey(typeof(Campaign)), Column("Campaign")]
		public string Campaign { get; set; }

		[ManyToOne]
		public Campaign campaign { get; set; }
	}
}