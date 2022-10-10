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
        ImageView profile;
        TextView name;
        User user;
        FB_Data fbd;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home_Screen);

            fbd = new FB_Data();
            user = new User(this);

            profile = FindViewById<ImageView>(Resource.Id.img_profile);
            name = FindViewById<TextView>(Resource.Id.tv_name);
            name.Text = user.Name;

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Layout.Toolbar);
            toolbar.InflateMenu(Resource.Menu.Utilities_Menu);
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