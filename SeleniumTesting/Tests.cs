using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Diagnostics;
using Tools;
namespace SeleniumTesting
{
    public class Tests
    {
        static IWebDriver driverFirefox;
        [SetUp]
        public void Setup()
        {
            driverFirefox = new FirefoxDriver();
        }
        [Test]
        public void ForEachTest()
        {
            //Arrange
            //Open page
            driverFirefox.Navigate().GoToUrl("https://playtictactoe.org/");

            //Dissable cookie
            var cookieDiv = driverFirefox.FindElement(By.XPath("//div[@class='cookies']"));
            var cookieButton = cookieDiv.FindElement(By.Id("consent"));
            cookieButton.Click();


            //find the board
            var board = driverFirefox.FindElements(By.XPath("//div[@class='game']//div[@class='board']//*"));


            //Act
            //play the game
            for(int index = 0; index < board.Count; index+= 2)
            {
                try
                {
                    board[index].Click();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
            }
           
            //Assert 
            var robotScore = driverFirefox.FindElement(By.ClassName("player2"))
                .FindElement(By.ClassName("score")).Text;
            driverFirefox.Quit();
            Assert.AreEqual(robotScore, "1");
           
        }

        [Test]
        public void RandomPositionTest()
        {
            //Arrange
            //Open page
            driverFirefox.Navigate().GoToUrl("https://playtictactoe.org/");

            //Dissable cookie
            var cookieDiv = driverFirefox.FindElement(By.XPath("//div[@class='cookies']"));
            var cookieButton = cookieDiv.FindElement(By.Id("consent"));
            cookieButton.Click();
           
            
            //find the board
            var board = driverFirefox.FindElements(By.XPath("//div[@class='game']//div[@class='board']//*"));

            string scoresPlayerone;
            string robotScore;
            int clickPosition;
            //get the scores
          
            //Act
            //play the game
            while (true)
            {
                clickPosition = RandomNumberGenerator.RandomNumberEven(0, 17);

                board[clickPosition].Click();

                //get the score of player1
                scoresPlayerone = driverFirefox.FindElement(By.ClassName("player1"))
                .FindElement(By.ClassName("score")).Text;

                //get the score of robot
                robotScore = driverFirefox.FindElement(By.ClassName("player2"))
                .FindElement(By.ClassName("score")).Text;

                if (!scoresPlayerone.Equals("0") || !robotScore.Equals("0"))
                    break;
            }
            driverFirefox.Quit();
            //Assert 

            Assert.AreEqual(robotScore, "1");
           
        }
    }
}