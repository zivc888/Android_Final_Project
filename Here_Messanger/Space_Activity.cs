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
    [Activity(Label = "Space_Activity")]
    public class Space_Activity : Activity
    {
        TextView group_name;
        Button chat, space;
        ImageView back, info, file;
        Android.App.Dialog EditGroup;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Space_Screen);

            group_name = FindViewById<TextView>(Resource.Id.tv_name);
            group_name.Text = Intent.Extras.GetString("group_name");
            chat = FindViewById<Button>(Resource.Id.btn_chat);
            space = FindViewById<Button>(Resource.Id.btn_space);
            back = FindViewById<ImageView>(Resource.Id.img_back);
            info = FindViewById<ImageView>(Resource.Id.img_info);
            file = FindViewById<ImageView>(Resource.Id.img_file);

            chat.Click += Chat_Click;
            back.Click += Back_Click;
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
            file.Click += File_Click;
        }

        private void File_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Currently not working until API infrastructure is implemented.", ToastLength.Long).Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Chat_Click(object sender, EventArgs e)
        {
            Finish();
            Intent i = new Intent(this, typeof(Group_Activity));
            i.PutExtra("group_name", group_name.Text);
            StartActivity(i);
        }
    }
}