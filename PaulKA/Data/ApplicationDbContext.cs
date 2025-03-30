using Microsoft.EntityFrameworkCore;
using PaulKA.Controllers;
using PaulKA.Models;


namespace PaulKA.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Required constructor for dependency injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet properties here
        public DbSet<Song> Songs { get; set; }
        public DbSet<PaymentRecord> PaymentRecords { get; set; } // Add this line to define the PaymentRecords DbSet

        public DbSet<PaymentModels> Payment { get; set; } // Correct the Payment class reference
    }
}
