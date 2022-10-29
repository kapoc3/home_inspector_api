﻿using HomeInspector.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
namespace HomeInspector.Data;

public class HomeInspectorDbContext : AbpDbContext<HomeInspectorDbContext>
{

    public DbSet<Device> Devices { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    

    public HomeInspectorDbContext(DbContextOptions<HomeInspectorDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */
        ConfigureDevice(builder);
    }


    private static void ConfigureDevice(ModelBuilder builder)
    {
        builder.Entity<Device>(b =>
        {
            b.HasIndex(x => x.Mac).IsUnique();
        });
    }
}
