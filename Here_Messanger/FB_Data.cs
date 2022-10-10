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
using Firebase;
using Firebase.Auth;

namespace Here_Messanger
{
    internal class FB_Data
    {
        private readonly FirebaseApp app;
        private readonly FirebaseAuth auth;

        public FB_Data()
        {
            app = FirebaseApp.InitializeApp(Application.Context);

            if(app is null)
            {
                FirebaseOptions options = GetMyOptions();
                app = FirebaseApp.InitializeApp(Application.Context, options);
            }

            auth = FirebaseAuth.Instance;
        }

        private FirebaseOptions GetMyOptions()
        {
            return new FirebaseOptions.Builder()
                .SetProjectId("here-messenger-d7e85")
                .SetApplicationId("here-messenger-d7e85")
                .SetApiKey("AIzaSyDtZ42miUkYWznW4re0g38L6aLn8UoBQ9o")
                .SetStorageBucket("here-messenger-d7e85.appspot.com")
                .Build();
        }

        public Android.Gms.Tasks.Task CreateUser(string email, string password)
        {
            return auth.CreateUserWithEmailAndPassword(email, password);
        }
        public Android.Gms.Tasks.Task SignIn(string email, string password)
        {
            return auth.SignInWithEmailAndPassword(email, password);
        }
        public Android.Gms.Tasks.Task ResetPassword(string email)
        {
            return auth.SendPasswordResetEmail(email);
        }
    }
}