using System;
using System.Collections.Generic;
using System.Text;
using AKFAC0_HFT_2021222.Models;
using ConsoleTools;

namespace AKFAC0_HFT_2021222.Client
{
	internal class Program
	{
        static RestService rest;
		#region Menu->Api calls
		static void Create(string entity) //All good
		{
			switch (entity)
			{
				case "Job":
					Console.Write("Enter Job Name: ");
					string jobName = Console.ReadLine();
					Console.Write("Enter role (TANK,DPS,HEALER): ");
					string role = Console.ReadLine();
					rest.Post(new Job() { Name = jobName, Role=role.ToUpper() },"job");
					break;
				case "Weapon":
					Console.Write("Enter Weapon Name: ");
					string weaponName = Console.ReadLine();
					Console.Write("Enter DMG ammount: ");
					int dmg = int.Parse(Console.ReadLine());
					Console.Write("Enter job's id : ");
					int weaponJobid = int.Parse(Console.ReadLine());
					rest.Post(new Weapon() { Name = weaponName, BaseDamage = dmg,JobId= weaponJobid }, "weapon/Post");
					break;
				case "Armor":
					Console.Write("Enter Job Name: ");
					string armorName = Console.ReadLine();
					Console.Write("Enter defense ammount: ");
					int defense = int.Parse(Console.ReadLine());
					Console.Write("Enter job's id : ");
					int armorJobid = int.Parse(Console.ReadLine());
					rest.Post(new Armor() { Name = armorName, BaseDefense=defense,JobId=armorJobid }, "armor/Post");
					break;
			}
			Console.WriteLine("Task finished.");
			Console.ReadLine();
		}
		static void List(string entity) // All good
		{
			switch (entity)
			{
				case "Job":
					List<Job> jobs = rest.Get<Job>("job");
					foreach (var item in jobs)
					{
						Console.WriteLine(item.Name + ": " + item.Role + "\n");
					}
					break;
				case "Weapon":
					List<Weapon> weapons = rest.Get<Weapon>("weapon/ReadAll");
					foreach (var weapon in weapons)
					{
						Console.WriteLine(weapon.Name + ": " + weapon.BaseDamage + "\n Job id: " + weapon.JobId+ "\n");
					}
					break;
				case "Armor":
					List<Armor> Armors = rest.Get<Armor>("armor/ReadAll");
					foreach (var armor in Armors)
					{
						Console.WriteLine(armor.Name + ": " + armor.BaseDefense + "\n Job id: " + armor.JobId+"\n");
					}
					break;
			}
			Console.WriteLine("Task finished.");
			Console.ReadLine();
		}
		static void Update(string entity) //All good
		{
			switch (entity)
			{
				case "Job":
					Console.Write("Enter job's id to update: ");
					int jobid = int.Parse(Console.ReadLine());
					Job jobtoUpdate = rest.Get<Job>(jobid, "job");

					Console.Write($"New name [old: {jobtoUpdate.Name}]: ");
					string jobName = Console.ReadLine();
					jobtoUpdate.Name = jobName;

					rest.Put(jobtoUpdate, "job");

					break;
				case "Weapon":
					Console.Write("Enter weapons's id to update: ");
					int weaponid = int.Parse(Console.ReadLine());
					Weapon weapontoUpdate = rest.Get<Weapon>(weaponid, "weapon/Read");

					Console.Write($"New name [old: {weapontoUpdate.Name}]: ");
					string weaponName = Console.ReadLine();
					weapontoUpdate.Name = weaponName;

					Console.Write($"New weapon damage [old: {weapontoUpdate.BaseDamage}]: ");
					int weaponDamage = int.Parse(Console.ReadLine());
					weapontoUpdate.BaseDamage = weaponDamage;


					Console.Write($"New job  [old: {weapontoUpdate.Job.Name}]: (ID)");
					int newWeaponJobId = int.Parse(Console.ReadLine());
					weapontoUpdate.JobId = newWeaponJobId;

					rest.Put(weapontoUpdate, "weapon/put");
					break;
				case "Armor":
					Console.Write("Enter weapons's id to update: ");
					int armorid = int.Parse(Console.ReadLine());
					Armor armortoUpdate = rest.Get<Armor>(armorid, "armor/Read");

					Console.Write($"New name [old: {armortoUpdate.Name}]: ");
					string armorName = Console.ReadLine();
					armortoUpdate.Name = armorName;

					Console.Write($"New armor defense [old: {armortoUpdate.BaseDefense}]: ");
					int armorDefense = int.Parse(Console.ReadLine());
					armortoUpdate.BaseDefense = armorDefense;


					Console.Write($"New job  [old: {armortoUpdate.Job.Name}]: (ID)");
					int newArmorJobId = int.Parse(Console.ReadLine());
					armortoUpdate.JobId = newArmorJobId;

					rest.Put(armortoUpdate, "armor/put");
					break;
			}
			Console.WriteLine("Task finished.");
			Console.ReadLine();
		}
		static void Delete(string entity) // all good
		{
			switch (entity)
			{
				case "Job":

					Console.Write("Enter job's id to delete: ");
					int jobid = int.Parse(Console.ReadLine());
					rest.Delete(jobid, "job");

					break;
				case "Weapon":

					Console.Write("Enter weapon's id to delete: ");
					int weaponid = int.Parse(Console.ReadLine());
					rest.Delete(weaponid, "weapon/Delete");

					break;
				case "Armor":

					Console.Write("Enter armor's id to delete: ");
					int armorid = int.Parse(Console.ReadLine());
					rest.Delete(armorid, "armor/Delete");

					break;
			}
			Console.WriteLine("Task finished.");
			Console.ReadLine();
		}

