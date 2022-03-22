using System;   // For console
using System.Collections.Generic;   // For data structures
using System.IO;    // For File class

namespace FileInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an array of strings
            string[] text = {"Hi", "Hello"};
        
            // In Bash, take this string "text", and convert it to a stream of data
            //echo "text" >> ./filename.txt
            // > or >> is a stream redirect, and we redirect to a target file

            // Hold the file path in memory as a string
            string path = @".\TestFile.txt"; // By default the file will be created in the same folder as the .dll and .exe

            // Test if the target file exists yet
            if(!File.Exists(path))
            {   
                // Create and write to the file
                File.WriteAllLines(path, text);
            }

            // If the file already exists
            if(File.Exists(path))
            {
                // Open and append to the file
                File.AppendAllLines(path, text);
            }

            // Reading from target file to an array of string
            string[] readText = File.ReadAllLines(path) ;
            
            // Iterate each element in the array and print it out on console
            foreach(string s in readText)
            {
                Console.WriteLine(s);
            }
    
            Person TheGuy = new Person("Zhixin", 65.4, 21);
            Console.WriteLine(TheGuy.name);
            Console.WriteLine("TheGuy is " + TheGuy.age + " years old.");
            Console.WriteLine("TheGuy grew up and is now " + TheGuy.GrowUp() + " years old.");
            Console.WriteLine("TheGuy is still " + TheGuy.age + " years old.");
        
            //Person SecondGuy = new Person();
            //Console.WriteLine("SecondGuy is " + SecondGuy.name);
            //Console.WriteLine("SecondGuy is " + SecondGuy.height + " inches tall.");
            //Console.WriteLine("SecondGuy is " + SecondGuy.age + " years old");

            Person ThirdGuy = new Person("Kevin", 65.4);
            Console.WriteLine("ThirdGuy is " + ThirdGuy.age + " years old.");
            ThirdGuy.GrowUp();
            Console.WriteLine("ThirdGuy grew up and is now " + ThirdGuy.age + " years old.");

            Person TheOtherGuy = new Person("Dan", 24);
            Console.WriteLine("TheOtherGuy is " + TheOtherGuy.height + " inches tall.");
            TheOtherGuy.Shrink();
            Console.WriteLine("TheOtherGuy shrank and is now " + TheOtherGuy.height + " inches tall.");

        }
    }

}