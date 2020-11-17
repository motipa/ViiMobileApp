using ClubApp.Models;
using ClubApp.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Services
{
    interface ILogin
    {
        Task<AuthorizationResponseModel> LoginAsync(AuthorizationModel authorization);
    }
}
