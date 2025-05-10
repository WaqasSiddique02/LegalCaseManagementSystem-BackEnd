using LegalCaseManagementSystem_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        // DbSets for each of your models
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseTask> CaseTasks { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Hearing> Hearings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure CaseTask to Lawyer relationship - Changed to NoAction
            modelBuilder.Entity<CaseTask>()
                .HasOne(t => t.AssignedToLawyer)
                .WithMany()
                .HasForeignKey(t => t.AssignedToLawyerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure CaseTask to Case relationship
            modelBuilder.Entity<CaseTask>()
                .HasOne(t => t.Case)
                .WithMany(c => c.CaseTasks) 
                .HasForeignKey(t => t.CaseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Case to Client relationship with cascading delete
            modelBuilder.Entity<Case>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Cases) 
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Case to Lawyer relationship with restrict delete behavior
            modelBuilder.Entity<Case>()
                .HasOne(c => c.Lawyer)
                .WithMany(l => l.AssignedCases) 
                .HasForeignKey(c => c.LawyerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Optional: Add index for better performance on frequently queried columns
            modelBuilder.Entity<CaseTask>()
                .HasIndex(t => t.Status);

            modelBuilder.Entity<Case>()
                .HasIndex(c => c.Status);
        }
    }
}