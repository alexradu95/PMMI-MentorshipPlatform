using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Siemens.MP.Data;
using Siemens.MP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Areas.Identity
{
    public class IdentityUtilsService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context = null;

        public IdentityUtilsService(ApplicationDbContext _context, IHttpContextAccessor httpContextAccessor, UserManager<UserInfo> userManager)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._context = _context;

        }

        public UserInfo GetCurrentUserAwaited()
        {
            UserInfo user = _context.Users.Single(x => x.Email == _httpContextAccessor.HttpContext.User.Identity.Name);
            return user;
        }

        public string GetCurrentUserID()
        {
            UserInfo user = GetCurrentUserAwaited();
            return user.Id;
        }

        public string GetCurrentUserName()
        {
            UserInfo user = GetCurrentUserAwaited();
            return user.UserName;
        }

        public void UpdateUser(UserInfo userToBeUpdated)
        {
            _context.Update<UserInfo>(userToBeUpdated);
            _context.SaveChanges();
        }



    }
}
