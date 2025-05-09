using LegalCaseManagementSystem_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace LegalCaseManagementSystem_BackEnd.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseTask> CaseTasks { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Hearing> Hearings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
