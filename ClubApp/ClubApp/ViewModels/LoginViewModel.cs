using ClubApp.Helper;
using ClubApp.Models;
using ClubApp.Models.Auth;
using ClubApp.Services;
using ClubApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClubApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private Page _page;
        public LoginModel LoginModel { get; set; } = new LoginModel();
        public LoginService _apiServices;
      
        public LoginViewModel(Page page)
        {
            _page = page;
            Title = "Login";

        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
        public ICommand LoginCommand
        {

            get
            {
                return new Command(async () =>
                {

                    if (IsBusy)
                    {
                        return;
                    }
                    _apiServices = new LoginService();
                     AuthorizationModel       authorization = new AuthorizationModel();
                    authorization.Login = LoginModel.Username;
                    authorization.Password = LoginModel.Password;
                    authorization.AuthorizationType = "credentials";
                    authorization.Client = "app";
                    authorization.ClientSecret = "123";
                    authorization.RefreshToken= "string";
                      authorization.ApplicationId = new Guid();
                          authorization.TenantId= new Guid();
  authorization.ListenerServiceName= "string";
 authorization.IntegrationPartnerName = "string";
                    authorization.IntegrationPartnerSecret = "string";

                    // if(_page !=null)
                    // if (!ValidationHelper.IsFormValid(LoginModel, _page)) { return; }

                    if (LoginModel.Username != null && LoginModel.Password != null)
                    {

                        Settings.UserName = LoginModel.Username;

                        IsBusy = true;
                        try
                        {
                              var res = await _apiServices.LoginAsync(authorization);

                            if (res.AccessToken != string.Empty)
                            {






                             
                                Settings.AccessToken = res.AccessToken;
                                Settings.RefreshToken = res.RefreshToken;

                                var datenow = DateTime.UtcNow;
                                Settings.AccessTokenExpirationDate = DateTime.UtcNow.AddMinutes(8);
                                Debug.Write(res.AccessToken + "/------------------------------Access Token");

                                Application.Current.MainPage = new AboutPage();



                            }
                            else
                            {
                                LoginPage login = new LoginPage();
                                Application.Current.MainPage = login;
                                
                                Debug.Assert(false, "Somehing went wrong. Please try again.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Write("Exception generated while login");
                            Application.Current.MainPage = new LoginPage();
                            Debug.Assert(false, "generate exception");
                        }
                    }


                    else
                    {

                        LoginPage login = new LoginPage();
                        Application.Current.MainPage = login;

                        Application.Current.MainPage = login;
                       
                        Debug.Assert(false, "Session Expired");


                    }
                });
            }
        }
    }
}
