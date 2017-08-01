using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Renderscripts;
using UK.CO.Chrisjenx.Calligraphy;
using Truii_App.Functions;
using static Android.Views.ViewGroup;

namespace Truii_App
{
    [Activity(Label = "LoginActivity", Theme = "@android:style/Theme.NoTitleBar.Fullscreen")]
    public class LoginActivity : Activity
    {
        EditText txtUsername;
        EditText txtPassword;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Login);
            FontFunction font = new FontFunction();
            txtUsername = FindViewById<EditText>(Resource.Id.txtUser);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            var btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += BtnLogin_Click;
            var btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += BtnRegister_Click;
            // Create your application here

        }
        protected override void AttachBaseContext(Context @base)
        {
            base.AttachBaseContext( CalligraphyContextWrapper.Wrap(@base));
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(RegistrationActivity)));
        }
    }
}