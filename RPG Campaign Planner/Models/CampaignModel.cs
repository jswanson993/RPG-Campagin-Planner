using SQLite;
namespace models {

	[Table("Campaign")]
	public class Campaign {
		[PrimaryKey, NotNull, MaxLength(20), Column("Name")]
		public string Name { get; set; }
		[Column("General Notes")]
		public string Notes { get; set; }
	}

}