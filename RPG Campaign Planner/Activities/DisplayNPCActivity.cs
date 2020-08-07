using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using RPG_Campaign_Planner.Fragments;

namespace RPG_Campaign_Planner.Activities {
	[Activity(Label = "DisplayNPCActivity")]
	public class DisplayNPCActivity : Android.Support.V4.App.FragmentActivity {
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			var npcName = Intent.Extras.GetString("NPCName");
			ISharedPreferences sharedprefs = GetSharedPreferences("prefs_file", FileCreationMode.Private);
			string campaignText = sharedprefs.GetString("Campaign", null);

			var detailsFrag = DisplayNPCFragment.NewInstance(npcName, campaignText);

			SupportFragmentManager.BeginTransaction().Add(Android.Resource.Id.Content, detailsFrag).Commit();
		}
	}
}