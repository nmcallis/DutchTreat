using Microsoft.AspNetCore.Identity;

namespace DutchTreat.Data.Entities
{
    public class StoreUser : IdentityUser
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
    }
}
