using AKFAC0_HFT_2021222.Logic;
using AKFAC0_HFT_2021222.Logic.Classes;
using AKFAC0_HFT_2021222.Models;
using AKFAC0_HFT_2021222.Repository;
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
	public class ArmorTester
	{

		ArmorLogic ArmorLogic;
		Mock<IRepository<Armor>> mockArmorRepo;


		[SetUp]
		public void Init()
		{
			//ARRANGE

			Job job1 = new Job(0, "job1", "TANK");
			Job job2 = new Job(1, "job2", "HEALER");

			mockArmorRepo = new Mock<IRepository<Armor>>();
			mockArmorRepo.Setup(mr => mr.ReadAll()).Returns(new List<Armor>()
			{
				new Armor("AAAA",100,0,job1),
				new Armor("BBBB",200,0,job1),
				new Armor("CCCC",1000,1,job2),
				new Armor("DDDD",0,1,job2),
			}.AsQueryable());

			ArmorLogic = new ArmorLogic(mockArmorRepo.Object);


		}

		//create test

		[TestCase("villa", 69, true)]
		[TestCase("kanal", -69, false)]
		[TestCase("t", 69, false)]
		[TestCase("Tttt", -69, false)]
		[TestCase("h?h", 100, false)]
		[TestCase("", 100, false)]
		public void CreateWeaponTest(string name, int def, bool shouldRun)
		{
			//ACT
			Armor testarmor = new Armor() { Name = name, BaseDefense = def };

			//ASSERT
			if (shouldRun)
			{
				ArmorLogic.Create(testarmor);
				mockArmorRepo.Verify(cr => cr.Create(testarmor), Times.Once);
			}
			else
			{
				mockArmorRepo.Verify(cr => cr.Create(testarmor), Times.Never);
			}
		}

		

		[Test]
		public void GetAverageDefenseTest()
		{
			var result = ArmorLogic.GetAverageDefence();

			var expected = new List<KeyValuePair<string, double>>()
			{
				new KeyValuePair<string, double>("Average Defence All Armor",325.0)
			};

			//Assert

			Assert.That(result, Is.EqualTo(expected));
		}
		[Test]
		public void GetAverageDefenseByClassTest()
		{

			var result = ArmorLogic.GetAverageDefenceByClass("job1");

			double expected = 150;

			//Assert

			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void GetAllJobArmors()
		{
			var result = ArmorLogic.GetAllJobArmors("job1").ToArray();

			Assert.That(result[0].Name == "AAAA" && result[1].Name == "BBBB"&&result.Length==2);
		}
	}
}
