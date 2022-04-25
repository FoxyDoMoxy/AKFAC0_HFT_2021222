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
		public void CreateJobTestWithCorrectRole()
		{
			var job = new Job() {Name="Test Mage",Role="DPS" };
			//ACT
			joblogic.Create(job);

			//ASSERT
			mockJobRepo.Verify(r => r.Create(job), Times.Once);

		}

		[Test]
		public void CreateJobTestWithInCorrectRole()
		{
			var job = new Job() { Name = "Test Mage", Role = "Student" };
			//ACT
			try
			{
				joblogic.Create(job);
			}
			catch
			{

	
			}

			//ASSERT
			mockJobRepo.Verify(r => r.Create(job), Times.Never);

		}


		[Test]
		public void CreateJobTestWithCorrectLenghtName()
		{
			var job = new Job() { Name = "VAlamiii", Role = "DPS" };
			//ACT
			joblogic.Create(job);

			//ASSERT
			mockJobRepo.Verify(r => r.Create(job), Times.Once);

		}

		[Test]
		public void CreateJobTestWithInCorrectLenghtName()
		{
			var job = new Job() { Name = "a", Role = "TANK" };
			//ACT
			try
			{
				joblogic.Create(job);
			}
			catch
			{


			}

			//ASSERT
			mockJobRepo.Verify(r => r.Create(job), Times.Never);

		}

	}
}
