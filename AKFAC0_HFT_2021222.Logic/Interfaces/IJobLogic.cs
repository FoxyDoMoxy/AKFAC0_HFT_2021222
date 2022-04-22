using AKFAC0_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace AKFAC0_HFT_2021222.Logic
{
	public interface IJobLogic
	{
		void Create(Job item);
		void Delete(int id);
		IEnumerable<Job> GetAllJobsByRole(string role);
		Job Read(int id);
		IQueryable<Job> ReadAll();
		void Update(Job item);
	}
}