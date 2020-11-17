using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Helper
{
   public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }
      
        public static string Password
        {
            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Password), value);
        }
        public static string AccessToken
        {
            get => AppSettings.GetValueOrDefault(nameof(AccessToken), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(AccessToken), value);
        }
        
        public static string RefreshToken
        {
            get => AppSettings.GetValueOrDefault(nameof(RefreshToken), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(RefreshToken), value);
        }
        public static DateTime AccessTokenExpirationDate
        {
            get => AppSettings.GetValueOrDefault(nameof(AccessTokenExpirationDate), DateTime.Now);
            set => AppSettings.AddOrUpdateValue(nameof(AccessTokenExpirationDate), value);
        }
    }
}
