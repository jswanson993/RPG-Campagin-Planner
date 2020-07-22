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
using System.Collections.Generic;

namespace RPG_Campaign_Planner {
	[Activity(Label = "ReferenceActivity", Theme = "@style/AppTheme.NoActionBar")]
	public class ReferenceActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener {
        private CampaignController campaignController;

		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            string campaignText = Intent.GetStringExtra("Selected Campaign") ?? "Data not available";
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

            campaignController = new CampaignController();
            string[] notes = campaignController.GetNotes(campaignController.GetConnection(), campaignText);
            if(notes[0] == null) {
                notes = new String[] { };
			}

            ListView listView = FindViewById<ListView>(Resource.Id.campaign_list);
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, notes);
            listView.Adapter = adapter;
            
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

        private void FabOnClick(object sender, EventArgs eventArgs) {
            
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

        private void DisplayGeneralNotes(string campaignText) {
            string[] notes;

            notes = campaignController.GetNotes(campaignController.GetConnection(), campaignText);
            foreach(string note in notes) {
			}
		}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}