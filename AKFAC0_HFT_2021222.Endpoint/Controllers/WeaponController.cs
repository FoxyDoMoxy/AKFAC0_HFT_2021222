using AKFAC0_HFT_2021222.Logic.Classes;
using AKFAC0_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AKFAC0_HFT_2021222.Endpoint.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class WeaponController : ControllerBase
	{
		IWeaponLogic logic;
		public WeaponController(IWeaponLogic logic)
		{
			this.logic = logic;
		}
		[HttpGet]
		public IEnumerable<Weapon> ReadAll() //works kinda?
		{
			return this.logic.ReadAll();
		}

		[HttpGet]
		public Weapon Read(int id)//works
		{
			return this.logic.Read(id);
		}

		[HttpPost]
		public void Post([FromBody] Weapon value)
		{
			this.logic.Create(value);
		}

		[HttpPut]
		public void Put([FromBody] Weapon value)
		{
			this.logic.Update(value);
		}

		[HttpDelete]
		public void Delete(int id) //works
		{
			this.logic.Delete(id);
		}
		[HttpGet]
		public IEnumerable<Weapon> GetAllJobWeapons(string job)
		{
			return this.logic.GetAllJobWeapons(job);
		}
		[HttpGet]
		public double? GetAverageDamageByClass(string jobname)
		{
			return this.logic.GetAverageDamageByClass(jobname);
		}
		[HttpGet]
		public double? GetAverageDamage()
		{
			return this.logic.GetAverageDamage();
		}

	}
}
