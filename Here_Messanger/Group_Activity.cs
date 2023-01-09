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
    [Activity(Label = "Group_Activity")]
    public class Group_Activity : Activity
    {
        TextView group_name;
        ImageView group_image, back, info, file, send;
        Android.App.Dialog EditGroup;
        Button chat, space;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Group_Screen);

            group_name = FindViewById<TextView>(Resource.Id.tv_name);
            group_name.Text = Intent.Extras.GetString("group_name");
            group_image = FindViewById<ImageView>(Resource.Id.img_profile);
            back = FindViewById<ImageView>(Resource.Id.img_back);
            info = FindViewById<ImageView>(Resource.Id.img_info);
            file = FindViewById<ImageView>(Resource.Id.img_file);
            send = FindViewById<ImageView>(Resource.Id.img_send);
            chat = FindViewById<Button>(Resource.Id.btn_chat);
            space = FindViewById<Button>(Resource.Id.btn_space);

            group_name.Click += Group_name_Click;
            info.Click += (object sender, EventArgs e) =>
            {
                EditGroup = new Android.App.Dialog(this);
                EditGroup.SetContentView(Resource.Layout.EditGroup_Dialog);
                EditGroup.SetTitle("Edit Group Info");
                EditGroup.SetCancelable(true);
                EditText new_name = EditGroup.FindViewById<EditText>(Resource.Id.et_name);
                Button save = EditGroup.FindViewById<Button>(Resource.Id.btn_save);
                Button cancel = EditGroup.FindViewById<Button>(Resource.Id.btn_cancel);

                save.Click += (object sender, EventArgs e) =>
                {
                    if (new_name.Text == "") { Toast.MakeText(this, "error", ToastLength.Short).Show(); }
                    else
                    {
                        Toast.MakeText(this, "saved", ToastLength.Short).Show();
                        group_name.Text = new_name.Text;
                        EditGroup.Hide();
                    }
                };

                cancel.Click += (object sender, EventArgs e) =>
                {
                    EditGroup.Hide();
                };
                EditGroup.Show();
            };
            space.Click += Space_Click;
            back.Click += Back_Click;

            send.Click += Send_Click;
            file.Click += File_Click;
        }

        private void File_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Currently not working until full Firebase infrastructure is implemented.", ToastLength.Long).Show();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Currently not working until full Firebase infrastructure is implemented.", ToastLength.Long).Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Space_Click(object sender, EventArgs e)
        {
            Finish();
            Intent i = new Intent(this, typeof(Space_Activity));
            i.PutExtra("group_name", group_name.Text);
            StartActivity(i);
        }

        private void Group_name_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(GroupDescription_Activity));
            i.PutExtra("group_name", group_name.Text);
            StartActivity(i);
        }
    }
}