using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderRobotic
{
    class Program
    {
        static void Main(string[] args)
        {

            string m1 = "\n Type a Comand of Orientation then press Enter. " +
                         "Type '+' anywhere in the text to quit:\n";

            string m2 = "Invalid Character '{0}' ";

            char ch;
            int x;

            int gX = 0;
            int gY = 0;

            // 1. Define Grid/wall Size

            Console.WriteLine("Please Enter Grid Size");

            bool loopExit = false;
            while (!loopExit)
            {
                loopExit = true;
                string WallSize = Console.ReadLine();
                string[] splitGrid = WallSize.Split(' ');

                if (splitGrid.Length != 2)
                {
                    Console.Write("The Grid X,Y values' entry invalid, try again! ");
                    loopExit = false;
                }

                else
                {
                    if (string.IsNullOrEmpty(splitGrid[0]))
                    {
                        Console.Write("The Grid X value cannot be null or empty, try again! ");
                        loopExit = false;

                    }
                    else
                    {
                        if (!int.TryParse(splitGrid[0], out x))
                        {
                            Console.Write("The Grid X value must be in correct format, try again: ");
                            loopExit = false;

                        }
                        else
                        {
                            if (int.Parse(splitGrid[0]) < 0)
                            {
                                Console.Write("The Grid X value must be +ve, try again: ");
                                loopExit = false;
                            }

                            else
                            {
                                gX = int.Parse(splitGrid[0]);
                            }

                        }

                    }

                    if (string.IsNullOrEmpty(splitGrid[1]))
                    {
                        Console.Write("The Grid Y value cannot be null or empty, try again! ");
                        loopExit = false;

                    }
                    else
                    {

                        if (!int.TryParse(splitGrid[1], out x))
                        {
                            Console.Write("The Grid Y value must be in correct format, try again: ");
                            loopExit = false;

                        }
                        else
                        {
                            if (int.Parse(splitGrid[1]) < 0)
                            {
                                Console.Write("The Grid Y value must be +ve, try again: ");
                                loopExit = false;
                            }

                            else
                            {

                                gY = int.Parse(splitGrid[1]);

                            }

                        }

                    }

                }

            }

            // 2. Entry for Spider Satrting Location and direction

            Console.WriteLine("Enter the Spider's Start Location & Heading");

            string StartPoint = Console.ReadLine();
            string[] splitStartPoint = StartPoint.Split(' ');
            int startX = int.Parse(splitStartPoint[0]);
            int startY = int.Parse(splitStartPoint[1]);
            string startHeading = (splitStartPoint[2]).ToString();


            // 3. Feed Orientation command
            Queue<char> SeqOrientations = new Queue<char>();
            int inputOri;
            Console.WriteLine(m1);
            do
            {

                inputOri = Console.Read();
                try
                {
                    ch = Convert.ToChar(inputOri);
                    if (Char.IsWhiteSpace(ch))
                    {

                        //if (ch == 0x0a)
                        //    Console.WriteLine(m1);
                    }
                    else if (ch.Equals('F'))
                    {
                        SeqOrientations.Enqueue(ch);

                    }
                    else if (ch.Equals('L'))
                    {

                        SeqOrientations.Enqueue(ch);
                    }

                    else if (ch.Equals('R'))
                    {

                        SeqOrientations.Enqueue(ch);
                    }

                    else
                        Console.WriteLine(m2, ch);
                    if (inputOri == 13)
                    {

                        Position curPosition = new Position(startX, startY, startHeading);
                        try
                        {
                            foreach (char value in SeqOrientations)
                            {

                                curPosition.CurrentPostion(value);

                                if (curPosition.x > gX || curPosition.y > gY)
                                {
                                    throw new ArgumentOutOfRangeException("Orientation Commands leads to out of range grid area !");

                                }

                            }
                        }

                        catch (ArgumentOutOfRangeException outOfRange)
                        {

                            Console.WriteLine("Error: {0}", outOfRange.Message);
                        }


                        Console.WriteLine(curPosition.x + " " + curPosition.y + " " + curPosition.heading);

                        SeqOrientations.Clear();
                    }
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("{0} Value read = {1}.", e.Message, inputOri);
                    ch = Char.MinValue;
                    Console.WriteLine(m1);
                }

            } while (ch != '\r');
                        
            Console.ReadKey();

        }
 
    }
}
