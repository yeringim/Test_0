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
    public class MainActivity : AppCompatActivity
    {
        EditText userName;
        EditText password;
        Button loginButton;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            userName = FindViewById<EditText>(Resource.Id.editUsername);
            password = FindViewById<EditText>(Resource.Id.editPassword);
            loginButton = FindViewById<Button>(Resource.Id.btnLogin);

            loginButton.Click += LoginClicked;

            // 회원가입 버튼 클릭하면 회원가입 화면으로 이동
            FindViewById<Button>(Resource.Id.btnRegister).Click += (o, e) =>
            SetContentView(Resource.Layout.activity_register);
        }


        //DB 사용 https://junseo-studybook.tistory.com/24



        // https://www.c-sharpcorner.com/article/login-and-registration-functionality-in-xamarin-android/
        // 로그인
        private void LoginClicked(object sender, EventArgs e)
        {
            if (userName.Text == "이름" && password.Text == "12345")
            {
                // 로그인 성공 메시지
                Toast.MakeText(this, "Login successfully done!", ToastLength.Long).Show();

                // 성공 -> 맵 화면으로 전환
                SetContentView(Resource.Layout.activity_main);
            }
            else
            {
                // 로그인 실패  메시지
                Toast.MakeText(this, "Wrong credentials found!", ToastLength.Long).Show();
            }
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