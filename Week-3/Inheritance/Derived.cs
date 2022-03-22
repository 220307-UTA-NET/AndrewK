namespace Inheritance
{
    public class Derived : Base
    {
        //Fields
        public string derivedString;

        // Constructors
        public Derived()
        {
            this.derivedString = "Derived";
        }

        // Methods

        // Method Overriding is a method that lets us invoke the function/method of a base/super class in another derived/sub class
        // Creating a method in the derived class with the same name as the base class

        public override void Speak()    // "override" is required to extend or modify the virtual method
        {
            Console.WriteLine("I am a Derived type object.");
        }

        // All override members
        // - Provide a new implementation of an inherited method
        // - Must have the same signature as the inherited method 
        //      (signature is made of the return type, method name, and parameters)
        // - Both methods must be virtual or override
        // - Must NOT use static or virtual to override a method

        public override void Speak(string s)
        {
            Console.WriteLine("THis is from Derived class: " + s);
        }
    }

}