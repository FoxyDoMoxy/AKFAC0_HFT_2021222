using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Models
{
	public class Armor : Entity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[Column("Armor_Id", TypeName = "int")]
		public override int Id { get; set; }

		[Required]
		[StringLength(240)]
		public string Name { get; set; }

		[Required]
		public int BaseDefense { get; set; }

		[ForeignKey(nameof(Job))]
		public int JobId { get; set; }
		[JsonIgnore]
		public virtual Job Job { get; set; }

		public Armor()
		{

		}
		public Armor(int Id,string name, int baseDefense, int jobId)
		{
			this.Id = Id;
			this.Name = name;
			this.BaseDefense = baseDefense;
			this.JobId = jobId;
		}
		public Armor(string name, int baseDefense, int jobId)
		{
			this.Name = name;
			this.BaseDefense = baseDefense;
			this.JobId = jobId;
		}
		public Armor(string name, int baseDefense, int jobId,Job job)
		{
			this.Name = name;
			this.BaseDefense = baseDefense;
			this.JobId = jobId;
			this.Job = job;
		}
	}
}
