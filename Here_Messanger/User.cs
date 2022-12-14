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
    internal class User
    {
        string name, mail, pwd;
        bool exist;
        readonly SP_data spd;

        public User(string name, string mail, string pwd, bool exist)
        {
            this.name = name.Trim();
            this.mail = mail.Trim();
            this.pwd = pwd.Trim();
            this.exist = exist;
        }

        public string Name { get => name; set => name = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public bool Exist { get => exist; set => exist = value; }

        public User(Context ctx)
        {
            spd = new SP_data(ctx);
            this.Name = spd.GetStringValue(General.KEY_NAME);
            this.Exist = this.name != String.Empty;

            if (this.exist)
            {
                this.Mail = spd.GetStringValue(General.KEY_MAIL);
                this.Pwd = spd.GetStringValue(General.KEY_PWD);
            }
        }

        public bool Save()
        {
            bool success = spd.PutStringValue(General.KEY_NAME, this.Name);
            success = success && spd.PutStringValue(General.KEY_PWD, this.Pwd);
            return success && spd.PutStringValue(General.KEY_MAIL, this.Mail);
        }
    }
}