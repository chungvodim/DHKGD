using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tearc.Entity.Main
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public string Gender { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public bool Consent { get; set; }
        public bool MarketingConsent { get; set; }

        public Enum.UserStatus UserStatus { get; set; }

        public int? CreatedUserID { get; set; }
        public int? UpdatedUserId { get; set; }
        [NotMapped]
        public bool IsImpersonated { get; set; }
        [NotMapped]
        public int ImpersonatorID { get; set; }
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
