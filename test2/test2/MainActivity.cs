using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;

namespace test2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button cmBtn, celsiusBtn, dolarsBtn;
        EditText metersValue, farenheitValue, pesosValue;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main);
            cmBtn = FindViewById<Button>(Resource.Id.cmBtn);
            celsiusBtn = FindViewById<Button>(Resource.Id.celsiusBtn);
            dolarsBtn = FindViewById<Button>(Resource.Id.dolarsBtn);

            metersValue = FindViewById<EditText>(Resource.Id.metersValue);
            farenheitValue = FindViewById<EditText>(Resource.Id.farenheitValue);
            pesosValue = FindViewById<EditText>(Resource.Id.pesosValue);

            cmBtn.Click += CmBtn_Click;
            celsiusBtn.Click += CelsiusBtn_Click;
            dolarsBtn.Click += DolarsBtn_Click;
        }

        private void DolarsBtn_Click(object sender, System.EventArgs e)
        {
            decimal dolars = decimal.Parse(pesosValue.Text);
            dolars = dolars / 20;
            pesosValue.Text = dolars.ToString();
        }

        private void CelsiusBtn_Click(object sender, System.EventArgs e)
        {
            decimal celsius = decimal.Parse(farenheitValue.Text);
            celsius = (celsius - 32) * 5 / 9;
            farenheitValue.Text = celsius.ToString();
        }

        private void CmBtn_Click(object sender, System.EventArgs e)
        {
            decimal cm = decimal.Parse(metersValue.Text);
            cm = cm * 100;
            metersValue.Text = cm.ToString();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}