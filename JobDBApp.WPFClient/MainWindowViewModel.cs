using AKFAC0_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobDBApp.WPFClient
{
	public class MainWindowViewModel
	{
		public RestCollection<Job> Jobs { get; set; }
		public MainWindowViewModel()
		{
			Jobs = new RestCollection<Job>("http://localhost:30703/", "job");
		}
	}
}
