using CustomASPNetCoreMVC.Areas.Identity.Data;
using CustomASPNetCoreMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomASPNetCoreMVC.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Use seed method here
        builder.Seed();
        base.OnModelCreating(builder);

        builder.Entity<AppUser>(entity =>
        {
            entity.ToTable(name: "SysUser");
        });
        builder.Entity<IdentityRole>(entity =>
        {
            entity.ToTable(name: "SysRole");
        });
        builder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable("SysUserRole");
        });
        builder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable("SysClaim");
        });
        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable("SysLogin");
        });
        builder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.ToTable("SysClaimRole");
        });
        builder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable("SysUserToken");
        });
    }
}
