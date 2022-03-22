using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Base myBase = new Base();
            Console.WriteLine("myBase.baseString = " + myBase.baseString);
            myBase.Speak();
            myBase.Speak("new String");

            Derived myDerived = new Derived();
            Console.WriteLine("myDerived.derivedString = " + myDerived.derivedString);
            Console.WriteLine("myDerived.baseString = " + myDerived.baseString);
            myDerived.Speak();
            myDerived.Speak("new String");
        }

    }

}