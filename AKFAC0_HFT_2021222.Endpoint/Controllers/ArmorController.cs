using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AKFAC0_HFT_2021222.Logic.Classes;
using AKFAC0_HFT_2021222.Models;
using System.Collections.Generic;
using AKFAC0_HFT_2021222.Endpoint.Services;
using Microsoft.AspNetCore.SignalR;

namespace AKFAC0_HFT_2021222.Endpoint.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ArmorController : ControllerBase
	{
		IArmorLogic logic;
		IHubContext<SignalRHub> hub;
		public ArmorController(IArmorLogic logic,IHubContext<SignalRHub> hub)
		{
			this.logic = logic;
			this.hub = hub;
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
			this.hub.Clients.All.SendAsync("ArmorCreated", value);
		}

		[HttpPut]
		public void Put([FromBody] Armor value)
		{
			this.logic.Update(value);
			this.hub.Clients.All.SendAsync("ArmorUpdated", value);
		}

		[HttpDelete("{id}")]
		public void Delete(int id) //works
		{
			var armorToDelete = this.logic.Read(id);
			this.logic.Delete(id);
			this.hub.Clients.All.SendAsync("ArmorDeleted", armorToDelete);
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
