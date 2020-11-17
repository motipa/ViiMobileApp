using System;
using System.Collections.Generic;
using System.Text;

namespace ClubApp.Services
{
   public interface IBookingStore
    {
      void  GetAssetsAsync(dynamic query);
    }
}
