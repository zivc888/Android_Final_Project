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
    [Activity(Label = "GroupDescription_Activity")]
    public class GroupDescription_Activity : Activity
    {
        ImageView back;
        TextView group_name;
        Button leave;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GroupDescription_Screen);

            group_name = FindViewById<TextView>(Resource.Id.tv_name);
            group_name.Text = Intent.Extras.GetString("group_name");
            back = FindViewById<ImageView>(Resource.Id.img_back);
            leave = FindViewById<Button>(Resource.Id.btn_leave);

            back.Click += Back_Click;
            leave.Click += Leave_Click;
        }

        private void Leave_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Currently not working until full Firebase infrastructure is implemented.", ToastLength.Long).Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}