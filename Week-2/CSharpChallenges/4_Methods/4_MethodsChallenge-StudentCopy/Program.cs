﻿using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1
            string name = GetName();
            GreetFriend(name);

            //2
            double result1 = GetNumber();
            double result2 = GetNumber();
            int action1 = GetAction();
            double result3 = DoAction(result1, result2, action1);

            System.Console.WriteLine($"The result of your mathematical operation is {result3}.");


        }

        public static string GetName()
        {
            string name = Console.ReadLine();
            return name;
            //throw new NotImplementedException();
        }

        public static void GreetFriend(string name)
        {
            //Greeting should be: Hello, nameVar. You are my friend
            //Ex: Hello, Jim. You are my friend
            string text = "Hello " + name + ". You are my friend";
            return text;
            //throw new NotImplementedException();
        }

        public static double GetNumber()
        {
            //Should throw FormatException if the user did not input a number
            try
            {
                double number = double.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                throw ex;
            }

            return number;
            //throw new NotImplementedException();
        }

        public static int GetAction()
        {
            int input;
            while(true)
            {
                Console.WriteLine("Enter: 1)add, 2)subtract, 3)multiply, or 4)divide");

                switch (input) 
                {
                    case(1):


                }
            }
            //throw new NotImplementedException();
        }

        public static double DoAction(double x, double y, int z)
        {
            throw new NotImplementedException();
        }
    }
}
