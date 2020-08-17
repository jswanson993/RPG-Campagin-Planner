using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using System.Security.Cryptography;
using RPG_Campaign_Planner.Controllers;
using models;
using Org.Json;
using RPG_Campaign_Planner.Parcelables;
using Org.Apache.Http.Impl.Client;

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
			if (container == null) {
				return null;
			}

			NPCController nc = new NPCController();
			NPCParcelable parcelable = nc.GetNPC(NPCName, CampaignName);

			var scroller = new ScrollView(Activity);
			var linearlayout = new LinearLayout(Activity);
			linearlayout.Orientation = Orientation.Vertical;

			var nameView = new TextView(Activity);
			var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 10, Activity.Resources.DisplayMetrics));
			nameView.SetPadding(padding, padding, padding, padding);
			nameView.TextSize = 30;
			 nameView.Text = parcelable.NPC.Name;
			nameView.TextAlignment = TextAlignment.Center;

			linearlayout.AddView(nameView);
			if (parcelable.NPC.Appearance != "") {

				var appearenceView = new TextView(Activity);
				appearenceView.SetPadding(padding, padding, padding, padding);
				appearenceView.TextSize = 20;
				appearenceView.Text = "Appearence";
				appearenceView.TextAlignment = TextAlignment.Center;

				linearlayout.AddView(appearenceView);

				var appearenceText = new TextView(Activity);
				appearenceText.SetPadding(padding, padding, padding, padding);
				appearenceText.TextSize = 15;
				appearenceText.Text = parcelable.NPC.Appearance;
				linearlayout.AddView(appearenceText);
			}

			if (parcelable.NPC.Quote != "") {

				var quoteView = new TextView(Activity);
				quoteView.SetPadding(padding, padding, padding, padding);
				quoteView.TextSize = 20;
				quoteView.Text = "Quote";
				quoteView.TextAlignment = TextAlignment.Center;

				linearlayout.AddView(quoteView);

				var quoteText = new TextView(Activity);
				quoteText.SetPadding(padding, padding, padding, padding);
				quoteText.TextSize = 15;
				quoteText.Text = parcelable.NPC.Quote;
				linearlayout.AddView(quoteText);
			}

			if (parcelable.NPC.Roleplaying != "") {

				var rolePlayingView = new TextView(Activity);
				rolePlayingView.SetPadding(padding, padding, padding, padding);
				rolePlayingView.TextSize = 20;
				rolePlayingView.Text = "Roleplay";
				rolePlayingView.TextAlignment = TextAlignment.Center;

				linearlayout.AddView(rolePlayingView);

				var rolePlayingText = new TextView(Activity);
				rolePlayingText.SetPadding(padding, padding, padding, padding);
				rolePlayingText.TextSize = 15;
				rolePlayingText.Text = parcelable.NPC.Roleplaying;
				linearlayout.AddView(rolePlayingText);
			}

			if (parcelable.NPC.Background != "") {

				var backgroundView = new TextView(Activity);
				backgroundView.SetPadding(padding, padding, padding, padding);
				backgroundView.TextSize = 20;
				backgroundView.Text = "Background";
				backgroundView.TextAlignment = TextAlignment.Center;

				linearlayout.AddView(backgroundView);

				var backgroundText = new TextView(Activity);
				backgroundText.SetPadding(padding, padding, padding, padding);
				backgroundText.TextSize = 15;
				backgroundText.Text = parcelable.NPC.Background;
				linearlayout.AddView(backgroundText);
			}

			if (parcelable.NPC.KeyInfo != "") {

				var keyInfoView = new TextView(Activity);
				keyInfoView.SetPadding(padding, padding, padding, padding);
				keyInfoView.TextSize = 20;
				keyInfoView.Text = "Key Info";
				keyInfoView.TextAlignment = TextAlignment.Center;

				linearlayout.AddView(keyInfoView);

				var keyInfoText = new TextView(Activity);
				keyInfoText.SetPadding(padding, padding, padding, padding);
				keyInfoText.TextSize = 15;
				keyInfoText.Text = parcelable.NPC.KeyInfo;
				linearlayout.AddView(keyInfoText);
			}

			if (parcelable.NPC.StatBlock != "") {

				var statBlockView = new TextView(Activity);
				statBlockView.SetPadding(padding, padding, padding, padding);
				statBlockView.TextSize = 20;
				statBlockView.Text = "Stats";
				statBlockView.TextAlignment = TextAlignment.Center;

				linearlayout.AddView(statBlockView);

				var statBlockText = new TextView(Activity);
				statBlockText.SetPadding(padding, padding, padding, padding);
				statBlockText.TextSize = 15;
				statBlockText.Text = parcelable.NPC.StatBlock;
				linearlayout.AddView(statBlockText);
			}


			scroller.AddView(linearlayout);
			return scroller;
		}

	}
	public class NPCObject{
		public string name { get; set; }
		public string appearence { get; set; }
		public string quote { get; set; }
		public string roleplaying { get; set; }
		public string background { get; set; }
		public string keyInfo { get; set; }
	}

	
}