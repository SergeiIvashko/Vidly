using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VidlyNew.Models;

namespace VidlyNew.Data
{
    public static class SeedData
    {
        private static readonly IdentityUser admin = AdminProfile();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider, string userPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                await EnsureUser(serviceProvider, userPw);
                await EnsureRole(serviceProvider);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider, string userPw)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByEmailAsync(admin.Email);
            if (user == null)
            {
                await userManager.CreateAsync(admin, userPw);
            }

            if (user == null)
            {
                throw new ArgumentNullException("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static IdentityUser AdminProfile()
        {
            return new IdentityUser
            {
                UserName = "admin@vidly.com",
                Email = "admin@vidly.com",
                EmailConfirmed = true
            };
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new ArgumentNullException($"{nameof(roleManager)} is null.");
            }

            IdentityResult IR;

            var role = await roleManager.FindByNameAsync(RoleName.Admin);
            if (role == null)
            {
                IR = await roleManager.CreateAsync(new IdentityRole(RoleName.Admin));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            if (userManager == null)
            {
                throw new ArgumentNullException($"{nameof(userManager)} is null");
            }

            var user = await userManager.FindByEmailAsync(admin.Email);

            if (user == null)
            {
                throw new ArgumentNullException($"The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, RoleName.Admin);

            return IR;
        }
        #endregion
    }
}
#pragma warning restore CS8602 // Dereference of a possibly null reference.