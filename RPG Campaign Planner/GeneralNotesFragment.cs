using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Runtime.Hosting;

namespace RPG_Campaign_Planner {
	public class GeneralNotesFragment : Fragment {
		public int NoteID;
		
		

		public static GeneralNotesFragment NewInstance(int noteId) {
			var bundle = new Bundle();
			bundle.PutInt("current_note_id1", noteId);
			return new GeneralNotesFragment { Arguments = bundle };
		}

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
			if(container == null) {
				return null;
			}
			NoteID = Arguments.GetInt("current_note_id", 0);

			var listView = new ListView(Activity);
			var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
			listView.SetPadding(padding, padding, padding, padding);


			return base.OnCreateView(inflater, container, savedInstanceState);
		}
	}
}