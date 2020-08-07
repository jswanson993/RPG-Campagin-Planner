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
using models;
using RPG_Campaign_Planner.Controllers;

namespace RPG_Campaign_Planner {
	[Activity(Label = "AddNPCActivity")]
	public class AddNPCActivity : Activity {
		string campaignText;
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_add_npc);
			ISharedPreferences sharedprefs = GetSharedPreferences("prefs_file", FileCreationMode.Private);
			campaignText = sharedprefs.GetString("Campaign", null);

			Button subButton = FindViewById<Button>(Resource.Id.buttonSubmitNPC);
			subButton.Click += submitOnClick;
		}
		private void submitOnClick(object sender, EventArgs args) {
			EditText name = FindViewById<EditText>(Resource.Id.editName);
			EditText appearence = FindViewById<EditText>(Resource.Id.editAppearence);
			EditText quote = FindViewById<EditText>(Resource.Id.editQuote);
			EditText roleplaying = FindViewById<EditText>(Resource.Id.editRoleplay);
			EditText background = FindViewById<EditText>(Resource.Id.editBackground);
			EditText keyInfo = FindViewById<EditText>(Resource.Id.editInfo);
			EditText stats = FindViewById<EditText>(Resource.Id.editStats);

			string nameText = name.Text;
			string appearenceText = appearence.Text;
			string quoteText = quote.Text;
			string roleText = roleplaying.Text;
			string backText = background.Text;
			string infoText = keyInfo.Text;
			string statsText = stats.Text;
			NPCController nc = new NPCController();
			nc.AddNPC(nameText, campaignText, appearenceText, quoteText, roleText, backText, infoText, statsText);
			Finish();
		}
	}
}