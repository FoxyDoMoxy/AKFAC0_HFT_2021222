using AKFAC0_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace AKFAC0_HFT_2021222.Logic.Classes
{
	public interface IWeaponLogic
	{
		void Create(Weapon item);
		void Delete(int id);
		IEnumerable<Weapon> GetAllJobWeapons(string job);
		double? GetAverageDamage();
		double? GetAverageDamageByClass(string jobname);
		Weapon Read(int id);
		IQueryable<Weapon> ReadAll();
		void Update(Weapon item);
	}
}