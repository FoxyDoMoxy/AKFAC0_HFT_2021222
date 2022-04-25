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
			//ARRANGE
			mockWeaponRepo = new Mock<IRepository<Weapon>>();
			mockWeaponRepo.Setup(mr => mr.ReadAll()).Returns(new List<Weapon>()
			{
				new Weapon("AAAA",100,1),
				new Weapon("BBBB",100,1),
				new Weapon("CCCC",1000,1),
				new Weapon("DDDD",0,1),
			}.AsQueryable());

			WeaponLogic = new WeaponLogic(mockWeaponRepo.Object);

		}

		//create test
		[Test]
		public void CreateArmorTestWithCorrectName()
		{
			var weapon = new Weapon() { Name = "Test Mage" };
			//ACT
			WeaponLogic.Create(weapon);

			//ASSERT
			mockWeaponRepo.Verify(r => r.Create(weapon), Times.Once);

		}

		[Test]
		public void CreateArmorTestWithInCorrectName()
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
		public void CreateArmorTestWithCorrectLenghtName()
		{
			var weapon = new Weapon() { Name = "VAlamiii" };
			//ACT
			WeaponLogic.Create(weapon);

			//ASSERT
			mockWeaponRepo.Verify(r => r.Create(weapon), Times.Once);

		}

		[Test]
		public void CreateArmorTestWithInCorrectLenghtName()
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

			double expected = 300;

			//Assert

			Assert.That(result, Is.EqualTo(expected));
		}
	}
}
