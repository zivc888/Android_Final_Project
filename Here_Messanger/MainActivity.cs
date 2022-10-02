using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Threading.Tasks;

namespace Here_Messanger
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnCompleteListener
    {
        EditText mail, password;
        Button login, register, reset;
        TextView status;
        User user;
        FB_Data fbd;
        Task tskLogin, tskReset;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);


            SetContentView(Resource.Layout.activity_main);


            mail = FindViewById<EditText>(Resource.Id.et_mail);
            password = FindViewById<EditText>(Resource.Id.et_password);
            login = FindViewById<Button>(Resource.Id.btn_login);
            register = FindViewById<Button>(Resource.Id.btn_register);
            reset = FindViewById<Button>(Resource.Id.btn_rst);
            status = FindViewById<TextView>(Resource.Id.tv_status);

            fbd = new FB_Data();
            user = new User(this);

            login.Click += Login_Click;
            register.Click += Register_Click;
            reset.Click += Reset_Click;

            if (user.Exist)
            {
                ShowUserData();
            }
            else
            {
                OpenRegisterActivity();
            }
        }

        private void ShowUserData()
        {
            mail.Text = user.Mail;
            password.Text = user.Pwd;
        }

        private void OpenRegisterActivity()
        {
            Intent i = new Intent(this, typeof(Register_Activity));
            StartActivityForResult(i, General.REQUEST_REGISTER);
        }

        private void Reset_Click(object sender, System.EventArgs e)
        {
            tskReset = fbd.ResetPassword(user.Mail);
            tskReset.AddOnCompleteListener(this);
        }

        private void Register_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(Register_Activity));
            StartActivityForResult(i, General.REQUEST_REGISTER);
        }

        private void Login_Click(object sender, System.EventArgs e)
        {
            if (password.Text != string.Empty)
            {
                tskLogin = fbd.SignIn(mail.Text, password.Text);
                tskLogin.AddOnCompleteListener(this);

                user.Pwd = password.Text;
                if (!user.Save())
                {
                    Toast.MakeText(this, "Error", ToastLength.Long).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Enter Password", ToastLength.Long).Show();
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == General.REQUEST_REGISTER)
            {
                if (resultCode == Result.Ok)
                {
                    user.Name = data.GetStringExtra(General.KEY_NAME);
                    user.Mail = data.GetStringExtra(General.KEY_MAIL);
                    user.Pwd = data.GetStringExtra(General.KEY_PWD);

                    ShowUserData();
                }
            }
        }

        public void OnComplete(Task task)
        {
            string msg = string.Empty;
            if (task.IsSuccessful)
            {
                if (task == tskLogin)
                {
                    msg = "Login Successful";
                }
                else if (task == tskReset)
                {
                    msg = "Reset Successful";
                }
            }
            else
                msg = task.Exception.Message;
            status.Text = msg;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}