		static void NonCRUD(string entity, string method)
		{
			switch (entity)
			{
				case "Job":
					switch (method)
					{
						case "GetAllJobsByRole":
							Console.WriteLine("Give a role name:");
							string role = Console.ReadLine();
							List<Job> jobs = rest.Get<Job>(role, "job/GetAllJobsByRole");
							foreach (var item in jobs)
							{
								Console.WriteLine(item.Name + ": " + item.Role + "\n");
							}
							break;
						case "GetAllWeaponByRole":
							Console.WriteLine("Give a role name:");
							string role2 = Console.ReadLine();
							List<Weapon> weapons = rest.Get<Weapon>(role2, "job/GetAllWeaponByRole");
							foreach (var item in weapons)
							{
								Console.WriteLine(item.Name + ": " + item.BaseDamage + "\n");
							}
							break;
						case "GetAllWeaponByRoleMinimumDmg":

							Console.WriteLine("Give a role name:");
							string role3 = Console.ReadLine();
							Console.WriteLine("Give a minimum dmg:");
							int min = int.Parse(Console.ReadLine());
							List<Weapon> weapons2 = rest.Get<Weapon>(role3, min, "job/GetAllWeaponByRoleMinimumDmg");
							foreach (var item in weapons2)
							{
								Console.WriteLine(item.Name + ": " + item.BaseDamage + "\n");
							}
							break;
						case "GetHighestDMGWeaponGivenRole":

							Console.WriteLine("Give a role name:");
							string role4 = Console.ReadLine();
							List<Weapon> weapons4 = rest.Get<Weapon>(role4, "job/GetHighestDMGWeaponGivenRole");
							foreach (var item in weapons4)
							{
								Console.WriteLine(item.Name + ": " + item.BaseDamage + "\n");
							}
							break;
					}

					break;
				case "Weapon":
					switch (method)
					{
						case "GetAllJobWeapons":
							Console.WriteLine("Give a job name:");
							string role = Console.ReadLine();
							List<Weapon> jobs = rest.Get<Weapon>(role, "weapon/GetAllJobWeapons");
							foreach (var item in jobs)
							{
								Console.WriteLine(item.Name + ": " + item.BaseDamage + "\n");
							}
							break;
						case "GetAverageDamageByClass":
							Console.WriteLine("Give a job name:");
							string role2 = Console.ReadLine();
							double output = rest.GetSingle<double>(role2, "weapon/GetAverageDamageByClass");
							Console.WriteLine("Average Damage By Class: " + role2 + " " + output);
							break;
						case "GetAverageDamage":
							double output2 = rest.GetSingle<double>("weapon/GetAverageDamage");
							Console.WriteLine("Average Damage : " + output2);
							break;
					}
					break;
				case "Armor":
					switch (method)
					{
						case "GetAllJobArmors":
							Console.WriteLine("Give a job name:");
							string role = Console.ReadLine();
							List<Armor> jobs = rest.Get<Armor>(role, "armor/GetAllJobArmors");
							foreach (var item in jobs)
							{
								Console.WriteLine(item.Name + ": " + item.BaseDefense + "\n");
							}
							break;
						case "GetAverageDefenceByClass":
							Console.WriteLine("Give a job name:");
							string role2 = Console.ReadLine();
							double output = rest.GetSingle<double>(role2, "armor/GetAverageDefenceByClass");
							Console.WriteLine("Average defence By Class: " + role2 + " " + output);
							break;
						case "GetAverageDefence":
							double output2 = rest.GetSingle<double>("armor/GetAverageDefence");
							Console.WriteLine("Average defence : " + output2);
							break;
					}
					break;
			}
			Console.WriteLine("Task finished.");
			Console.ReadLine();
		}

