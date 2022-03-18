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

            Console.WriteLine(squareOne.numberOfSides);
            Console.WriteLine(squareOne.getPerimeter());
        }

    }

}
