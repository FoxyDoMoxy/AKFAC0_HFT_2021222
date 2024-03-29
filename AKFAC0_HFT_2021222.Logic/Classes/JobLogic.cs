﻿using AKFAC0_HFT_2021222.Repository.Interfaces;
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
			string[] accepted = new string[]
			{
				"TANK",
				"HEALER",
				"DPS"
			};
			try
			{
				if (!accepted.Contains(item.Role.ToUpper()))
				{
					throw new ArgumentException("Job doesnt appeal to the requements");
				}
				else if (item.Name.Length < 3)
				{
					throw new ArgumentException("Job name is too short");
				}
				else { this.repo.Create(item); }
			}
			catch (Exception)
			{
				
			}

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

		public IEnumerable<Job> ReadAll()
		{
			return this.repo.ReadAll();
		}

		public void Update(Job item)
		{
			this.repo.Update(item);
		}

		// Non crud

		// Gives back all Jobs of the given role. (Nem többtáblás) (pl : TANK)
		public IEnumerable<Job> GetAllJobsByRole(string id) 
		{
			return from x in this.repo.ReadAll()
				   where x.Role == id
				   select new Job
				   {
					   Name = x.Name,
					   Role = x.Role,
					   Armors = x.Armors.ToList(),
					   Weapons = x.Weapons.ToList(),
					   Id = x.Id
				   };
		}

		//Gives back a collection of weapons belonging to a given role. (többtáblás) (pl : TANK)
		public IEnumerable<Weapon> GetAllWeaponByRole(string id) 
		{
			return (from x in this.repo.ReadAll()
					where x.Role == id
					select x.Weapons).SelectMany(y => y); ;

		}

		//Read the name maybe?? lol (többtáblás) (pl : TANK, 115)
		public IEnumerable<Weapon> GetAllWeaponByRoleMinimumDmg(string id, int dmg)
		{

			var res = repo
				.ReadAll()
				.Where(x => x.Role == id)
				.SelectMany(y=>y.Weapons.Where( v=>v.BaseDamage>dmg))
				.Select(x=>x);
			return res;

		}

		// Name says it all  (többtáblás) (pl : TANK)
		public IEnumerable<Weapon> GetHighestDMGWeaponGivenRole(string role)
		{
			var max = repo.ReadAll().Where(x=>x.Role == role).SelectMany(x=>x.Weapons.Select(y=>y.BaseDamage)).Max();
			var res = repo
				.ReadAll()
				.Where(x => x.Role == role)
				.Select(v=>v.Weapons.Where(d=>d.BaseDamage == max))
				.SelectMany(x => x).OrderByDescending(y => y.BaseDamage);
			return res;

		}


	}
}
