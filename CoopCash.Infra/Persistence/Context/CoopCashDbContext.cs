using CoopCash.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoopCash.Infra.Persistence.Context
{
    public class CoopCashDbContext : DbContext
    {
        public CoopCashDbContext(DbContextOptions<CoopCashDbContext> options) : base(options) { }

        public DbSet<Associate> Associates { get; set; }
        public DbSet<AssociateCard> AssociateCards { get; set; }
        public DbSet<CardMachine> CardMachines { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<SystemUser> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chaves primárias
            modelBuilder.Entity<Associate>().HasKey(a => a.Id);
            modelBuilder.Entity<AssociateCard>().HasKey(c => c.Id);
            modelBuilder.Entity<CardMachine>().HasKey(m => m.Id);
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Company>().HasKey(c => c.Id);
            modelBuilder.Entity<Invoice>().HasKey(i => i.Id);
            modelBuilder.Entity<InvoiceItem>().HasKey(ii => ii.Id);
            modelBuilder.Entity<SystemUser>().HasKey(u => u.Id);

            // Relacionamento 1:N
            modelBuilder.Entity<Associate>()
                .HasMany(a => a.Cards)
                .WithOne(c => c.Associate)
                .HasForeignKey(c => c.AssociateId);

            modelBuilder.Entity<Associate>()
                .HasMany(a => a.Invoices)
                .WithOne(i => i.Associate)
                .HasForeignKey(i => i.AssociateId);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.Items)
                .WithOne(ii => ii.Invoice)
                .HasForeignKey(ii => ii.InvoiceId);

            // Relacionamento N:N
            modelBuilder.Entity<AssociateCard>()
                .HasMany(c => c.LinkedMachines)
                .WithMany(m => m.LinkedCards)
                .UsingEntity(j => j.ToTable("AssociateCardMachines"));
        }
    }
}
