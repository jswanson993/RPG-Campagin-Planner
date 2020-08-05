using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.RecyclerView.Extensions;
using Android.Util;
using Android.Views;
using Android.Widget;
using Controllers;
using models;
using RPG_Campaign_Planner.Activities;
using RPG_Campaign_Planner.Controllers;

namespace RPG_Campaign_Planner.Fragments {
	public class NPCNamesFragment : Android.Support.V4.App.ListFragment {
		string selectedNPC;
		string campaignName;
		public override void OnActivityCreated(Bundle savedInstanceState) {
			base.OnActivityCreated(savedInstanceState);
			campaignName = Arguments.GetString("Campaign");
			string[] names = getNPCs(campaignName);
			ListAdapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItemActivated1, names);

			if(savedInstanceState != null) {
				selectedNPC = savedInstanceState.GetString("current_NPC");
			}
		}

		public override void OnSaveInstanceState(Bundle outState) {
			base.OnSaveInstanceState(outState);
			outState.PutString("current_NPC", selectedNPC);
		}

		public override void OnListItemClick(ListView l, View v, int position, long id) {

			string name = (string)l.GetItemAtPosition(position);
			if (name != null) {
				ShowNPC(name);
			}
		}

		private void ShowNPC(string name) {
			var intent = new Intent(Activity, typeof(DisplayNPCActivity));
			intent.PutExtra("NPCName", selectedNPC);
			intent.PutExtra("Campaign", campaignName);
			StartActivity(intent);
		}

		private string[] getNPCs(string campaign) {
			NPCController nc = new NPCController();
			return nc.GetNPCNames(campaign);
		}
	}
}