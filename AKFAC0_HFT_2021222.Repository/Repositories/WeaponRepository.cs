using AKFAC0_HFT_2021222.Models;
using AKFAC0_HFT_2021222.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Repository.Repositories
{
	internal class WeaponRepository : Repository<Weapon>, IRepository<Weapon>
	{
		public WeaponRepository(JobDbContext ctx) : base(ctx)
		{
		}
	}
}
