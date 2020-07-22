using System;
using System.IO;
using SQLite;
using models;
using System.Linq;
using System.Runtime.Serialization;

namespace Controllers {
	public class CampaignController{

		private SQLiteConnection conn;

		public CampaignController(string path = null) {
			string dbPath = path ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "campaignDb.db3;foreign keys=true;");

			conn = new SQLiteConnection(dbPath);
		}

		public SQLiteConnection GetConnection() {
			return conn;
		}

		/// <summary>
		/// Creates empty database
		/// </summary>
		/// <param name="db"></param>
		public void CreateDatabase(SQLiteConnection c) {
			c.CreateTable<Campaign>();
			c.CreateTable<NPC>();
		}

		public bool AddCampaign(SQLiteConnection c, string name, string notes = null) {
			var query = from s in c.Table<Campaign>()
						where s.Name == name
						select s;

			if (query.Count() != 0) {
				return false;
			}

			int added;
			Campaign camp = new Campaign();
			camp.Name = name;
			camp.Notes = notes;
			added = c.Insert(camp);
			return added > 0;
		}

		public string[] GetCampaigns(SQLiteConnection c) {
			
			var query = from s in c.Table<Campaign>()
						select s.Name;
			if(query.Count() == 0) {
				return query.DefaultIfEmpty().ToArray();
			} else {
				return query.ToArray();
			}
		}

		public string[] GetNotes(SQLiteConnection c, string campaign) {
			var query = from camp in c.Table<Campaign>()
						where camp.Name.Equals(campaign)
						select camp.Notes;

			if(query.Count() == 0) {
				return query.DefaultIfEmpty().ToArray();
			} else {
				return query.ToArray();
			}
		}

		public void CloseConnection(SQLiteConnection c) {
			c.Close();
		}
	}


}