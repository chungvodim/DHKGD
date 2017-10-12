using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tearc.Entity.Main
{
    public class User : IdentityUser
    {
    }

    public class CustomClaimTypes
    {
        public const string FirstName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/FirstName";
        public const string LastName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/LastName";
        public const string IsImpersonated = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/IsPersonated";
        public const string ImpersonatorID = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/ImpersonatorID";
        public const string Consent = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/ImpersonatorID";
    }
}
