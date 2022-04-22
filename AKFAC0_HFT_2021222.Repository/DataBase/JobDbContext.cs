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
				//MDF tesztelő
				//optionsBuilder
				//.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Foxy\source\repos\AKFAC0_HFT_2021222\AKFAC0_HFT_2021222.Repository\Job.mdf;Integrated Security=True")
				//.UseLazyLoadingProxies();

				optionsBuilder
					.UseInMemoryDatabase("JobDb")
					.UseLazyLoadingProxies();
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region NP
			//Weapon Navigation Property
			modelBuilder.Entity<Weapon>(Weapon => Weapon
			.HasOne(Weapon => Weapon.Job)
			.WithMany(Job => Job.Weapons)
			.HasForeignKey(Weapon => Weapon.JobId)
			.OnDelete(DeleteBehavior.ClientSetNull));

			//Armor Navigation Property
			modelBuilder.Entity<Armor>(Armor => Armor
			.HasOne(Armor => Armor.Job)
			.WithMany(Job => Job.Armors)
			.HasForeignKey(Armor => Armor.JobId)
			.OnDelete(DeleteBehavior.ClientSetNull));
			#endregion
			//DBSeed

			modelBuilder.Entity<Job>().HasData(new Job[]
			{
				new Job (1,"Paladin","TANK"),
				new Job (2,"Warrior","TANK"),
				new Job (3,"Dark Knight","TANK"),
				new Job (4,"Gunbreaker","TANK"),
				new Job (5,"White Mage","HEALER"),
				new Job (6,"Scholar","HEALER"),
				new Job (7,"Astrologian","HEALER"),
				new Job (8,"Sage","HEALER"),
				new Job (9,"Dragoon","DPS"),
				new Job (10,"Monk","DPS"),
				new Job (11,"Ninja","DPS"),
				new Job (12,"Reaper","DPS"),
				new Job (13,"Samurai","DPS"),
				new Job (14,"Bard","DPS"),
				new Job (15,"Machinist","DPS"),
				new Job (16,"Dancer","DPS"),
				new Job (17,"Summoner","DPS"),
				new Job (18,"Black Mage","DPS"),
				new Job (19,"Red Mage","DPS"),
			});

			modelBuilder.Entity<Weapon>().HasData(new Weapon[]
			{
				new Weapon(1,"Radiant’s Bastard Sword & Shield",117,1),
				new Weapon(2,"Asphodelos Longsword & Shield",117,1),
				new Weapon(3,"Skullrender",101,2),
				new Weapon(4,"Greatsword of Divine Light",115,3),
				new Weapon(5,"Chaosbringer",111,3),
				new Weapon(6,"Blazefire Saber",123,4), //Lightning's gunblade :3
				new Weapon(7,"Hyperion",111,4),
				new Weapon(8,"Moonward Wand",113,5),
				new Weapon(9,"Palaka Wand",106,5),
				new Weapon(10,"Imperial Magitek Index",102,6),
				new Weapon(11,"Edenmorn Index",116,6),
				new Weapon(12,"Ultimate Deneb",113,7),
				new Weapon(13,"Pepsi Blasters",555,8),
				new Weapon(14,"Law’s Order Spear",103,9),
				new Weapon(15,"Classical Tonfa",104,10),
				new Weapon(16,"Mutsunokami",111,11),
				new Weapon(17,"Botanist's sickle",666,12),
				new Weapon(18,"Hoshikiri",107,13),
				new Weapon(19,"Ruby Bow",101,14),
				new Weapon(20,"Lawman",101,15),
				new Weapon(21,"Blade’s Euphoria",106,16),
				new Weapon(22,"Epikairekakia",99,17),
				new Weapon(23,"Asura’s Rod",111,18),
				new Weapon(24,"Talekeeper",101,19)
			});

			modelBuilder.Entity<Armor>().HasData(new Armor[]
			{
				new Armor(1,"Reverence SET",200,1),
				new Armor(2,"Pummeler's SET",200,2),
				new Armor(3,"Ignominy SET",200,3),
				new Armor(4,"Allegiance SET",200,4),
				new Armor(5,"Theophany SET",50,5),
				new Armor(6,"Academic's SET",50,6),
				new Armor(7,"Astronomia SET",50,7),
				new Armor(8,"Didact's SET",50,8),
				new Armor(9,"Tiamat SET",100,9),
				new Armor(10,"Anchorite's SET",100,10),
				new Armor(11,"Hachiya SET",100,11),
				new Armor(12,"Reaper's SET",100,12),
				new Armor(13,"Saotome SET",100,13),
				new Armor(14,"Brioso SET",100,14),
				new Armor(15,"Pioneer's SET",75,15),
				new Armor(16,"Etoile SET",75,16),
				new Armor(17,"Convoker's SET",75,17),
				new Armor(18,"Spaekona's SET",50,18),
				new Armor(19,"Atrophy SET",50,19),
			});


		}
    }
}
