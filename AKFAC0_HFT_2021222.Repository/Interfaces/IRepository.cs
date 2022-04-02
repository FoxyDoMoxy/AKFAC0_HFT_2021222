using AKFAC0_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Repository.Interfaces
{
	public interface IRepository<T> where T : Entity
	{
		T Read(int id);
		IQueryable<T> ReadAll();

		void Create(T item);
		void Update(T item);
		void Delete(int id);
	}
}
