using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using MasterClassTestAutomation.PageObject;
using MasterClassTestAutomation.Models;

namespace MasterClassTestAutomation
{
    public class TestSuite
    {
        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver(); 
            driver.Manage().Window.Maximize();
            driver.Navigate()
                .GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");


            IWebElement textInput = driver.FindElement(By.Id("my-text-id"));
            textInput.SendKeys("Joseph");

            IWebElement password = driver.FindElement(By.Name("my-password"));
            password.SendKeys("mysecreat Password");

            IWebElement textArea = driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys("Welcome everyone");

            IWebElement dropdown = driver.FindElement(By.Name("my-select"));
            dropdown.SendKeys("Two");

            IWebElement dataList = driver.FindElement(By.Name("my-datalist"));
            dataList.SendKeys("Chicago");

            IWebElement file = driver.FindElement(By.Name("my-file"));
            var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent + "\\TestData\\file.txt";

            file.SendKeys(path);

            IWebElement slider = driver.FindElement(By.Name("my-range"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("$(arguments[0]).val(arguments[1]).change();", slider, 0);

            Thread.Sleep(5000);
            driver.Quit(); 
        }


        [Test]
        public void Test2()
        {
            IWebDriver driver = new ChromeDriver(); 
            driver.Manage().Window.Maximize();
            driver.Navigate()
                .GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");


            IReadOnlyCollection<IWebElement> listOfElements = 
                driver.FindElements(By.XPath("//*[@class= 'form-control']"));

            listOfElements.First().SendKeys("Joseph");

            listOfElements.ElementAt(1).SendKeys("mysecreat Password");

            listOfElements.ElementAt(2).SendKeys("Welcome everyone");

            IWebElement dropdown = driver.FindElement(By.Name("my-select"));
            dropdown.SendKeys("Two");

            listOfElements.ElementAt(5).SendKeys("Chicago");

            var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent + "\\TestData\\file.txt";

            listOfElements.ElementAt(6).SendKeys(path);

            IWebElement slider = driver.FindElement(By.Name("my-range"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("$(arguments[0]).val(arguments[1]).change();", slider, 0);

            Thread.Sleep(5000);
            driver.Quit(); 
        }

        [Test]
        public void Test3()
        {
            IWebDriver driver = new ChromeDriver(); 
            driver.Manage().Window.Maximize();
            var reader = Dbconnect.GetTblData("select * from webform");
            //Deserilize
            var dataFromDb = reader.Select(db => new ColName()
            {
                 Id = (int)db["Id"],
                 Url = (string)db["Url"],
                 TextInput = (string)db["TextInput"],
                 Password = (string)db["Password"],
                 TextArea = (string)db["TextArea"],
                 DropDown = (string)db["DropDown"],
                 DataList = (string)db["DataList"],
                 Range = (int)db["Range"]
            });

            driver.Navigate()
                .GoToUrl(dataFromDb.First().Url);

            IReadOnlyCollection<IWebElement> listOfElements =
                driver.FindElements(By.XPath("//*[@class= 'form-control']"));


            listOfElements.First().SendKeys(dataFromDb.First().TextInput);

            listOfElements.ElementAt(1).SendKeys(reader.FirstOrDefault()?.ElementAt(3).Value.ToString());

            listOfElements.ElementAt(2).SendKeys(reader.FirstOrDefault()?.ElementAt(4).Value.ToString());

            IWebElement dropdown = driver.FindElement(By.Name("my-select"));
            dropdown.SendKeys(reader.FirstOrDefault()?.ElementAt(5).Value.ToString());

            listOfElements.ElementAt(5).SendKeys(reader.FirstOrDefault()?.ElementAt(6).Value.ToString());

            var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent + "\\TestData\\file.txt";

            listOfElements.ElementAt(6).SendKeys(path);

            IWebElement slider = driver.FindElement(By.Name("my-range"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("$(arguments[0]).val(arguments[1]).change();", slider,
                reader.FirstOrDefault()?.ElementAt(7).Value.ToString());

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        public void TestWithPageObject()
        {
            IWebDriver driver = new ChromeDriver(); //Open browser
            driver.Manage().Window.Maximize(); //Maximizing the browser
            var reader = Dbconnect.GetTblData("select * from webform"); //Database

            var db = reader.Select(x => new ColName 
            {
                Id = (int)x["Id"],
                Url = (string)x["Url"],
                TextInput = (string)x["TextInput"],
                Password = (string)x["Password"],
                TextArea = (string)x["TextArea"],
                DropDown = (string)x["DropDown"],
                DataList = (string)x["DataList"],
                Range = (int)x["Range"],
            });//Deserialization

            driver.Navigate()
                .GoToUrl(db.First().Url);

            WebFormPage wfp = new WebFormPage(driver);

            var path = Directory.GetParent(Directory.GetCurrentDirectory())?
                .Parent?.Parent + "\\TestData\\file.txt";

            wfp.InteractWithElement(Num.Zero, db.First().TextInput!)
               .InteractWithElement(Num.One, db.First().Password!)
               .InteractWithElement(Num.Two, db.First().TextArea!)
               .InteractWithDropdown(db.First().DropDown!)
               .InteractWithElement(Num.Five, db.First().DataList!)
               .InteractWithElement(Num.Six, path)
               .InteractWithRange(db.First().Range!); //PageObject

            Thread.Sleep(5000);
            driver.Quit();
        }
    }
} 