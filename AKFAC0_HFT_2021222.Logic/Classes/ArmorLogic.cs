using AKFAC0_HFT_2021222.Models;
using AKFAC0_HFT_2021222.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Logic.Classes
{
	public class ArmorLogic : IArmorLogic
	{
		IRepository<Armor> repo;
		public ArmorLogic(IRepository<Armor> repo)
		{
			this.repo = repo;
		}
		public void Create(Armor item)
		{
			if (item.Name.Length < 3)
			{
				throw new ArgumentException("Job name is too short");
			}
			else if (item.Name.Contains('?'))
			{

			}
			else
				this.repo.Create(item);
		}

		public void Delete(int id)
		{
			this.repo.Delete(id);
		}

		public Armor Read(int id)
		{
			var job = this.repo.Read(id);
			if (job == null)
			{
				throw new ArgumentNullException("This job does not exist");
			}
			return job;
		}

		public IQueryable<Armor> ReadAll()
		{
			return this.repo.ReadAll();
		}

		public void Update(Armor item)
		{
			this.repo.Update(item);
		}

		// Non crud

		// Returns all armor of the specific job by name (többtáblás)
		public IEnumerable<Armor> GetAllJobArmors(string job)
		{
			return from x in this.repo.ReadAll()
				   where x.Job.Name == job
				   select new Armor()
				   {
					   Id = x.Id,
					   Name = x.Name,
					   BaseDefense = x.BaseDefense,
				   };
		}

		// Returns the average defense of a specific job's armors. (többtáblás)
		public double? GetAverageDefenceByClass(string jobname)
		{
			return this.repo.ReadAll().Where(x => x.Job.Name.Equals(jobname)).Average(x => x.BaseDefense);
		}

		//// Returns Average defense of all armor (nem többtáblás)
		public double? GetAverageDefence()
		{
			return this.repo.ReadAll().Average(x => x.BaseDefense);
		}
	}
}
