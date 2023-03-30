﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CQRSandMediatR.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {

        //Commands generate database is : Add-Migration Initial -context ApplicationContext , update-database -context ApplicationContext
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
