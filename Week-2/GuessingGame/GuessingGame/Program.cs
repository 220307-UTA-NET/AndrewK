namespace GuessingGame {
	class Program {
		static void Main(string[] args) {
		// GuessingGame -- play a quick guessing game with the computer.
		Console.WriteLine("Welcome to the Guessing Game!");

		//var rand = new Random();	// Instantiate random number generator

		// While loop to ask user whether to play again or not
		while(true) {
			Console.WriteLine("Enter the number for the menu option of your choice: ");
			Console.WriteLine("[1] - Play the Guessing Game.");
			Console.WriteLine("[2] - Math Challenge.");
			Console.WriteLine("[0] - Exit.");
			
			int menu = int.Parse(Console.ReadLine());

			// Switch statements to play the game or not	
			switch(menu) {
				// Exit the app
				case 0:
					// Prompt to clear the screen
					Console.WriteLine("Thank you for playing!");
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					Console.Clear();;
					return;
				// Play the game
				case 1:
					GuessingGame();
					break;
				case 2:
					AdditionChallenge();
					break;
				// If input is not recognized	
				default:
					Console.WriteLine("Invalid input!");

					// Prompt to clear the screen
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					Console.Clear();
					
					break;		
				}	
			}
		}
		
		static void GuessingGame() {
			// Instantiate random number generator
			var rand = new Random();

			// Generate a random number between 0 - 10
			int number = rand.Next(11);
			//Console.WriteLine(number);

			// Ask user for a number
			while(true) {	
				// User prompt
				Console.WriteLine("Guess a number between 0 and 10: ");		

				// Try-Catch Block
				int input;
				try {
					// Read user input from the console then parse into an int data type variable
					input = int.Parse(Console.ReadLine());
				}
				catch (System.Exception ex)
				{
					Console.WriteLine(ex.Message);
					//Console.WriteLine("Bad input detected. Returning to menu.");
					break;
				}

				Console.WriteLine("You guessed " + input);

				// If the user guessed the correct number 
				if(input == number) {
					Console.WriteLine("Congratulations! You've correctly guessed the secret number!");
					
					// Prompt to clear the screen
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					Console.Clear();

					break;
				}
				// If the user guessed too high
				else if(input > number) { 
					Console.WriteLine("You've guessed too high!");
				}
				// If the user guessed too low
				else {
					Console.WriteLine("You've guessed too low!");
				}
			}	
		}

		static void AdditionChallenge() {
			var rand = new Random();	// Generating random values for the problem
			int num1 = rand.Next(101);
			int num2 = rand.Next(101);

			int solution = num1 + num2;	// Finding the correct solution

			Console.WriteLine("Welcome to the Addition Challenge!");
			
			while(true) {
				Console.WriteLine("Your question is: ");
				Console.WriteLine(num1 + " + " + num2 + " = ?");
				Console.Write("Enter your answer: ");

				// Unit Test
				string userGuess = Console.ReadLine();
				int intUserGuess;

				bool success = int.TryParse(userGuess, out intUserGuess);	// Accepting the users solution

				if(success)
				{
					intUserGuess = int.Parse(userGuess);
				}
				else
				{
					Console.WriteLine("Invalid input. Exiting Addition Challenge.");
					break;
				}

				if(solution == intUserGuess) {
					Console.WriteLine("You got it!");
					
					// Prompt to clear the screen
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					Console.Clear();

					break;
				}
				else {
					Console.WriteLine("Not quite, you were off by: " + Math.Abs(solution - intUserGuess));
				}
			}
		}
	}
}	