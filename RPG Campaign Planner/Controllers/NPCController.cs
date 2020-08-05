using System;
using System.IO;
using SQLite;
using models;
using System.Linq;

namespace RPG_Campaign_Planner.Controllers {
	class NPCController {
		private SQLiteConnection conn;

		public NPCController(string path = null, SQLiteConnection conn = null) {
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

		public string GetNPC(string name, string campaign) {
			return "";
		}

		public string[] GetNPCNames(string campaign) {
			var query = from npc in conn.Table<NPC>()
						where npc.campaign.Equals(campaign)
						select npc.Name;
			if(query.Count() == 0) {
				return query.DefaultIfEmpty().ToArray();
			} else {
				return query.ToArray();
			}
		}
	}
}