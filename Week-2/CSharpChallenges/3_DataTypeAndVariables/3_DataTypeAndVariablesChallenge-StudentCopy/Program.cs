using System;

namespace _3_DataTypeAndVariablesChallenge
{
    public class Program
    {
      public static void Main(string[] args)
      {

          byte myByte = 11;
          Console.WriteLine("myByte = " + myByte);

          sbyte mySbyte = 111;
          Console.WriteLine("mySByte = " + mySbyte);

          int myInt = 22;
          Console.WriteLine("myInt = " + myInt);

          uint myUint = 222;
          Console.WriteLine("myUint = " + myUint);

          short myShort = 33;
          Console.WriteLine("myShort = " + myShort); 

          ushort myUShort = 333;
          Console.WriteLine("myUShort = " + myUShort); 

          float myFloat = 44.4F;
          Console.WriteLine("myFloat = " + myFloat); 

          double myDouble = 55.5;
          Console.WriteLine("myDouble = " + myDouble); 

          char myCharacter = 'a';
          Console.WriteLine("myCharacter = " + myCharacter); 

          bool myBool = true;
          Console.WriteLine("myBool = " + myBool); 

          string myText = "This is a text.";
          Console.WriteLine("myText = " + myText); 

          string numText = "123";
          Console.WriteLine("numText = " + numText); 
      }

      public static int Text2Num(string numText)
      {
        int number;
        bool success = int.TryParse(numText, out number);
        if(success)
        {
          Console.WriteLine(numText);
          number = int.Parse(numText);
          return number;
        }
        else
        {
          Console.WriteLine("Not an int.");
          return number;
        }
        //throw new NotImplementedException();
      }
    }
}
