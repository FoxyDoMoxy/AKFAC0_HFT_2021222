using Microsoft.EntityFrameworkCore;
using AKFAC0_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Repository
{
	public partial class JobDbContext : DbContext
	{
		public virtual DbSet<Job> Jobs { get; set; }
		public virtual DbSet<Weapon> Weapons { get; set; }
		public virtual DbSet<Armor> Armors { get; set; }

		public JobDbContext()
		{
			this.Database.EnsureCreated();
		}
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseInMemoryDatabase(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Foxy\source\repos\AKFAC0_HFT_2021222\AKFAC0_HFT_2021222.Repository\Job.mdf;Integrated Security=True;MultipleActiveResultSets=True")
					.UseLazyLoadingProxies();
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
    }
}
