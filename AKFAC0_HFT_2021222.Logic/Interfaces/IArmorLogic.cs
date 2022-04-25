using AKFAC0_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace AKFAC0_HFT_2021222.Logic.Classes
{
	public interface IArmorLogic
	{
		void Create(Armor item);
		void Delete(int id);
		Armor Read(int id);
		IQueryable<Armor> ReadAll();
		void Update(Armor item);

		// non cruds
		public IEnumerable<Armor> GetAllJobArmors(string job);//(többtáblás)
		public double? GetAverageDefenceByClass(string jobname);//(többtáblás)
		public double? GetAverageDefence();
	}
}