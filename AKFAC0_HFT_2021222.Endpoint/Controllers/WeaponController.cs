using AKFAC0_HFT_2021222.Endpoint.Services;
using AKFAC0_HFT_2021222.Logic.Classes;
using AKFAC0_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace AKFAC0_HFT_2021222.Endpoint.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class WeaponController : ControllerBase
	{
		IWeaponLogic logic;
		IHubContext<SignalRHub> hub;
		public WeaponController(IWeaponLogic logic, IHubContext<SignalRHub> hub)
		{
			this.logic = logic;
			this.hub = hub;
		}
		[HttpGet]
		public IEnumerable<Weapon> ReadAll() //works kinda?
		{
			return this.logic.ReadAll();
		}

		[HttpGet("{id}")]
		public Weapon Read(int id)//works
		{
			return this.logic.Read(id);
		}

		[HttpPost]
		public void Post([FromBody] Weapon value)
		{
			this.logic.Create(value);
			this.hub.Clients.All.SendAsync("WeaponCreated", value);
		}

		[HttpPut]
		public void Put([FromBody] Weapon value)
		{
			this.logic.Update(value);
			this.hub.Clients.All.SendAsync("WeaponUpdated", value);
		}

		[HttpDelete("{id}")]
		public void Delete(int id) //works
		{
			var weaponToDelete = this.logic.Read(id);
			this.logic.Delete(id);
			this.hub.Clients.All.SendAsync("WeaponDeleted", weaponToDelete);
		}
		[HttpGet("{GetAllJobWeapons}")]
		public IEnumerable<Weapon> GetAllJobWeapons(string id)
		{
			return this.logic.GetAllJobWeapons(id);
		}
		[HttpGet("{GetAverageDamageByJob}")]
		public double? GetAverageDamageByJob(string id)
		{
			return this.logic.GetAverageDamageByJob(id);
		}
		[HttpGet("{GetAverageDamage}")]
		public IEnumerable<KeyValuePair<string, double>> GetAverageDamage()
		{
			return this.logic.GetAverageDamage();
		}

	}
}
