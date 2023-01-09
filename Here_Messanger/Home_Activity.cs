using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Here_Messanger
{
    [Activity(Label = "Home_Activity")]
    public class Home_Activity : Activity
    {
        ImageView profile, search, settings;
        TextView name;
        User user;
        FB_Data fbd;
        LinearLayout group;
        Android.App.Dialog EditProfile;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home_Screen);

            fbd = new FB_Data();
            user = new User(this);

            profile = FindViewById<ImageView>(Resource.Id.img_profile);
            name = FindViewById<TextView>(Resource.Id.tv_name);
            name.Text = Intent.Extras.GetString(General.KEY_NAME);
            search = FindViewById<ImageView>(Resource.Id.img_search);
            settings = FindViewById<ImageView>(Resource.Id.img_settings);
            group = FindViewById<LinearLayout>(Resource.Id.layout_group1);

            group.Click += Group_Click;
            settings.Click += Settings_Click;
            search.Click += Search_Click;

            profile.Click += (object sender, EventArgs e) =>
            {
                EditProfile = new Android.App.Dialog(this);
                EditProfile.SetContentView(Resource.Layout.EditProfile_Dialog);
                EditProfile.SetTitle("Edit Profile Info");
                EditProfile.SetCancelable(true);
                EditText new_name = EditProfile.FindViewById<EditText>(Resource.Id.et_name);
                Button save = EditProfile.FindViewById<Button>(Resource.Id.btn_save);
                Button cancel = EditProfile.FindViewById<Button>(Resource.Id.btn_cancel);

                save.Click += (object sender, EventArgs e) =>
                {
                    if (new_name.Text == "") { Toast.MakeText(this, "error", ToastLength.Short).Show(); }
                    else
                    {
                        Toast.MakeText(this, "saved", ToastLength.Short).Show();
                        name.Text = new_name.Text;
                    }
                };

                cancel.Click += (object sender, EventArgs e) =>
                {
                    EditProfile.Hide();
                };
                EditProfile.Show();
            };

        }

        private void Search_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Currently not working until full Firebase infrastructure is implemented.", ToastLength.Long).Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Settings_Activity));
            i.PutExtra("name", name.Text);
            StartActivity(i);
        }

        private void Group_Click(object sender, EventArgs e)
        {
            TextView group_name = FindViewById<TextView>(Resource.Id.tv_group1_name);
            ImageView group_photo = FindViewById<ImageView>(Resource.Id.img_group1_photo);
            Intent i = new Intent(this, typeof(Group_Activity));
            i.PutExtra("group_name", group_name.Text);
            StartActivity(i);
        }

        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Utilities_Menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            Toast.MakeText(this, "you selected logout " + item.ItemId, ToastLength.Long);

            if (item.ItemId == Resource.Id.action_logout)
            {
                Toast.MakeText(this, "you selected logout", ToastLength.Long).Show();
                return true;

            }
            else if (item.ItemId == Resource.Id.action_register)
            {
                Toast.MakeText(this, "you selected register", ToastLength.Long).Show();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }


    }
}