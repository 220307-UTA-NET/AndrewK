using System;
using System.Collections.Generic;
using System.IO;

namespace ClassesOOP
{
    class Program
    {
        // Main
        static void Main(string[] args)
        {
            Square squareOne = new Square();

            Console.WriteLine("Square number of sides = " + squareOne.numberOfSides);
            Console.WriteLine("Square perimeter = " + squareOne.getPerimeter());

            try
            {
                Triangle triangleOne = new Triangle(1, 1, 1);
                Console.WriteLine("Trianle perimeter = " + triangleOne.Perimeter());
            }
            catch(Exception e)
            {
                Console.WriteLine("Triangle was not able to be created, invalid sides.");
            }

            Console.WriteLine("The program continues after the try-catch.");
        }

    }

}
