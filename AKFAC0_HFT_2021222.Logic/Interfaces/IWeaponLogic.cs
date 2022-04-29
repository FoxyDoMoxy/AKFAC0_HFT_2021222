using AKFAC0_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace AKFAC0_HFT_2021222.Logic.Classes
{
	public interface IWeaponLogic
	{
		void Create(Weapon item);
		void Delete(int id);
		Weapon Read(int id);
		IEnumerable<Weapon> ReadAll();
		void Update(Weapon item);

		// non cruds

		public IEnumerable<Weapon> GetAllJobWeapons(string job);//(többtáblás)
		public double? GetAverageDamageByJob(string jobname);//(többtáblás)
		public double? GetAverageDamage();
	}
}