using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Data.Models
{
    public class QuizAppUser : IdentityUser
    {
        public string Token { get; set; }
        public DateTime TokenExpires { get; set; } //Will be used to store the expiration date and time for the JWT Token.
        public IList<Claim> Claims { get; set; } = new List<Claim>(); //This collection will be used to store the logged-in user’s authentication claims
    }
}
