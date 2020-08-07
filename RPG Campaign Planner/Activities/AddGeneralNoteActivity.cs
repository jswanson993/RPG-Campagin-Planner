using System;
using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Graphics;
using Android.Widget;
using static Android.App.ActionBar;
using Controllers;
using Android.Content;
using Android.Text;
using Android.Views.Autofill;
using System.Text.RegularExpressions;
using models;
using Java.IO;
using Android.Support.V7.RecyclerView.Extensions;
using System.Collections.Generic;
using Android.Support.V7.View.Menu;
using System.Security.Cryptography;
using Android.Util;
using System.Runtime.CompilerServices;

namespace RPG_Campaign_Planner.Activities {
	[Activity(Label = "AddGeneralNoteActivity")]
	public class AddGeneralNoteActivity : Activity {
		private string campaignText;
		private string existingNote;

		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			SetContentView( Resource.Layout.activity_add_note);

			ISharedPreferences sharedprefs = GetSharedPreferences("prefs_file", FileCreationMode.Private);
			campaignText = sharedprefs.GetString("Campaign", null);
			existingNote = Intent.GetStringExtra("Current Note") ?? "";
			EditText text = FindViewById<EditText>(Resource.Id.edit_notes);
			Button subButton = FindViewById<Button>(Resource.Id.submit_note_button);
			subButton.Click += submitOnClick;

			if(!existingNote.Equals("")) {
				text.Text = existingNote;
			}
		}

		private void submitOnClick(object sender, EventArgs args) {
			EditText text = FindViewById<EditText>(Resource.Id.edit_notes);
			GeneralNotesController gc = new GeneralNotesController();
			gc.AddNote(campaignText, text.Text);
			Finish();
		}
	}
}