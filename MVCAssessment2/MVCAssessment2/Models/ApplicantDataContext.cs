using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace MVCAssessment2.Models
{
    public class ApplicantDataContext : IdentityDbContext
    {
        public DbSet<Applicant> applicant { get; set; }

        public ApplicantDataContext(DbContextOptions<ApplicantDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}