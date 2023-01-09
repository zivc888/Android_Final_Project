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
    [Activity(Label = "Settings_Activity")]
    public class Settings_Activity : Activity
    {
        ImageView back;
        TextView name, lbl1, lbl2, lbl3, lbl4;
        Button group, contacts, sign_out;
        LinearLayout lbls;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Settings_Screen);

            back = FindViewById<ImageView>(Resource.Id.img_back);
            name = FindViewById<TextView>(Resource.Id.tv_name);
            lbl1 = FindViewById<TextView>(Resource.Id.tv_lbl1);
            lbl2 = FindViewById<TextView>(Resource.Id.tv_lbl2);
            lbl3 = FindViewById<TextView>(Resource.Id.tv_lbl3);
            lbl4 = FindViewById<TextView>(Resource.Id.tv_lbl4);
            group = FindViewById<Button>(Resource.Id.btn_addGroup);
            contacts = FindViewById<Button>(Resource.Id.btn_contacts);
            sign_out = FindViewById<Button>(Resource.Id.btn_signOut);
            lbls = FindViewById<LinearLayout>(Resource.Id.ll_lbls);

            sign_out.Click += Sign_out_Click;
            lbls.Click += Lbls_Click;
            back.Click += Back_Click;
            group.Click += Group_Click;
            contacts.Click += Contacts_Click;
        }

        private void Contacts_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Currently not working until full Firebase infrastructure is implemented.", ToastLength.Long).Show();
        }

        private void Group_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Currently not working until full Firebase infrastructure is implemented.", ToastLength.Long).Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Lbls_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Currently not working until full Firebase infrastructure is implemented.", ToastLength.Long).Show();
        }

        private void Sign_out_Click(object sender, EventArgs e)
        {
            Finish();
            Finish();
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }
    }
}