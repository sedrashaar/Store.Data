using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.IdentityEntities;


namespace Store.Repository
{
    public class StoreIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Sedra Abdelrahman",
                    Email = "sedra.shaar29@gmail.com",
                    UserName = "Sedra",
                    Address = new Address
                    {
                        FirstName = "Sedra",
                        LastName = "Abdelrahman",
                        City = " October",
                        State = "Cairo",
                        Street = "45",
                        PostalCode = "123456"
                    },
                };
                await userManager.CreateAsync(user, "Password123!");
            }
        }
           
    }
}
