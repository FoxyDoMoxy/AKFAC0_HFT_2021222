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
			try
			{
				if (item.Name == "" && item.Name == null)
				{
					throw new ArgumentNullException("Armor name cant be null");
				}
				else
				{
					if (item.Name.Length < 3)
					{
						throw new ArgumentException("Armor name is too short");
					}
					else if (item.Name.Contains('?'))
					{
						throw new ArgumentException("Armor name contains illegal characters");
					}
					else if (item.BaseDefense < 0)
					{
						throw new ArgumentException("Armor defence is negative.");
					}
					else
						this.repo.Create(item);

				}
			}
			catch (AggregateException)
			{

				throw;
			}

		}

		public void Delete(int id)
		{
			this.repo.Delete(id);
		}

		public Armor Read(int id)
		{
			var armor = this.repo.Read(id);
			if (armor == null)
			{
				throw new ArgumentNullException("This armor does not exist");
			}
			return armor;
		}

		public IEnumerable<Armor> ReadAll()
		{
			return this.repo.ReadAll();
		}

		public void Update(Armor item)
		{
			this.repo.Update(item);
		}

		// Non crud

		// Returns all armor of the specific job by name (többtáblás) (pl : Paladin)
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

		// Returns the average defense of a specific job's armors. (többtáblás) (pl : Paladin)
		public double? GetAverageDefenceByClass(string jobname)
		{
			return this.repo.ReadAll().Where(x => x.Job.Name.Equals(jobname)).Average(x => x.BaseDefense);
		}

		//// Returns Average defense of all armor (nem többtáblás)
		public IEnumerable<KeyValuePair<String,double>> GetAverageDefence()
		{

			var helperq = "Average Defence All Armor";

			var helperq2 = this.repo.ReadAll().Average(x => x.BaseDefense);

			var result = (from x in repo.ReadAll()
						  select new KeyValuePair<String, double>(helperq, helperq2)).Take(1);

			return result;
			//return this.repo.ReadAll().Average(x => x.BaseDefense);

		}
	}
}
