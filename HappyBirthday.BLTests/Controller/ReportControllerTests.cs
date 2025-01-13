using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HappyBirthday.BL.Model;
using System.IO;

namespace HappyBirthday.BL.Controller.Tests
{
    [TestClass()]
    public class ReportControllerTests
    {
        [TestMethod()]
        public void MakeHappyBirthdayDocumentTest()
        {
            // Arrange
            CitizenController citizenController = new CitizenController();
            ReportController reportController = new ReportController();
            Report report = reportController.Report;

            report.SelectedMonth = 2;
            report.SelectedYear = DateTime.Today.Year;
            report.Poem = "Поздравительное стихотворение.";
            report.Additionally = "Дополнительная информация.";

            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                string name = Guid.NewGuid().ToString();
                report.SelectedAnniversaryCitizens.Add(new Citizen(name, report.SelectedMonth));
            }

            for (int i = 0; i < 100; i++)
            {
                string name = Guid.NewGuid().ToString();
                report.SelectedBirthdayCitizens.Add(new Citizen(name, report.SelectedMonth));
            }

            int[] weddingAges = new int[] { 20, 25, 30, 35, 40, 45, 50, 55, 60, 65 };

            for (int i = 0; i < 5; i++)
            {
                int number = rnd.Next(0, 10);
                int weddingAge = weddingAges[number];
                WeddingType weddingType = Parser.GetWeddingType(weddingAge);
                string marrieds = $"Супруги {i + 1}";
                string weddingPoem = $"Поздравление с годовщиной свадбы {i + 1}";
                number = rnd.Next(1, 30);
                DateTime weddingDate = Parser.ToDate($"{number}.{report.SelectedMonth}.{report.SelectedYear}");
                Wedding wedding = new Wedding(weddingAge, weddingType, marrieds, weddingPoem, weddingDate);
                report.Weddings.Add(wedding);
            }

            string monthName = Parser.GetMonthName(report.SelectedMonth);           
            string testPath = Directory.GetCurrentDirectory();
            report.FilePath = $"{testPath}\\поздравление {monthName} {report.SelectedYear}.docx";

            // Act				
            reportController.MakeHappyBirthdayReport();

            // Assert       
            Assert.AreEqual(true, File.Exists(report.FilePath));
        }
    }
}