using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using models;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Org.Json;
using System.Runtime.InteropServices;
using Android.Accounts;
using Newtonsoft.Json;
using RPG_Campaign_Planner.Parcelables;

namespace RPG_Campaign_Planner.Controllers {
	class NPCController{
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

		public NPCParcelable GetNPC(string name, string campaign) {
			List<string> results = new List<string>();
			var query = from npc in conn.Table<NPC>()
						where npc.Campaign.Equals(campaign) && npc.Name.Equals(name)
						select npc;

			NPCParcelable parcelable = new NPCParcelable();
			try {
				parcelable.NPC = query.SingleOrDefault();
				return parcelable;
			} catch {
				parcelable.NPC = query.FirstOrDefault();
				return parcelable;
			}
		}

		public string[] GetNPCNames(string campaign) {
			var query = from npc in conn.Table<NPC>()
						where npc.Campaign == campaign
						select npc.Name;
			if(query.Count() == 0) {
				return query.DefaultIfEmpty().ToArray();
			} else {
				return query.ToArray();
			}
		}

		public bool AddNPC(string name, string campaign, string appearence = null, string quote = null, string roleplay = null, string background = null, string info = null, string stats = null) {
			if (GetNPC(name, campaign).NPC != null) {
				return false;
			}

			NPC npc = new NPC();
			npc.Name = name;
			npc.Campaign = campaign;
			npc.Appearance = appearence;
			npc.Quote = quote;
			npc.Roleplaying = roleplay;
			npc.Background = background;
			npc.KeyInfo = info;
			npc.StatBlock = stats;

			int added = conn.Insert(npc);
			return added == 1;
		}
	}
}