using AKFAC0_HFT_2021222.Repository.Interfaces;
using AKFAC0_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Logic
{
	public class JobLogic : IJobLogic
	{
		IRepository<Job> repo;
		public JobLogic(IRepository<Job> repo)
		{
			this.repo = repo;
		}
		public void Create(Job item)
		{
			if (item.Name.Length < 3)
			{
				throw new ArgumentException("Job name is too short");
			}
			else
				this.repo.Create(item);
		}

		public void Delete(int id)
		{
			this.repo.Delete(id);
		}

		public Job Read(int id)
		{
			var job = this.repo.Read(id);
			if (job == null)
			{
				throw new ArgumentNullException("This job does not exist");
			}
			return job;
		}

		public IQueryable<Job> ReadAll()
		{
			return this.repo.ReadAll();
		}

		public void Update(Job item)
		{
			this.repo.Update(item);
		}

		// Non crud

		public IEnumerable<Job> GetAllJobsByRole(string role)
		{
			return from x in this.repo.ReadAll()
				   where x.Role == role
				   select new Job
				   {
					   Name = x.Name,
					   Role = x.Role,
					   Armors = x.Armors,
					   Weapons = x.Weapons,
					   Id = x.Id
				   };
		}
	}
}
