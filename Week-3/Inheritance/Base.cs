namespace Inheritance
{
    public class Base
    {
        // Fields
        public string baseString;

        
        // Constructors
        public Base()
        {
            this.baseString = "Base";
        }


        // Methods

        // Method Overriding is a method that lets us invoke the function/method of a base/super class in another derived/sub class
        // Creating a method in the derived class with the same name as the base class

        // <Access-Modifier> Modifier Return-Type Method-Name(Parameters)
        public virtual void Speak() // "virtual" keyword is used to identify a method to allow it to be overridden.
        {
            Console.WriteLine("Hello, I am a Base type object.");
        }

        public virtual void Speak(string s)
        {
            Console.WriteLine("This is from Base class: " + s);
        }

    }

}