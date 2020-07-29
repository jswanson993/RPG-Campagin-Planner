﻿using System;
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
using RPG_Campaign_Planner.Activities;
using System.Linq;


namespace RPG_Campaign_Planner {
	[Activity(Label = "General Notes", Theme = "@style/AppTheme.NoActionBar")]
	public class NotesActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener {
        string campaignText;
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_ref);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            campaignText = Intent.GetStringExtra("Selected Campaign") ?? "Data not available";

            ViewStub stub = FindViewById<ViewStub>(Resource.Id.layout_stub);
            stub.LayoutResource = Resource.Layout.content_main;
            View inflated = stub.Inflate();

            GeneralNotesController gc = new GeneralNotesController();

            List<String> notes = new List<String>(gc.GetNotes(campaignText));
            if (notes[0] == null) {
                notes = new List<string>();
            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, notes);
            ListView listView = new ListView(this);
            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, this.Resources.DisplayMetrics));
            listView.SetPadding(padding, padding, padding, padding);

            listView.Adapter = adapter;

            listView.TextFilterEnabled = true;

            LinearLayout ll = FindViewById<LinearLayout>(Resource.Id.main_content_layout);
            ll.AddView(listView);   
        }

        public override void OnBackPressed() {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start)) {
                drawer.CloseDrawer(GravityCompat.Start);
            } else {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu) {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings) {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

		protected override void OnResume() {
			base.OnResume();
            System.Console.WriteLine("Test");
		}

		private void FabOnClick(object sender, EventArgs eventArgs) {
            var intent = new Intent(this, typeof(AddGeneralNoteActivity));
            intent.PutExtra("Selected Campaign", campaignText);
            StartActivity(intent);
        }

        public bool OnNavigationItemSelected(IMenuItem item) {
            int id = item.ItemId;

            if (id == Resource.Id.nav_camera) {
                // Handle the camera action
            } else if (id == Resource.Id.nav_gallery) {

            } else if (id == Resource.Id.nav_slideshow) {

            } else if (id == Resource.Id.nav_manage) {

            } else if (id == Resource.Id.nav_share) {

            } else if (id == Resource.Id.nav_send) {

            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}