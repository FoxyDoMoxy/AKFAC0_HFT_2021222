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
			mockArmorRepo = new Mock<IRepository<Armor>>();
			mockArmorRepo.Setup(mr => mr.ReadAll()).Returns(new List<Armor>()
			{
				new Armor("AAAA",100,1),
				new Armor("BBBB",100,1),
				new Armor("CCCC",1000,1),
				new Armor("DDDD",0,1),
			}.AsQueryable());

			ArmorLogic = new ArmorLogic(mockArmorRepo.Object);

		}

		//create test
		[Test]
		public void CreateArmorTestWithCorrectName()
		{
			var armor = new Armor() { Name = "Test Mage"};
			//ACT
			ArmorLogic.Create(armor);

			//ASSERT
			mockArmorRepo.Verify(r => r.Create(armor), Times.Once);

		}

		[Test]
		public void CreateArmorTestWithInCorrectName()
		{
			var armor = new Armor() { Name = "?:asdds" };
			//ACT
			try
			{
				ArmorLogic.Create(armor);
			}
			catch
			{


			}

			//ASSERT
			mockArmorRepo.Verify(r => r.Create(armor), Times.Never);

		}


		[Test]
		public void CreateArmorTestWithCorrectLenghtName()
		{
			var armor = new Armor() { Name = "VAlamiii"};
			//ACT
			ArmorLogic.Create(armor);

			//ASSERT
			mockArmorRepo.Verify(r => r.Create(armor), Times.Once);

		}

		[Test]
		public void CreateArmorTestWithInCorrectLenghtName()
		{
			var armor = new Armor() { Name = "a"};
			//ACT
			try
			{
				
				ArmorLogic.Create(armor);
			}
			catch
			{


			}

			//ASSERT
			mockArmorRepo.Verify(r => r.Create(armor), Times.Never);

		}

		[Test]
		public void GetAverageDefenseTest()
		{
			var result = ArmorLogic.GetAverageDefence();

			double expected = 300;

			//Assert

			Assert.That(result, Is.EqualTo(expected));
		}
	}
}
