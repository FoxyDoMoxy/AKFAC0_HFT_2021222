using System;
using AKFAC0_HFT_2021222.Logic;
using AKFAC0_HFT_2021222.Logic.Classes;
using AKFAC0_HFT_2021222.Models;
using AKFAC0_HFT_2021222.Repository;
using AKFAC0_HFT_2021222.Repository.Repositories;
using ConsoleTools;

namespace AKFAC0_HFT_2021222.Client
{
	internal class Program
	{
        static JobLogic jobLogic;
        static WeaponLogic weaponLogic;
        static ArmorLogic armorlogic;
        static void Create(string entity)
        {
            switch (entity)
            {
                case "Job":

                    break;
                case "Weapon":

                    break;
                case "Armor":

                    break;
            }
            Console.ReadLine();
        }
        static void List(string entity)
        {

            switch (entity)
			{
                case "Job":
                    var jobs = jobLogic.ReadAll();
                    foreach (var item in jobs)
                    {
						Console.WriteLine(item.Id+"\t"+item.Name+"\t"+item.Role);
                    }
                    break;
                case "Weapon":
                    var weapons = weaponLogic.ReadAll();
                    foreach (var item in weapons)
                    {
                        Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.BaseDamage);
                    }
                    break;
                case "Armor":
                    var armors = armorlogic.ReadAll();
                    foreach (var item in armors)
                    {
                        Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.BaseDefense);
                    }
                    break;
            }
			Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }
        static void Main(string[] args)
		{
            var ctx = new JobDbContext();
            
            var jobRepo=new JobRepository(ctx);
            var weaponRepo=new WeaponRepository(ctx);
            var ArmorRepo=new ArmorRepository(ctx);

            jobLogic = new JobLogic(jobRepo);
            weaponLogic = new WeaponLogic(weaponRepo);
            armorlogic = new ArmorLogic(ArmorRepo);

            var jobSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("List", () => List("Job"))
                 .Add("Create", () => Create("Job"))
                 .Add("Delete", () => Delete("Job"))
                 .Add("Update", () => Update("Job"))
                 .Add("Exit", ConsoleMenu.Close);

            var weaponSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("List", () => List("Weapon"))
                 .Add("Create", () => Create("Weapon"))
                 .Add("Delete", () => Delete("Weapon"))
                 .Add("Update", () => Update("Weapon"))
                 .Add("Exit", ConsoleMenu.Close);

            var armorSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("List", () => List("Armor"))
                 .Add("Create", () => Create("Armor"))
                 .Add("Delete", () => Delete("Armor"))
                 .Add("Update", () => Update("Armor"))
                 .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                 .Add("Jobs", () => jobSubMenu.Show())
                 .Add("Weapons", () => weaponSubMenu.Show())
                 .Add("Armors", () => armorSubMenu.Show())
                 .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
	}
}
