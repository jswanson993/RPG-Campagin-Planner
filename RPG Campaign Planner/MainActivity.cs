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

namespace RPG_Campaign_Planner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private CampaignController cc;
        private Button btnPopupCancel;
        private Button btnPopupOk;
        private Dialog popupDialog;
        private AutoCompleteTextView txtCampaignName;
        private ArrayAdapter<string> adapter;
        private List<string> camps;
        private ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
           
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            cc = new CampaignController();
            cc.CreateDatabase(cc.GetConnection());

            camps = GetExistingCampaigns();
            if(camps[0] == null) {
                camps = new List<string>();
			}
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, camps);
            listView = FindViewById<ListView>(Resource.Id.campaign_list);
            listView.Adapter = adapter;

            listView.TextFilterEnabled = true;

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                /*
                var intent = new Intent(this, typeof(ReferenceActivity));
                intent.PutExtra("Selected Campaign", txtTag.Text);
                intent.PutExtra("Campaign Controller", cc);
                StartActivity(intent);
                */
                var intent = new Intent(this, typeof(ReferenceActivity));
                intent.PutExtra("Selected Campaign", ((TextView)args.View).Text);
                StartActivity(intent);
            };

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            popupDialog = new Dialog(this);
            popupDialog.SetContentView(Resource.Layout.new_campaign_popup);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();

            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.Transparent);

            // Access Popup layout fields like below  
            btnPopupCancel = popupDialog.FindViewById<Button>(Resource.Id.btnCancel);
            btnPopupOk = popupDialog.FindViewById<Button>(Resource.Id.btnOk);
            txtCampaignName = popupDialog.FindViewById<AutoCompleteTextView>(Resource.Id.autocomplete);

            // Events for that popup layout  
            btnPopupCancel.Click += BtnPopupCancel_Click;
            btnPopupOk.Click += BtnPopOk_Click;
        }


        private void BtnPopOk_Click(object sender, EventArgs e) {
            if (txtCampaignName.Text.Length == 0) {
                View view = (View)sender;
                Snackbar.Make(view, "Must Enter a name", Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();

            } else {
                View view = (View)sender;
                if (cc.AddCampaign(cc.GetConnection(), txtCampaignName.Text)) {
                    adapter.Add(txtCampaignName.Text.ToString());
                    adapter.NotifyDataSetChanged();
                    popupDialog.Dismiss();
                    popupDialog.Hide();
                } else {
                    Snackbar.Make(view, "Campaign Already Exists", Snackbar.LengthShort)
                        .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
                }
            }
        }

        private void BtnPopupCancel_Click(object sender, EventArgs e) {
            popupDialog.Dismiss();
            popupDialog.Hide();
        }

        private List<string> GetExistingCampaigns() {
            return new List<string>(cc.GetCampaigns(cc.GetConnection()));
        }
		



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

