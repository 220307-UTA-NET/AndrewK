namespace FunctionTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program starting....");

            NewFunction();

            Console.WriteLine("Currently running in Main()");

            PrintValue(4);

            string returned;
            returned = GetString();
            Console.WriteLine("Returned string: " + returned);

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    NewFunction();
                }
            }
            
            // Finding prime numbers up to 100
//            int i,j;
//            for(i = 2; i < 100; i++)
//            {
//                for(j = 2; j <= (i/j); j++)
//                {
//                    if((i%j) == 0)  // if(!(i%j))
//                    {
//                        break;  // if factor found, not a prime number
//                    }
//                }
//                if(j > (i/j))
//                {
//                    Console.WriteLine(i + " is a prime number.");
//                }
//            }

            // Function to look for repeated letter in a string
            string newString = "abcdefgab";
            for(int s = 0; s <= newString.Length; s++)
            {
                for(int t = s+1; t < newString.Length; t++)
                {
                    if(newString[s] == newString[t])
                    {
                        Console.WriteLine(newString[s] + " is repeated.");
                    }        
                }
            }

        }

        static void NewFunction()
        {
            Console.WriteLine("Currenty running NewFunction()");
        }

        static void PrintValue(int num)
        {
            Console.WriteLine(num);
        }

        static string GetString()
        {
            string x = "Hello World!";
            return x;
        }

    }
}