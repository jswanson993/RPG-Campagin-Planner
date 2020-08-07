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
using RPG_Campaign_Planner.Activities;
using System.Linq;
using Android.Content.PM;

namespace RPG_Campaign_Planner.Activities {
	[Activity(Label = "NPCActivity", Theme = "@style/AppTheme.NoActionBar")]
	public class NPCActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener {
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
            ISharedPreferences sharedprefs = GetSharedPreferences("prefs_file", FileCreationMode.Private);
            campaignText = sharedprefs.GetString("Campaign", null);

            ViewStub stub = FindViewById<ViewStub>(Resource.Id.layout_stub);
            stub.LayoutResource = Resource.Layout.activity_NPCs;
            View inflated = stub.Inflate();
        }

        private void FabOnClick(object sender, EventArgs eventArgs) {
            var intent = new Intent(this, typeof(AddNPCActivity ));
            StartActivity(intent);
        }

        public bool OnNavigationItemSelected(IMenuItem item) {
            int id = item.ItemId;

            if (id == Resource.Id.nav_notes) {
                var intent = new Intent(this, typeof(NotesActivity));
                intent.PutExtra("Selected Campaign", campaignText);
                intent.AddFlags(ActivityFlags.SingleTop);
                StartActivity(intent);
            } else if (id == Resource.Id.nav_npcs) {

            } else if (id == Resource.Id.nav_pcs) {

            } else if (id == Resource.Id.nav_locations) {

            } else if (id == Resource.Id.nav_factions) {

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
