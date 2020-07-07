using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebCoreIsIstek.Models
{
    public partial class MakinaBakimDbContext : DbContext
    {
        public MakinaBakimDbContext()
        {
        }

        public MakinaBakimDbContext(DbContextOptions<MakinaBakimDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tbKullanicilar> tbKullanicilar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }


    }

}
