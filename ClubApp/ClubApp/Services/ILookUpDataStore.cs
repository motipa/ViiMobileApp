using ClubApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Services
{
    public interface ILookupDataStore
    {
        Task<LookupModel<Guid>[]> GetBookingDetails();
      
    }
}
