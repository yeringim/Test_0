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



namespace Test_0
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);

            // 로그인 버튼 클릭하면 맵 화면으로 이동
            //FindViewById<Button>(Resource.Id.btnLogin).Click += (o, e) =>
            //SetContentView(Resource.Layout.activity_main);

            // 회원가입 버튼 클릭하면 회원가입 화면으로 이동
            FindViewById<Button>(Resource.Id.btnRegister).Click += (o, e) =>
            SetContentView(Resource.Layout.activity_register);

        }




        // http://son10001.blogspot.com/2017/03/xamarin-android.html
        // 뒤로가기 버튼으로 종료 막기
        public override void OnBackPressed()
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);

            builder.SetPositiveButton("확인", (senderAlert, args) => {
                Finish();
            });

            builder.SetNegativeButton("취소", (senderAlert, args) => {
                return;
            });

            Android.App.AlertDialog alterDialog = builder.Create();
            alterDialog.SetTitle("알림");
            alterDialog.SetMessage("프로그램을 종료 하시겠습니까?");
            alterDialog.Show();
        }
    }
}