using System;
using System.IO;
using SQLite;
using models;
using System.Linq;
using System.Runtime.Serialization;

namespace Controllers {
	public class CampaignController{

		private SQLiteConnection conn;

		public CampaignController(string path = null, SQLiteConnection conn = null) {
			string dbPath = path ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "campaignDb.db3;foreign keys=true;");

			if (conn == null) { 
				this.conn = new SQLiteConnection(dbPath);
			} else {
				this.conn = conn;
			}
		}

		public SQLiteConnection GetConnection() {
			return conn;
		}

		/// <summary>
		/// Creates empty database
		/// </summary>
		/// <param name="db"></param>
		public void CreateDatabase() {
			conn.CreateTable<Campaign>();
			conn.CreateTable<NPC>();
			conn.CreateTable<Notes>();
		}

		public bool AddCampaign(string name, string notes = null) {
			var query = from s in conn.Table<Campaign>()
						where s.Name == name
						select s;

			if (query.Count() != 0) {
				return false;
			}

			int added;
			Campaign camp = new Campaign();
			camp.Name = name;
			camp.Notes = notes;
			added = conn.Insert(camp);
			return added > 0;
		}

		public Campaign GetCampaign(string campaign) {
			var query = from c in conn.Table<Campaign>()
						where c.Name == campaign
						select c;

			return query.SingleOrDefault();
		}

		public string[] GetCampaigns() {
			
			var query = from s in conn.Table<Campaign>()
						select s.Name;
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