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
    [Activity(Label = "RegisterActivity", Theme = "@android:style/Theme.NoTitleBar.Fullscreen")]
    public class RegistrationActivity : Activity
    {
        EditText txtEmail;
        EditText txtPassword;
        EditText txtConfirmPassword;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //You do not need to touch the font part
            FontFunction font = new FontFunction();
            SetContentView(Resource.Layout.Registration);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            txtConfirmPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            var btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += BtnRegister_Click;
            // Create your application here
            
        }
        protected override void AttachBaseContext(Context @base)
        {
            base.AttachBaseContext( CalligraphyContextWrapper.Wrap(@base));
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}