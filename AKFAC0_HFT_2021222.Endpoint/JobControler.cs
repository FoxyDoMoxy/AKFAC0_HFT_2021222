using AKFAC0_HFT_2021222.Models;
using AKFAC0_HFT_2021222.Logic.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AKFAC0_HFT_2021222.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AKFAC0_HFT_2021222.Endpoint
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobControler : ControllerBase
	{
		IJobLogic logic;
		public JobControler(IJobLogic logic)
		{
			this.logic = logic;
		}
		[HttpGet]
		public IEnumerable<Job> Get()
		{
			return this.logic.ReadAll();
		}

		[HttpGet("{id}")]
		public Job Get(int id)
		{
			return this.logic.Read(id);
		}

		[HttpPost]
		public void Post([FromBody] Job value)
		{
			this.logic.Create(value);
		}

		[HttpPut("{id}")]
		public void Put([FromBody] Job value)
		{
			this.logic.Update(value);
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			this.logic.Delete(id);
		}
	}
}
