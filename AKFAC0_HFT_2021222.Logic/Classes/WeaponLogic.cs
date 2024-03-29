﻿using AKFAC0_HFT_2021222.Models;
using AKFAC0_HFT_2021222.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Logic.Classes
{
	public class WeaponLogic : IWeaponLogic
	{
		IRepository<Weapon> repo;
		public WeaponLogic(IRepository<Weapon> repo)
		{
			this.repo = repo;
		}
		public void Create(Weapon item)
		{
			try
			{
				if (item.Name == "" && item.Name == null)
				{
					throw new ArgumentNullException("Weapon name cant be null");
				}
				else
				{
					if (item.Name.Length < 3)
					{
						throw new ArgumentException("Weapon name is too short");
					}
					else if (item.Name.Contains('?'))
					{
						throw new ArgumentException("Weapon name contains illegal characters");
					}
					else if (item.BaseDamage < 0)
					{
						throw new ArgumentException("Weapon dmg is negative.");
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

		public Weapon Read(int id)
		{
			var weapon = this.repo.Read(id);
			if (weapon == null)
			{

				throw new ArgumentNullException("This weapon does not exist");
			}
			return weapon;
		}

		public IEnumerable<Weapon> ReadAll()
		{
			return this.repo.ReadAll();
		}

		public void Update(Weapon item)
		{
			this.repo.Update(item);
		}

		// Non crud


		// Returns all weapons of the specific job by name (többtáblás) (pl : Paladin)
		public IEnumerable<Weapon> GetAllJobWeapons(string job) 
		{
			return from x in this.repo.ReadAll()
				   where x.Job.Name == job
				   select new Weapon()
				   {
					   Id = x.Id,
					   Name = x.Name,
					   BaseDamage = x.BaseDamage,
				   };
		}

		// Returns the average DMG of a specific job's weapons. (többtáblás) (pl : Paladin)
		public double? GetAverageDamageByJob(string jobname)
		{

			return this.repo.ReadAll().Where(x => x.Job.Name.Equals(jobname)).Average(x => x.BaseDamage);
		}


		// Returns Average dmg of all weapon (nem többtáblás)
		public IEnumerable<KeyValuePair<String, double>> GetAverageDamage()
		{

			var helperq = "Average dmg All weapon";

			var helperq2 = this.repo.ReadAll().Average(x => x.BaseDamage);

			var result = (from x in repo.ReadAll()
						  select new KeyValuePair<string, double>(helperq, helperq2)).Take(1);

			return result;
			//return this.repo.ReadAll().Average(x => x.BaseDefense);

		}
		//public double? GetAverageDamage()
		//{
		//	return this.repo.ReadAll().Average(x => x.BaseDamage);
		
	}
}
