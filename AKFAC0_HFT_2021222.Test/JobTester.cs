using AKFAC0_HFT_2021222.Logic;
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
	public class JobTester
	{

        JobLogic joblogic;
        Mock<IRepository<Job>> mockJobRepo;

        [SetUp]
        public void Init()
        {
			//ARRANGE

			Weapon wep1 = new Weapon("Wep1", 10, 0);
			Weapon wep2 = new Weapon("Wep2", 100, 0);
			Weapon wep3 = new Weapon("Wep2", 100, 1);

			Job A = new Job(0, "AAAA", "TANK");
			A.Weapons.Add(wep1);
			A.Weapons.Add(wep2);

			mockJobRepo = new Mock<IRepository<Job>>();
            mockJobRepo.Setup(mr => mr.ReadAll()).Returns(new List<Job>()
            {
                A,
                new Job(1,"BBBB","HEALER"),
                new Job(2,"CCCC","DPS"),
                new Job(3,"DDDD","DPS"),
            }.AsQueryable());

            joblogic = new JobLogic(mockJobRepo.Object);

        }

		//create test

		[TestCase("Valaki", "TANK", true)]
		[TestCase("Pista", "versenyautoo", false)]
		[TestCase("t", "TANK", false)]
		[TestCase("Pista2", "", false)]
		public void CreateJobTest(string name, string role, bool shouldRun)
		{
			//ACT
			Job testJob = new Job() { Name=name,Role=role};

			//ASSERT
			if (shouldRun)
			{
				joblogic.Create(testJob);
				mockJobRepo.Verify(cr => cr.Create(testJob), Times.Once);
			}
			else
			{
				mockJobRepo.Verify(cr => cr.Create(testJob), Times.Never);
			}
		}


		[Test]
		public void GetAllWeaponByRoleTest()
		{
			//Act

			var result = joblogic.GetAllWeaponByRole("TANK").ToArray();


			//Assert

			Assert.That(result[0].Name == "Wep1" && result[1].Name == "Wep2");
		}

	}
}
