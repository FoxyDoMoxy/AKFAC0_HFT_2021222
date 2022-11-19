using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AKFAC0_HFT_2021222.Logic.Classes;
using AKFAC0_HFT_2021222.Models;
using System.Collections.Generic;

namespace AKFAC0_HFT_2021222.Endpoint.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ArmorController : ControllerBase
	{
		IArmorLogic logic;
		public ArmorController(IArmorLogic logic)
		{
			this.logic = logic;
		}
		[HttpGet]
		public IEnumerable<Armor> ReadAll() //works kinda?
		{
			return this.logic.ReadAll();
		}

		[HttpGet("{id}")]
		public Armor Read(int id)//works
		{
			return this.logic.Read(id);
		}

		[HttpPost]
		public void Post([FromBody] Armor value)
		{
			this.logic.Create(value);
		}

		[HttpPut]
		public void Put([FromBody] Armor value)
		{
			this.logic.Update(value);
		}

		[HttpDelete("{id}")]
		public void Delete(int id) //works
		{
			this.logic.Delete(id);
		}
		[HttpGet("{GetAllJobArmors}")]
		public IEnumerable<Armor> GetAllJobArmors(string id)
		{
			return this.logic.GetAllJobArmors(id);
		}
		[HttpGet("{GetAverageDefenceByClass}")]
		public double? GetAverageDefenceByClass(string id)
		{
			return this.logic.GetAverageDefenceByClass(id);
		}
		[HttpGet("{GetAverageDefence}")]
		public IEnumerable<KeyValuePair<string, double>> GetAverageDefence()
		{
			return this.logic.GetAverageDefence();
		}
	}
}
