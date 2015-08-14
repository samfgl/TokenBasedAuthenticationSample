using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokenBasedAuthenticationSample.Models;
using System.Threading.Tasks;

namespace TokenBasedAuthenticationSample.Services
{
    public class DummyUserStore : IUserStore<AppUser>, IUserPasswordStore<AppUser>
    {
        public Task CreateAsync(AppUser user)
        {
            return Task.FromResult(0);
        }

        public Task DeleteAsync(AppUser user)
        {
            return Task.FromResult(0);
        }

        public void Dispose()
        {
            
        }

        public Task<AppUser> FindByIdAsync(string userId)
        {
            return Task.Factory.StartNew(() => new AppUser { Id = userId, UserName = userId + "Name" });
        }

        public Task<AppUser> FindByNameAsync(string userName)
        {
            return Task.Factory.StartNew(() => new AppUser { Id = userName.Replace("Name", ""), UserName = userName });
        }

        public Task<string> GetPasswordHashAsync(AppUser user)
        {
            return Task.Factory.StartNew(() => user.Id.GetHashCode().ToString());
        }

        public Task<bool> HasPasswordAsync(AppUser user)
        {
            return Task.Factory.StartNew(() => true);
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash)
        {
            return Task.FromResult(0);
        }

        public Task UpdateAsync(AppUser user)
        {
            return Task.FromResult(0);
        }
    }
}