using Data.Configurations;
using Data.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace Data
{
    public class QuizAppDbContext : ApiAuthorizationDbContext<QuizAppUser>
    {
        public QuizAppDbContext(DbContextOptions<QuizAppDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        { }

        public DbSet<GameRound> GameRounds { get; set; }
        public DbSet<QuestionStatistic> QuestionStatistics { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<QuizAppUser> QuizAppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new GameRoundConfiguration())
                .ApplyConfiguration(new QuestionStatisticConfiguration())
                .ApplyConfiguration(new CategoryConfiguration())
                .ApplyConfiguration(new QuizAppUserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder builder)
        {
            #region Admin Credentials Properties
            var email = "a@b.c";
            var password = "Test123_";

            var user = new QuizAppUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                EmailConfirmed = true

            };

            var passwordHasher = new PasswordHasher<QuizAppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, password);

            // Add user to database
            builder.Entity<QuizAppUser>().HasData(user);
            #endregion 

            /*Adding the new user to the database. */

            #region Admin Roles and Claims
            var admin = "Admin";
            var role = new IdentityRole { Id = "1", Name = admin, NormalizedName = admin.ToUpper() };

            /*Adding the role to the AspNetRoles table.*/

            builder.Entity<IdentityRole>().HasData(role);

            /*Assigning the role to the Admin user */

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = role.Id, UserId = user.Id });

            /*Adding user claims to Admin and QuizAppUser*/

            builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string> { Id = 1, ClaimType = admin, ClaimValue = "true", UserId = user.Id });

            builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string> { Id = 2, ClaimType = "QuizAppUser", ClaimValue = "true", UserId = user.Id });
            #endregion
        }

        public void SeedAdminData() /*The entire code is run only when we create the database and run the application the first time */
        {
            #region Admin Credentials Properties
            var adminEmail = "a@b.c";
            var adminPassword = "Test123__";
            var adminUserId = string.Empty;

            // Fetch the Admin User Id
            if (Users.Any(u => u.Email.Equals(adminEmail))) adminUserId = (Users.SingleOrDefault(u => u.Email.Equals(adminEmail))).Id;

            else
            {
                var user = new QuizAppUser
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper(),
                    NormalizedUserName = adminEmail.ToUpper()
                };

                var passwordHasher = new PasswordHasher<QuizAppUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, adminPassword);

                Users.Add(user);
                SaveChanges();
                adminUserId = (Users.SingleOrDefault(u => u.Email.Equals(adminEmail))).Id;

            }
            #endregion

            #region Add Admin Role
            var adminRoleName = "Admin";

            /*Fetching a role with the name Admin from the table and storing it in a variable named adminRole. */

            var adminRole = Roles.SingleOrDefault(r => r.Name.ToLower().Equals(adminRoleName.ToLower()));

            /*Checking if Admin was successfully fetched, default value means that the role wasn’t in the table */

            if (adminRole == default)
            {

                /*Add a new role to the table with the Name and Id 1. */   /*Creating it in the database table */
                Roles.Add(new IdentityRole()
                {

                    Name = adminRoleName,
                    NormalizedName = adminRoleName.ToUpper(),
                    Id = "1"

                });

                /*Saving the changes to the database and fetching the role into the adminRole variable */   /*Bringing it to the application? */
                SaveChanges(); adminRole = Roles.SingleOrDefault(r => r.Name.ToLower().Equals(adminRoleName.ToLower()));
            }
            #endregion
            /*Adding the Admin role to the admin user */

            #region Seed Data for the Admin
            if (adminUserId != string.Empty) /*Alternative - if (!adminUserId.Equals(string.Empty)) */

            {
                /*Checking that adminRole exists. */
                if (adminRole != default)
                {
                    /*Fetching role from the UserRoles table.*/

                    var userRoleExists = UserRoles.Any(ur => ur.RoleId.Equals(adminRole.Id) && ur.UserId.Equals(adminUserId));

                    if (!userRoleExists)
                        /*If missing then adding the Admin role to the user */
                        UserRoles.Add(new IdentityUserRole<string> { RoleId = adminRole.Id, UserId = adminUserId });

                }
                #endregion
                #region Add User Claims
                var claimType = "Admin"; /*Claim to have the role of an admin */
                /*Checking if there is claim associated with adminUserId */
                var userClaimExists = UserClaims.Any(uc => uc.ClaimType.ToLower().Equals(claimType.ToLower()) && uc.UserId.Equals(adminUserId));

                if (!userClaimExists) UserClaims.Add(new IdentityUserClaim<string>

                {
                    ClaimType = claimType,
                    ClaimValue = "true",
                    UserId = adminUserId

                });

                claimType = "QuizAppUser"; /*Claim to have the role of a regular user */
                userClaimExists = UserClaims.Any(uc => uc.ClaimType.ToLower().Equals(claimType.ToLower()) && uc.UserId.Equals(adminUserId));

                if (!userClaimExists)

                    UserClaims.Add(new IdentityUserClaim<string> /*The entire code is run only when we create the database and run the application the first time */
                    {
                        ClaimType = claimType,
                        ClaimValue = "true",
                        UserId = adminUserId

                    });
                #endregion
            }
            SaveChanges();

        }

        public void SeedMembershipData()
        {
            var email = "a@b.c";
            var userId = string.Empty;


            if (Users.Any(r => r.Email.Equals(email)))
                userId = Users.First(r => r.Email.Equals(email)).Id;
            else

                return;

            SaveChanges();
        }

    }
}
