using ClubApp.Helper;
using ClubApp.Services;
using ClubApp.Views;
using Flurl.Http;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClubApp
{
    public partial class App : Application
    {
        public static string AzureBackendUrl =
  
#if DEBUG

  DeviceInfo.Platform == DevicePlatform.Android ? "https://localhost:44304" : "https://localhost:44304";

#else
 DeviceInfo.Platform == DevicePlatform.Android? "https://indagoapi.azurewebsites.net" : "https://indago-api.ep360.net";

#endif

     
        public App()
        {
            FlurlHttp.ConfigureClient("https://localhost:44304/", cli => cli.Settings.HttpClientFactory = new UntrustedCertClientFactory());
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
