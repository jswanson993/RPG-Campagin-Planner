using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using System.Security.Cryptography;

namespace RPG_Campaign_Planner.Fragments {
	public class DisplayNPCFragment : Android.Support.V4.App.Fragment {
		public string NPCName => Arguments.GetString("NPCName");
		public string CampaignName => Arguments.GetString("Campaign");
	
		public static DisplayNPCFragment NewInstance(string npcName, string campaignName) {
			var bundle = new Bundle();
			bundle.PutString("NPCName", npcName);
			bundle.PutString("Campaign", campaignName);
			return new DisplayNPCFragment { Arguments = bundle };
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

			var nameView = new TextView(Activity);
			var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
			nameView.SetPadding(padding, padding, padding, padding);
			nameView.TextSize = 50;
			nameView.Text = NPCName;

			var scroller = new ScrollView(Activity);
			scroller.AddView(nameView);
			return scroller;
		}
	}
}