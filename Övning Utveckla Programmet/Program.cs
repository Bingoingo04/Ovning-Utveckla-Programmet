﻿using System.Diagnostics.Metrics;

namespace Övning_Utveckla_Programmet
{
    class WordGuessingGame
    {
        static string[] wordsEasy = { "ball", "car", "earn", "run", "toe" };
        static string[] wordsMedium = { "plenty", "arrow", "office", "radio", "Window" };
        static string[] wordsHard = { "apple", "banana", "cherry", "date", "elderberry" };
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
