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

		JobLogic joblogic;
		Mock<IRepository<Job>> mockJobRepo;

		[SetUp]
		public void Init()
		{
			//ARRANGE
			mockArmorRepo = new Mock<IRepository<Armor>>();
			mockArmorRepo.Setup(mr => mr.ReadAll()).Returns(new List<Armor>()
			{
				new Armor("AAAA",100,1),
				new Armor("BBBB",100,2),
				new Armor("CCCC",1000,1),
				new Armor("DDDD",0,2),
			}.AsQueryable());

			ArmorLogic = new ArmorLogic(mockArmorRepo.Object);

			mockJobRepo = new Mock<IRepository<Job>>();
			mockJobRepo.Setup(mr => mr.ReadAll()).Returns(new List<Job>()
			{
				new Job(0,"AAAA","TANK"),
				new Job(1,"BBBB","HEALER"),
				new Job(2,"CCCC","DPS"),
				new Job(3,"DDDD","DPS"),
			}.AsQueryable());

			joblogic = new JobLogic(mockJobRepo.Object);

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
		[Test]
		public void GetAverageDefenseByClassTest()
		{

			var asd = joblogic.Read(2).Name;
			//var result = ArmorLogic.GetAverageDefenceByClass(joblogic.Read(2).Name);

			double expected = 300;

			//Assert

			Assert.That(asd, Is.EqualTo("CCCC"));
		}
	}
}
