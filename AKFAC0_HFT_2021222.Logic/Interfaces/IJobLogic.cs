using AKFAC0_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace AKFAC0_HFT_2021222.Logic
{
	public interface IJobLogic
	{
		void Create(Job item);
		void Delete(int id);
		Job Read(int id);
		IEnumerable<Job> ReadAll();
		void Update(Job item);

		// non cruds

		public IEnumerable<Job> GetAllJobsByRole(string role);
		public IEnumerable<Weapon> GetAllWeaponByRole(string role);//(többtáblás)
		public IEnumerable<Weapon> GetAllWeaponByRoleMinimumDmg(string role, int dmg);//(többtáblás)
		public Weapon GetHighestDMGWeaponGivenRole(string role); //(többtáblás)
	}
}