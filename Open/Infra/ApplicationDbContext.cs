using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Open.Data.Museum;
using Open.Data.User;

namespace Open.Infra
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<MusealData> Museals { get; set; }
        public DbSet<InventoryMusealData> InventoryMuseals { get; set; }
        public DbSet<InventoryData> Inventories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            createMusealTable(builder);
            createInventoryMusealTable(builder);
            createInventoryTable(builder);
        }
        private static void createMusealTable(ModelBuilder b)
        {
            const string table = "Museal";
            b.Entity<MusealData>().ToTable(table);
        }
        private static void createInventoryTable(ModelBuilder b)
        {
            const string table = "Inventory";
            b.Entity<InventoryData>().ToTable(table);
        }
        private static void createInventoryMusealTable(ModelBuilder b)
        {
            const string table = "InventoryMuseal";
            b.Entity<InventoryMusealData>().ToTable(table);
            createForeignKey<InventoryMusealData, MusealData>(b, table, x => x.MusealID, x => x.Museal);
            createForeignKey<InventoryMusealData, InventoryData>(b, table, x => x.InventoryID, x => x.Inventory);
        }

        internal static void createPrimaryKey<TEntity>(ModelBuilder b, string tableName,
            Expression<Func<TEntity, object>> primaryKey) where TEntity : class
        {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasKey(primaryKey);
        }
        internal static void createForeignKey<TEntity, TRelatedEntity>(ModelBuilder b,
            string tableName, Expression<Func<TEntity, object>> foreignKey,
            Expression<Func<TEntity, TRelatedEntity>> getRelatedEntity)
            where TEntity : class where TRelatedEntity : class
        {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasOne(getRelatedEntity)
                .WithMany()
                .HasForeignKey(foreignKey)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
