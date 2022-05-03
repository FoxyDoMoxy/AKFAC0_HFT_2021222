using AKFAC0_HFT_2021222.Logic.Classes;
using AKFAC0_HFT_2021222.Models;
using AKFAC0_HFT_2021222.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKFAC0_HFT_2021222.Test
{
	[TestFixture]
	public class WeaponTester
	{
		WeaponLogic WeaponLogic;
		Mock<IRepository<Weapon>> mockWeaponRepo;

		[SetUp]
		public void Init()
		{
			Job job1 = new Job(0, "job1", "TANK");
			Job job2 = new Job(1, "job2", "HEALER");

			//ARRANGE
			mockWeaponRepo = new Mock<IRepository<Weapon>>();
			mockWeaponRepo.Setup(mr => mr.ReadAll()).Returns(new List<Weapon>()
			{
				new Weapon("AAAA",100,0,job1),
				new Weapon("BBBB",200,0,job1),
				new Weapon("CCCC",1000,1,job2),
				new Weapon("DDDD",0,1,job2),
			}.AsQueryable());

			WeaponLogic = new WeaponLogic(mockWeaponRepo.Object);

		}

		//create test

		[TestCase("villa", 69, true)]
		[TestCase("kanal",-69 , false)]
		[TestCase("t", 69, false)]
		[TestCase("Tttt", -69, false)]
		[TestCase("h?h", 100, false)]
		[TestCase("", 100, false)]
		public void CreateWeaponTest(string name, int dmg, bool shouldRun)
		{
			//ACT
			Weapon testweapon = new Weapon() { Name = name, BaseDamage = dmg };

			//ASSERT
			if (shouldRun)
			{
				WeaponLogic.Create(testweapon);
				mockWeaponRepo.Verify(cr => cr.Create(testweapon), Times.Once);
			}
			else
			{
				mockWeaponRepo.Verify(cr => cr.Create(testweapon), Times.Never);
			}
		}



		[Test]
		public void GetAverageDamageTest()
		{
			var result = WeaponLogic.GetAverageDamage();

			var expected = new List<KeyValuePair<string, double>>()
			{
				new KeyValuePair<string, double>("Average dmg All weapon",325.0)
			};

			//Assert

			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void GetAverageDamageByClassTest()
		{

			var result = WeaponLogic.GetAverageDamageByJob("job1");

			double expected = 150;

			//Assert

			Assert.That(result, Is.EqualTo(expected));
		}
	}
}
