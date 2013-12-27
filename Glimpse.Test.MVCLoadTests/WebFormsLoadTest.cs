using System;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Glimpse.Test.MVCLoadTests
{
    public class WebFormsLoadTest: SeleniumTest
    {
        public WebFormsLoadTest() : base("source\\Glimpse.WebForms.WingTip.Sample", 55555) { }
        
        [Fact]
        public void LoadTest()
        {
            //Arrange
            const int totalCount = 20;
            const int intervalCount = 25;
            var timer = DateTime.Now;

            // Act

            Parallel.For(0, totalCount, i =>
            {
                var driver = new ChromeDriver("C:\\");
                driver.Url = GetAbsoluteUrl("/");

                for (int j = 0; j < intervalCount; j++)
                {
                    driver.Url = GetAbsoluteUrl("/ProductList/Cars");
                    driver.Url = GetAbsoluteUrl("/ProductList/Planes");
                    driver.Url = GetAbsoluteUrl("/ProductList/Trucks");
                    driver.Url = GetAbsoluteUrl("/ProductList/Boats");
                    driver.Url = GetAbsoluteUrl("/ProductList/Rockets");
                    driver.Url = GetAbsoluteUrl("/Product/Convertible%20Car");
                    driver.Url = GetAbsoluteUrl("/Product/Old-time%20Car");
                    driver.Url = GetAbsoluteUrl("/Product/Fast%20Car");
                    driver.Url = GetAbsoluteUrl("/Product/Super%20Fast%20Car");
                    driver.Url = GetAbsoluteUrl("/Product/Old%20Style%20Racer");
                    driver.Url = GetAbsoluteUrl("/ProductList");
                }


                driver.Quit();
            });

            var timerFinish = DateTime.Now;
            var delta = timerFinish - timer;

            Console.WriteLine("Test took {0} hours, {1} minutes to run", delta.Hours, delta.Minutes);

            //Assert
            // If this test reaches this we have successfully run.
            Assert.True(true);
        }
    }
}
