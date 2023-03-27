using Entities;
using Microsoft.AspNetCore.Identity;
using Repository;

namespace Inclusive.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services) {
            var builder = services.AddIdentity<User, IdentityRole>(opt => {
                opt.Password.RequiredLength = 5;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }
    }
}
