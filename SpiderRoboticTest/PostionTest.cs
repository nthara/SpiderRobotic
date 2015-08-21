using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiderRobotic;

namespace SpiderRoboticTest
{
    [TestClass]
    public class PostionTest
    {
        [TestMethod]
        public void Position_WithValidInputs()
        {
            // arrange
            int gridX = 7;
            int gridY = 15;
            int spiderInitX = 4;
            int spiderInitY = 10;
            string spiderInitHeading = "Left";
            string orientation = "FLFLFRFFLF";
            string expected = "5 7 Right";
            // act ....

            char[] orien = orientation.ToCharArray();

            Position curPosition = new Position(spiderInitX, spiderInitY, spiderInitHeading);
            try
            {
                foreach (char value in orien)
                {

                    curPosition.CurrentPostion(value);

                    if (curPosition.x > gridX || curPosition.y > gridY)
                    {
                        throw new ArgumentOutOfRangeException("Orientation Commands leads to out of range grid area !");

                    }

                }
            }

            catch (ArgumentOutOfRangeException outOfRange)
            {

                Console.WriteLine("Error: {0}", outOfRange.Message);
            }

            // assert
            string actual = curPosition.x + " " + curPosition.y + " " + curPosition.heading;

            Assert.AreEqual(expected, actual, "Spider not located correctly");
        }
    }
}
