﻿
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCAssessment2.Models
{
    public class CSIROContext : IdentityDbContext
    {
        public DbSet<Applicant> applicant { get; set; }

        public CSIROContext(DbContextOptions<CSIROContext> options): base(options)
        {
            Database.EnsureCreated();
        } 
    }
}
