using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Models
{
	public class Armor : Entity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Armor_Id", TypeName = "int")]
		public override int Id { get; set; }

		[Required]
		[StringLength(240)]
		public string Name { get; set; }
		[Required]
		public int Level { get; set; }

		[Required]
		public int BaseDefense { get; set; }

		[ForeignKey(nameof(Job))]
		public int JobId { get; set; }
		public virtual Job Job { get; set; }
	}
}
