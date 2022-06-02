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
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Text;


namespace Test_0
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText userName;
        EditText password;
        Button loginButton;

        public static IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
        public static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 

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

        private void Receiver()
        {
            byte[] buf = new byte[1024];
            String data;

            while (true)
            {
                socket.Receive(buf);
                data = Encoding.Unicode.GetString(buf);
                string mode = data.Substring(0, 3);
                string realdata = data.Substring(3);

                if (mode == null)
                {
                    //AbsSesdf(mode, realdata);
                }
            }
        }

        public static void DataBroadCast(byte[] mode, byte[] data)
        {
            byte[] temp = new byte[mode.Length + data.Length];
            Array.Copy(mode, 0, temp, 0, mode.Length);
            Array.Copy(data, 0, temp, mode.Length , data.Length);
            socket.Send(temp);
        }

        // https://www.c-sharpcorner.com/article/login-and-registration-functionality-in-xamarin-android/
        // 로그인
        private void LoginClicked(object sender, EventArgs e)
        {
            socket.Connect(ip);
            new Thread(Receiver).Start();

            DataBroadCast(Encoding.Unicode.GetBytes(userName.Text), Encoding.Unicode.GetBytes(password.Text));
            if (userName.Text == "이름" && password.Text == "12345")      // 임의로 사용자 이름과 비밀번호를 지정해줌(나중에 지우기)
            {
                // 로그인 성공 메시지
                Toast.MakeText(this, "Login successfully done!", ToastLength.Short).Show();

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
        //public override void OnBackPressed()
        //{
        //    Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);

        //    builder.SetPositiveButton("확인", (senderAlert, args) => {
        //        Finish();
        //    });

        //    builder.SetNegativeButton("취소", (senderAlert, args) => {
        //        return;
        //    });

        //    Android.App.AlertDialog alterDialog = builder.Create();
        //    alterDialog.SetTitle("알림");
        //    alterDialog.SetMessage("프로그램을 종료 하시겠습니까?");
        //    alterDialog.Show();
        //}


    }
}