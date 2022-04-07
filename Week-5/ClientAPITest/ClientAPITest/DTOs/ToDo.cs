namespace ClientAPITest.DTOs
{
    // DTOs - Data Transfer Objects
    // Are not meant to model a behavior
    // Just the values of an object
    // Purpose: it is to take a value, converting it to an object, and presenting them to the user
    
    // When we start to use a Client application to communicate with a Server
    // The Server cannot use Console.Read or Console.Write
    // So all User Interaction must come through the Console Application (the Client application)
    
    public class ToDo
    {
        // Fields
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

    }
}
