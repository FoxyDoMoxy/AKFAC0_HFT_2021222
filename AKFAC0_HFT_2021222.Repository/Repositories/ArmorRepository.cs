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
		public override Armor Read(int id)
		{
			return ctx.Armors.FirstOrDefault(t => t.Id == id);
		}

		public override void Update(Armor item)
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
