using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Models
{
	public class Job : Entity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Job_id", TypeName = "int")]
		public override int Id { get; set; }

		[Required]
		[StringLength(240)]
		public string Name { get; set; }

		[Required]
		[Range(1,90)]
		public string Role { get; set; }

		[NotMapped] // Not sure?
		public virtual ICollection<Weapon> Weapons { get; set; }

		[NotMapped]// Not sure?
		public virtual ICollection<Armor> Armors { get; set; }

		public Job()
		{
			this.Weapons = new HashSet<Weapon>();
			this.Armors = new HashSet<Armor>();
		}
	}
}
