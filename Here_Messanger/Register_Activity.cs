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
using System.Threading.Tasks;

namespace Here_Messanger
{
    [Activity(Label = "Register_Activity")]
    public class Register_Activity : Activity, IOnCompleteListener
    {
        EditText name, password, mail;
        Button register, cancel;
        TextView status;
        User user;
        FB_Data fbd;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Register_Screen);

            name = FindViewById<EditText>(Resource.Id.et_name);
            password = FindViewById<EditText>(Resource.Id.et_password);
            mail = FindViewById<EditText>(Resource.Id.et_mail);
            register = FindViewById<Button>(Resource.Id.btn_register);
            cancel = FindViewById<Button>(Resource.Id.btn_cancel);
            status = FindViewById<TextView>(Resource.Id.tv_status);

            fbd = new FB_Data();

            register.Click += Register_Click;
            cancel.Click += Cancel_Click;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            user = new User(name.Text, mail.Text, password.Text, false);
            if (user.Name != string.Empty && user.Mail != string.Empty && user.Pwd != string.Empty)
            {
                fbd.CreateUser(user.Mail, user.Pwd).AddOnCompleteListener(this);
            }
            else
            {
                Toast.MakeText(this, "Enter all values", ToastLength.Short).Show();
            }
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                Intent i = new Intent();
                i.PutExtra(General.KEY_NAME, user.Name);
                i.PutExtra(General.KEY_MAIL, user.Mail);
                i.PutExtra(General.KEY_PWD, user.Pwd);
                SetResult(Result.Ok, i);
                Finish();
            }
            else
            {
                status.Text = task.Exception.Message;
            }
        }
    }
}