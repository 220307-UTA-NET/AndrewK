// GuessingGame -- play a quick guessing game with the computer.
Console.WriteLine("Welcome to the Guessing Game!");

// While loop to ask user whether to play again or not
while(true) {
	Console.WriteLine("Enter the number for the menu option of your choice: ");
	Console.WriteLine("[1] - Play the Guessing Game.");
	Console.WriteLine("[0] - Exit.");
	
	int menu = int.Parse(Console.ReadLine());

	// Switch statements to play the game or not	
	switch(menu) {
		// 
		case 0:
			Console.WriteLine("Good game, thanks for playing!");
			return;
		case 1:
			// Instantiate random number generator
			var rand = new Random();
	
			// Generate a random number between 0 - 10
			int number = rand.Next(11);
			//Console.WriteLine(number);


			while(true) {	
				// User prompt
				Console.WriteLine("Guess a number between 0 and 10: ");		
				// Read user input from the console then parse into an int data type variable
				int input = int.Parse(Console.ReadLine());
				Console.WriteLine("You guessed " + input);

				// If the user guessed the correct number 
				if(input == number) {
					Console.WriteLine("Congratulations! You've correctly guessed the secret number!");
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
			break;

		default:
			Console.WriteLine("Invalid input!");
			break;		
	}
}
