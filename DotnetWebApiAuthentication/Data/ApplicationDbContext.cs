using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DotnNetWebApiAuthentication.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnNetWebApiAuthentication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}