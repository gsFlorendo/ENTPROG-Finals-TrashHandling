using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashHandling.Areas.Identity.Data;
using TrashHandling.Models.Entities;

namespace TrashHandling.Data;

public class PatientConsultAuthDBContext : IdentityDbContext<User>
{
    public PatientConsultAuthDBContext(DbContextOptions<PatientConsultAuthDBContext> options)
        : base(options)
    {
    }

    public DbSet<TrashBooking> TrashBookings { get; set; }
    public DbSet<TrashCollection> TrashCollections { get; set; }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<Shop> Shops { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
