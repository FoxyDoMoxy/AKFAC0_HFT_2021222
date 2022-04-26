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
		[Test]
		public void CreateWeaponTestWithNull()
		{
			var weapon = new Weapon();
			//ACT
			try
			{
				WeaponLogic.Create(weapon);
			}
			catch
			{
			}

			//ASSERT
			mockWeaponRepo.Verify(r => r.Create(weapon), Times.Never);

		}
		[Test]
		public void CreateWeaponTestWithCorrectName()
		{
			var weapon = new Weapon() { Name = "Test Mage" };
			//ACT
			WeaponLogic.Create(weapon);

			//ASSERT
			mockWeaponRepo.Verify(r => r.Create(weapon), Times.Once);

		}

		[Test]
		public void CreateWeaponTestWithInCorrectName()
		{
			var weapon = new Weapon() { Name = "?:asdds" };
			//ACT
			try
			{
				WeaponLogic.Create(weapon);
			}
			catch
			{


			}

			//ASSERT
			mockWeaponRepo.Verify(r => r.Create(weapon), Times.Never);

		}


		[Test]
		public void CreateWeaponTestWithCorrectLenghtName()
		{
			var weapon = new Weapon() { Name = "VAlamiii" };
			//ACT
			WeaponLogic.Create(weapon);

			//ASSERT
			mockWeaponRepo.Verify(r => r.Create(weapon), Times.Once);

		}

		[Test]
		public void CreateWeaponTestWithInCorrectLenghtName()
		{
			var weapon = new Weapon() { Name = "a" };
			//ACT
			try
			{

				WeaponLogic.Create(weapon);
			}
			catch
			{


			}

			//ASSERT
			mockWeaponRepo.Verify(r => r.Create(weapon), Times.Never);

		}

		[Test]
		public void GetAverageDamageTest()
		{

			var result = WeaponLogic.GetAverageDamage();

			double expected = 325;

			//Assert

			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void GetAverageDamageByClassTest()
		{

			var result = WeaponLogic.GetAverageDamageByClass("job1");

			double expected = 150;

			//Assert

			Assert.That(result, Is.EqualTo(expected));
		}
	}
}