		#endregion
		static void Main(string[] args)
		{
			rest = new RestService("http://localhost:30703/", "job");

			#region Menu
			var jobSubMenu = new ConsoleMenu(args, level: 1)
				 .Add("List", () => List("Job"))
				 .Add("Create", () => Create("Job"))
				 .Add("Delete", () => Delete("Job"))
				 .Add("Update", () => Update("Job"))
				 .Add("GetAllJobsByRole", () => NonCRUD("Job", "GetAllJobsByRole"))
				 .Add("GetAllWeaponByRole", () => NonCRUD("Job", "GetAllWeaponByRole"))
				 .Add("GetAllWeaponByRoleMinimumDmg", () => NonCRUD("Job", "GetAllWeaponByRoleMinimumDmg"))
				 .Add("GetHighestDMGWeaponGivenRole", () => NonCRUD("Job", "GetHighestDMGWeaponGivenRole"))
				 .Add("Exit", ConsoleMenu.Close)
				 .Configure(config =>
				 {
					 config.SelectedItemForegroundColor = ConsoleColor.White;
					 config.SelectedItemBackgroundColor = ConsoleColor.Blue;
					 config.ItemForegroundColor = ConsoleColor.Gray;
					 config.Title = "Job menu";
					 config.Selector = "|--->>";
				 });

			var weaponSubMenu = new ConsoleMenu(args, level: 1)
				 .Add("List", () => List("Weapon"))
				 .Add("Create", () => Create("Weapon"))
				 .Add("Delete", () => Delete("Weapon"))
				 .Add("Update", () => Update("Weapon"))
				 .Add("GetAllJobWeapons", () => NonCRUD("Weapon", "GetAllJobWeapons"))
				 .Add("GetAverageDamageByClass", () => NonCRUD("Weapon", "GetAverageDamageByClass"))
				 .Add("GetAverageDamage", () => NonCRUD("Weapon", "GetAverageDamage"))
				 .Add("Exit", ConsoleMenu.Close)
				 .Configure(config =>
				 {
					 config.SelectedItemForegroundColor = ConsoleColor.White;
					 config.SelectedItemBackgroundColor = ConsoleColor.Blue;
					 config.ItemForegroundColor = ConsoleColor.Gray;
					 config.Title = "Weapon menu";
					 config.EnableBreadcrumb = true;
					 config.Selector = "|--->>";
				 });

			var armorSubMenu = new ConsoleMenu(args, level: 1)
				 .Add("List", () => List("Armor"))
				 .Add("Create", () => Create("Armor"))
				 .Add("Delete", () => Delete("Armor"))
				 .Add("Update", () => Update("Armor"))
				 .Add("GetAllJobArmors", () => NonCRUD("Armor", "GetAllJobArmors"))
				 .Add("GetAverageDefenceByClass", () => NonCRUD("Armor", "GetAverageDefenceByClass"))
				 .Add("GetAverageDefence", () => NonCRUD("Armor", "GetAverageDefence"))
				 .Add("Exit", ConsoleMenu.Close)
				 .Configure(config =>
				 {
					 config.SelectedItemForegroundColor = ConsoleColor.White;
					 config.SelectedItemBackgroundColor = ConsoleColor.Blue;
					 config.ItemForegroundColor = ConsoleColor.Gray;
					 config.Title = "Armor menu";
					 config.EnableBreadcrumb = true;
					 config.Selector = "|--->>";
				 });

			var menu = new ConsoleMenu(args, level: 0)
				 .Add("Jobs", () => jobSubMenu.Show())
				 .Add("Weapons", () => weaponSubMenu.Show())
				 .Add("Armors", () => armorSubMenu.Show())
				 .Add("Exit", ConsoleMenu.Close)
				 .Configure(config =>
				 {
					 config.SelectedItemForegroundColor = ConsoleColor.White;
					 config.SelectedItemBackgroundColor = ConsoleColor.Blue;
					 config.ItemForegroundColor = ConsoleColor.Gray;
					 config.Title = "Main menu";
					 config.EnableBreadcrumb = true;
					 config.Selector = "|--->>";
				 });

			//var menu2 = new ConsoleMenu(args, level: 0)
			//	.Add("Weapon List", () => List("Weapon"))
			//	.Add("Weapon Create", () => Create("Weapon"))
			//	.Add("Weapon Delete", () => Delete("Weapon"))
			//	.Add("Weapon Update", () => Update("Weapon"))
			//	.Add("GetAllJobWeapons", () => NonCRUD("Weapon", "GetAllJobWeapons"))
			//	.Add("GetAverageDamageByClass", () => NonCRUD("Weapon", "GetAverageDamageByClass"))
			//	.Add("GetAverageDamage", () => NonCRUD("Weapon", "GetAverageDamage"))
			//	.Add("Armor List", () => List("Armor"))
			//	.Add("Armor Create", () => Create("Armor"))
			//	.Add("Armor Delete", () => Delete("Armor"))
			//	.Add("Armor Update", () => Update("Armor"))
			//	.Add("GetAllJobArmors", () => NonCRUD("Armor", "GetAllJobArmors"))
			//	.Add("GetAverageDefenceByClass", () => NonCRUD("Armor", "GetAverageDefenceByClass"))
			//	.Add("GetAverageDefence", () => NonCRUD("Armor", "GetAverageDefence"))
			//	.Add("Exit", ConsoleMenu.Close)
			//	.Configure(config => {
			//		 config.SelectedItemForegroundColor = ConsoleColor.White;
			//		 config.SelectedItemBackgroundColor = ConsoleColor.Blue;
			//		 config.ItemForegroundColor = ConsoleColor.Gray;
			//		 config.Title = "Main menu";
			//		 config.EnableBreadcrumb = true;
			//		 config.Selector = "|--->>";
			//		config.EnableFilter = true;
			//		 });


			menu.Show();
			#endregion
		}
	}
}
