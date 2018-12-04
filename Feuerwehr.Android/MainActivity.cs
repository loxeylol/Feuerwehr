using System;
using System.IO;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;



namespace Feuerwehr.Droid
{
    [Activity(Label = "Feuerwehr", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            string fileName = "feuerwehr_db.sqlite";
            string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string full_path = Path.Combine(fileLocation, fileName);

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
           
            Xamarin.FormsMaps.Init(this, savedInstanceState);

            RequestPermissions(new string[]
            {
                "ACCES_FINE_LOCATION",
                "ACCESS_COARSE_LOCATION",
                "ACCESS_LOCATION_EXTRA_COMMANDS",
                "ACCESS_MOCK_LOCATION",
                "ACCESS_NETWORK_STATE",
                "ACCESS_WIFI_STATE",
                "INTERNET"
            }, 1);

            LoadApplication(new App(full_path));
        }
    }
}