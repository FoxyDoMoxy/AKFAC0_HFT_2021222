using AKFAC0_HFT_2021222.Models;
using AKFAC0_HFT_2021222.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Repository.Repositories
{
	public class ArmorRepository : Repository<Armor>, IRepository<Armor>
	{
		public ArmorRepository(JobDbContext ctx) : base(ctx)
		{
		}
	}
}
