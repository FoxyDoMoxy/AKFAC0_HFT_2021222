using AKFAC0_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace AKFAC0_HFT_2021222.Logic.Classes
{
	public interface IArmorLogic
	{
		void Create(Armor item);
		void Delete(int id);
		IEnumerable<Armor> GetAllJobArmors(string job);
		IEnumerable<Armor> GetAllJobWeapons(string job);
		double? GetAverageDefence();
		double? GetAverageDefenceByClass(string jobname);
		Armor Read(int id);
		IQueryable<Armor> ReadAll();
		void Update(Armor item);
	}
}