using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Location;
using Xamarin.Essentials;
using System;
using Android.Gms.Tasks;
using Android.Gms.Maps.Model;

namespace Test_0
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class RegisterActivity : AppCompatActivity
    {
        EditText userName;
        EditText password;
        Button registerButton;
        
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_register);

            userName = FindViewById<EditText>(Resource.Id.editText1);
            password = FindViewById<EditText>(Resource.Id.editText2);
            registerButton = FindViewById<Button>(Resource.Id.button1);

            registerButton.Click += RegisterClicked;


            // 회원가입 버튼 클릭하면 이전 화면으로 이동
            //FindViewById<Button>(Resource.Id.btnRegister).Click += (o, e) =>
            //SetContentView(Resource.Layout.activity_login);
        }


        // 회원가입
        private void RegisterClicked(object sender, EventArgs e)
        {
            
        }
    }
}