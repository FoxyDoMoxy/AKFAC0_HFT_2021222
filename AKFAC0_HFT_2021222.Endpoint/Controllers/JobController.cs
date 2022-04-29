using AKFAC0_HFT_2021222.Logic;
using AKFAC0_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AKFAC0_HFT_2021222.Endpoint.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class JobController : ControllerBase
	{
		IJobLogic logic;
		public JobController(IJobLogic logic)
		{
			this.logic = logic;
		}
		[HttpGet]
		public IEnumerable<Job> ReadAll() //works kinda?
		{
			return this.logic.ReadAll();
		}

		[HttpGet("{id}")]
		public Job Read(int id)//works
		{
			return this.logic.Read(id);
		}

		[HttpPost]
		public void Post([FromBody] Job value)
		{
			this.logic.Create(value);
		}

		[HttpPut]
		public void Put([FromBody] Job value)
		{
			this.logic.Update(value);
		}

		[HttpDelete("{id}")]
		public void Delete(int id) //works
		{
			this.logic.Delete(id);
		}

		[HttpGet("GetAllJobsByRole")]
		public IEnumerable<Job> GetAllJobsByRole(string id)
		{
			return this.logic.GetAllJobsByRole(id);
		}
		[HttpGet("GetAllWeaponByRole")]
		public IEnumerable<Weapon> GetAllWeaponByRole(string id)
		{
			return this.logic.GetAllWeaponByRole(id);
		}
		[HttpGet("GetAllWeaponByRoleMinimumDmg")]
		public IEnumerable<Weapon> GetAllWeaponByRoleMinimumDmg(string id, int dmg)
		{
			return this.logic.GetAllWeaponByRoleMinimumDmg(id, dmg);
		}
		[HttpGet("GetHighestDMGWeaponGivenRole")]
		public IEnumerable<Weapon> GetHighestDMGWeaponGivenRole(string id)
		{
			return this.logic.GetHighestDMGWeaponGivenRole(id);
		}
	}
}
