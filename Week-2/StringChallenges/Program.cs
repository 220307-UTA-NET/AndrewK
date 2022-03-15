
string word;    // Declare a string variable
int number; // Declare an int variable
Console.WriteLine("Please enter your message and press Enter.");
word = Console.ReadLine();
Console.WriteLine("Please enter a number LESS THAN the length of your string and press Enter.");
number = int.Parse(Console.ReadLine()); // Parsing string into int

char letter;    // Declare a char variable
Console.WriteLine("For which character should I search in your original message?");
letter = char.Parse(Console.ReadLine());    // Parsing string into char; only accepts 1 char character

Console.Write("Please enter your first name: ");
string firstName = Console.ReadLine();
Console.Write("Please enter your last name: ");
string lastName = Console.ReadLine();
Console.WriteLine("User name: " + firstName + " " + lastName);  // Concatenate user first and last name
Console.WriteLine("User initial: " + firstName.Substring(0,1) + lastName.Substring(0,1));   // Print user first and last name initial
Console.WriteLine("User first name and first two letters of user last name: " + firstName + lastName.Substring(0,2));   // Print user first name and first two letters of last name
Console.WriteLine("Lenght of user last name: " + lastName.Length);  // Print user last name length