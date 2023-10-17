﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserFactory : UserClaimsPrincipalFactory<User>
    {
        UserManager<User> userManager;
        public UserFactory(UserManager<User> _userManager,
                           IOptions<IdentityOptions> optionsAccessor
                    ):base(_userManager,optionsAccessor) 
        {
            userManager = _userManager;
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var claims = await base.GenerateClaimsAsync(user);
            if (user != null)
            {
                var roles = await userManager.GetRolesAsync(user);
                foreach (var item in roles)
                {
                    claims.AddClaim(new Claim(item, item));
                }
                claims.AddClaim(new Claim("PhoneNumer", user.PhoneNumber));
                claims.AddClaim(new Claim("Picture", user.Picture));
            }

            return claims;
        }
    }

}
