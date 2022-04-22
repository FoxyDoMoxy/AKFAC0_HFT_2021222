using System;
using System.Collections.Generic;
using AKFAC0_HFT_2021222.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKFAC0_HFT_2021222.Repository.Interfaces;

namespace AKFAC0_HFT_2021222.Repository.Repositories
{
	public class JobRepository : Repository<Job>, IRepository<Job>
	{
		public JobRepository(JobDbContext ctx) : base(ctx)
		{
		}
	}
}
