﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Models
{
	[Table("Weapons")]
	public class Weapon : Entity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[Column("Weapon_id", TypeName = "int")]
		public override int Id { get; set; }

		[MaxLength(240)]
		[Required]
		public string Name { get; set; }

		[Required]
		public int BaseDamage { get; set; }

		[ForeignKey(nameof(Job))]
		public int JobId { get; set; }
		[JsonIgnore]
		public virtual Job Job { get; set; }

		public Weapon()
		{

		}
		public Weapon(int id,string name,int baseDamage,int jobId)
		{
			this.Id=id;
			this.Name = name;
			this.BaseDamage = baseDamage;
			this.JobId = jobId;
		}
		public Weapon(string name, int baseDamage, int jobId)
		{
			this.Name = name;
			this.BaseDamage = baseDamage;
			this.JobId = jobId;
		}

		public Weapon(string name, int baseDamage, int jobId,Job job)
		{
			this.Name = name;
			this.BaseDamage = baseDamage;
			this.JobId = jobId;
			this.Job = job;
		}
	}
}
