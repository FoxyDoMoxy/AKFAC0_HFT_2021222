using AKFAC0_HFT_2021222.Logic;
using AKFAC0_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AKFAC0_HFT_2021222.Endpoint.Controllers
{
	[Route("api/[controller]/[action]")]
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

		[HttpGet]
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

		[HttpDelete]
		public void Delete(int id) //works
		{
			this.logic.Delete(id);
		}
	}
}
