using System;
using System.IO;
using SQLite;
using models;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace Controllers {
	class GeneralNotesController {
		private SQLiteConnection conn;

		public GeneralNotesController(string path = null, SQLiteConnection conn = null) {
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

		public String GetNote(string camp, string note) {
			var query = from n in conn.Table<Notes>()
						where n.Campaign == camp && n.Note == note
						select n.Note;
			if(query.Count() == 0) {
				return query.DefaultIfEmpty().ToString();
			} else {
				return query.SingleOrDefault().ToString();
			}
		}

		public String[] GetNotes(string camp) {
			var query = from n in conn.Table<Notes>()
						where n.Campaign == camp
						select n.Note;
			if(query.Count() == 0) {
				return query.DefaultIfEmpty().ToArray();
			} else {
				return query.ToArray();
			}
		}

		public bool AddNote(string camp, string note) {
			if(GetNote(camp, note).Equals(note)) {
				return false;
			}
			int added;
			Notes newNote = new Notes();
			newNote.Campaign = camp;
			newNote.Note = note;
			added = conn.Insert(newNote);
			return added > 0;
		}
		
	}
}