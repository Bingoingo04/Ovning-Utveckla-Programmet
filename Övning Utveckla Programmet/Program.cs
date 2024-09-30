namespace Övning_Utveckla_Programmet
{
    class WordGuessingGame
    {
        static string[] words = { "apple", "banana", "cherry", "date", "elderberry" };
        static Random random = new Random();

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
            string wordToGuess = words[random.Next(words.Length)];
            char[] guessedWord = new char[wordToGuess.Length];
            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }

            int attemptsLeft = 6;

            while (attemptsLeft > 0)
            {
                Console.WriteLine($"\nWord: {new string(guessedWord)}");
                Console.WriteLine($"Attempts left: {attemptsLeft}");
                Console.Write("Guess a letter: ");

                char guess = Console.ReadLine().ToLower()[0];
                bool correctGuess = false;

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

                if (new string(guessedWord) == wordToGuess)
                {
                    Console.WriteLine($"Congratulations! You guessed the word: {wordToGuess}");
                    return;
                }
            }

            Console.WriteLine($"Game over! The word was: {wordToGuess}");
        }
    }
}
