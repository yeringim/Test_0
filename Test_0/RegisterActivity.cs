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

    public class RegisterActivity : AppCompatActivity
    {
        EditText userName;
        EditText password;
        Button registerButton;

        public static IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
        public static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_register);

            userName = FindViewById<EditText>(Resource.Id.editText1);
            password = FindViewById<EditText>(Resource.Id.editText2);
            registerButton = FindViewById<Button>(Resource.Id.button1);

            registerButton.Click += RegisterClicked;
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
            Array.Copy(data, 0, temp, mode.Length, data.Length);
            socket.Send(temp);
        }

        // 회원가입
        private void RegisterClicked(object sender, EventArgs e)
        {
            socket.Connect(ip);
            new Thread(Receiver).Start();

            DataBroadCast(Encoding.Unicode.GetBytes(userName.Text), Encoding.Unicode.GetBytes(password.Text));
        }
    }
}