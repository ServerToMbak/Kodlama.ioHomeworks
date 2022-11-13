using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
              //  base.OnConfiguring(
                //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramingLanguage>(a =>
            {
                object value = a.ToTable("ProgramingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologiess);
            });

            modelBuilder.Entity<Technologies>(a =>
            {
                object value = a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.ProgramingLanguageId).HasColumnName("PropramingLanguageId");
                a.HasOne(p => p.ProgramingLanguage);
            });


            ProgramingLanguage[] programingLanguageSeeds = { new(1, "Test 1"), new(2, "Test 2") };
            modelBuilder.Entity<ProgramingLanguage>().HasData(programingLanguageSeeds);

            Technologies[] TechnologiesSeeds = { new(1,1,"Entityframe"), new(2,1, "Test 2") };
            modelBuilder.Entity<Technologies>().HasData(TechnologiesSeeds);

        }
    }
}
