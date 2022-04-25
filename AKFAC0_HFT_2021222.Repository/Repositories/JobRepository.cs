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

		public override Job Read(int id)
		{
			return ctx.Jobs.FirstOrDefault(t => t.Id == id);
		}

		public override void Update(Job item)
		{
			var old = Read(item.Id);
			foreach (var prop in old.GetType().GetProperties())
			{
				if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
				{
					prop.SetValue(old, prop.GetValue(item));
				}
			}
			ctx.SaveChanges();
		}
	}
}
