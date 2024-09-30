using System.Diagnostics.Metrics;

namespace Övning_Utveckla_Programmet
{
    class WordGuessingGame
    {
        static string[] wordsEasy = { "ball", "car", "earn", "run", "toe" };
        static string[] wordsMedium = { "plenty", "arrow", "office", "radio", "Window" };
        static string[] wordsHard = { "apple", "banana", "cherry", "date", "elderberry" };
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
                    int settings = Difficult();
                    PlayGame(settings);
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

        static void PlayGame(int settings)
        {
            // Sets up the difficulty based on the return from Difficuly()
            int gameScore = 0;
            string wordToGuess = wordsHard[random.Next(wordsHard.Length)];
            char[] guessedWord = new char[wordToGuess.Length];
            int attemptsLeft = 0;

            if (settings == 1)
            {
                wordToGuess = wordsEasy[random.Next(wordsEasy.Length)];
                guessedWord = new char[wordToGuess.Length];
                attemptsLeft = 6;
            }
            else if (settings == 2)
            {
                wordToGuess = wordsMedium[random.Next(wordsMedium.Length)];
                guessedWord = new char[wordToGuess.Length];
                attemptsLeft = 4;
            }
            else if (settings == 3)
            {
                wordToGuess = wordsHard[random.Next(wordsHard.Length)];
                guessedWord = new char[wordToGuess.Length];
                attemptsLeft = 3;
            }

            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }

            Console.WriteLine("Type exit to quit game");
            while (attemptsLeft > 0)
            {
                Console.WriteLine($"Word: {new string(guessedWord)}");
                Console.WriteLine($"Attempts left: {attemptsLeft}");
                Console.Write("Guess a letter: ");

                string userInput = Console.ReadLine().ToLower();
                //first char in userInput is the guess.
                char guess = ' ';
                if (userInput.Length > 0)
                {
                    guess = userInput[0];
                }
                else
                {
                    //no input, go back to top of while loop
                    continue;
                }
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
        
        static int Difficult()
        {
            int userChoice = 0;
            while (userChoice == 0 && userChoice <= 3)
            {

                Console.WriteLine("              Välj svårighetsgrad");
                Console.WriteLine();
                Console.WriteLine("1.Lätt");
                Console.WriteLine("2.Medium");
                Console.WriteLine("3.Svårt");

                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());

                }
                catch (System.FormatException)
                {

                    Console.WriteLine("Fel inmatning, försök igen.");
                }
                Console.Clear();
                Console.WriteLine();

                switch (userChoice)
                {
                    case 1:
                        Console.Write("1. Du valde: Lätt\n");
                        break;
                    case 2:
                        Console.Write("2. Du valde: Medium\n");
                        break;
                    case 3:
                        Console.Write("3. Du valde: Svårt\n");
                        break;
                    default:
                        break;
                }

            }

            return userChoice;
        }
    }
}


