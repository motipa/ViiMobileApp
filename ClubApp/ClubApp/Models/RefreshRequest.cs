using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Models
{
   public class RefreshRequest
    {
        public string AuthorizationType { get; set; }



        public string RefreshToken { get; set; }
    }
}
