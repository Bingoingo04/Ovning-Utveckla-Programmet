namespace Övning_Utveckla_Programmet
{
	class WordGuessingGame
	{
		static string[] words = { "apple", "banana", "cherry", "date", "elderberry" };
		static Random random = new Random();

		static int highScore = 0;
		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("\nWord Guessing Game");
				Console.WriteLine("1. Play Game");
				Console.WriteLine("2. Exit");
				Console.Write("Enter your choice: ");

				string choice = Console.ReadLine();

				if (choice == "1")
				{
					PlayGame();
				}
				else if (choice == "2")
				{
					break;
				}
				else
				{
					Console.WriteLine("Invalid choice. Please try again.");
				}
			}
		}

		static void PlayGame()
		{
			int gameScore = 0;

			string wordToGuess = words[random.Next(words.Length)];
			char[] guessedWord = new char[wordToGuess.Length];
			for (int i = 0; i < guessedWord.Length; i++)
			{
				guessedWord[i] = '_';
			}

			int attemptsLeft = 6;
			Console.WriteLine("Type exit to quit game");
			while (attemptsLeft > 0)
			{
				Console.WriteLine($"Word: {new string(guessedWord)}");
				Console.WriteLine($"Attempts left: {attemptsLeft}");
                Console.Write("Guess a letter: ");

				string userInput = Console.ReadLine().ToLower();
				//first char in userInput is the guess.
				char guess = userInput[0];

				bool correctGuess = false;

				if (userInput == "exit")
				{
					//break the while loop and go back to home screen
					break;
				}

				for (int i = 0; i < wordToGuess.Length; i++)
				{
					if (wordToGuess[i] == guess)
					{
						guessedWord[i] = guess;
						correctGuess = true;
					}
				}

				if (!correctGuess)
				{
					attemptsLeft--;
					Console.WriteLine("Incorrect guess!");
				}
				else
				{
					gameScore += attemptsLeft;
					if (gameScore > highScore)
					{
						highScore = gameScore;
                    }
					Console.WriteLine(gameScore + " | " + highScore);
				}

				if (new string(guessedWord) == wordToGuess)
				{
					Console.WriteLine($"Congratulations! You guessed the word: {wordToGuess}");
					Console.WriteLine($"Score: {gameScore} | HighScore: {highScore}");
					return;
				}
			}

			Console.WriteLine($"Game over! The word was: {wordToGuess}");
			Console.WriteLine($"Score: {gameScore} | HighScore: {highScore}");

		}
	}
}
