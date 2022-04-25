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
	public class Job : Entity
	{
		[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]   Valamiért nem szereti DBseedel :p
		[Column("Job_id", TypeName = "int")]
		public override int Id { get; set; }

		[Required]
		[StringLength(240)]
		public string Name { get; set; }

		[Required]
		public string Role { get; set; }

		[NotMapped] 
		[JsonIgnore]
		public virtual ICollection<Weapon> Weapons { get; set; }

		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<Armor> Armors { get; set; }

		public Job()
		{
			this.Weapons = new HashSet<Weapon>();
			this.Armors = new HashSet<Armor>();
		}
		public Job(int id,string Name,string Role) :base()
		{
			this.Id = id;
			this.Weapons = new HashSet<Weapon>();
			this.Armors = new HashSet<Armor>();
			this.Name = Name;
			this.Role = Role;
		}

	}
}
