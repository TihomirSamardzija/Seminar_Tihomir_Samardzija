using Microsoft.AspNetCore.Identity;
using Seminar_Tihomir_Samardzija.Models;
using Seminar_Tihomir_Samardzija.Models.Dbo;
using Seminar_Tihomir_Samardzija.Services.Interface;

namespace Seminar_Tihomir_Samardzija.Services.Implementation
{
    public class IdentityService : IIdentityService
    {

        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public IdentityService(IServiceScopeFactory scopeFactory)
        {

            using (var scope = scopeFactory.CreateScope())
            {
                this.userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                this.roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


                CreateRoleAsync(Roles.Admin).Wait();
                CreateRoleAsync(Roles.BasicUser).Wait();


                CreateUserAsync(new ApplicationUser
                {
                    Firstname = "Ivan",
                    Lastname = "Ivic",
                    Email = "ivan@domena.com",
                    UserName = "ivan@domena.com",
                    DOB = DateTime.Now.AddYears(-30),
                    PhoneNumber = "+3859912345678",
                    //Adress = new List<Adress>
                    //{
                    //    new Adress
                    //    {
                    //        City = "Pozega",
                    //        Street = "Glavna",
                    //    }
                    //}

                }, "Pa$$word123", Roles.Admin).Wait();

                CreateUserAsync(new ApplicationUser
                {
                    Firstname = "Pero",
                    Lastname = "Peric",
                    Email = "pero@domena.com",
                    UserName = "pero@domena.com",
                    DOB = DateTime.Now.AddYears(-45),
                    PhoneNumber = "+3859812345678",
                    //Adress = new List<Adress>
                    //{
                    //    new Adress
                    //    {
                    //        City = "Pozega",
                    //        Street = "Obilaznica",
                    //    }
                    //}

                }, "Pa$$word12345", Roles.BasicUser).Wait();
            }


        }


        public async Task CreateRoleAsync(string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = role

                });
            }

        }


        public async Task CreateUserAsync(ApplicationUser user, string password, string role)
        {

            //Prvo provjeri ima li korisnika sa istim emailom u bazi
            var find = await userManager.FindByEmailAsync(user.Email);
            if (find != null)
            {
                return;
            }


            user.EmailConfirmed = true;
            //Izraditi novog korisnika
            var createdUser = await userManager.CreateAsync(user, password);
            //Provjeriti jeli korisnik uspješno dodan
            if (createdUser.Succeeded)
            {
                //Dodati korisnika u rolu
                var userAddedToRole = await userManager.AddToRoleAsync(user, role);
                if (!userAddedToRole.Succeeded)
                {
                    throw new Exception("Korisnik nije dodan u rolu!");
                }
            }
        }
    }
}
