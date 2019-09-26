using System;

namespace Hangman
{
    class Program
    {
        static string[,] graphic = new string[,]
        {
            { "   +---+", "   |   |", "       |", "       |", "       |", "       |", "=========" },
            { "   +---+", "   |   |", "   O   |", "       |", "       |", "       |", "=========" },
            { "   +---+", "   |   |", "   O   |", "   |   |", "       |", "       |", "=========" },
            { "   +---+", "   |   |", "   O   |", "  /|   |", "       |", "       |", "=========" },
            { "   +---+", "   |   |", "   O   |", "  /|\\  |", "       |", "       |", "=========" },
            { "   +---+", "   |   |", "   O   |", "  /|\\  |", "  /    |", "       |", "=========" },
            { "   +---+", "   |   |", "   O   |", "  /|\\  |", "  / \\  |", "       |", "=========" }
        };

        static string[] wordbank = new string[]
        {
            "ant", "baboon", "badger", "bat", "bear", "beaver", "camel", "cat", "clam", "cobra", "cougar", "coyote", "crow", "deer", "dog", "donkey", "duck", "eagle", "ferret", "fox", "frog", "goat", "goose", "hawk", "lion", "lizard", "llama", "mole", "monkey", "moose", "mouse", "mule", "newt", "otter", "owl", "panda", "parrot", "pigeon", "python", "rabbit", "ram", "rat", "raven", "rhino", "salmon", "seal", "shark", "sheep", "skunk", "sloth", "snake", "spider", "stork", "swan", "tiger", "toad", "trout", "turkey", "turtle", "weasel", "whale", "wolf", "wombat", "zebra"
        };

        static void Main(string[] args)
        {
            int deathCounter = 0,
                letterCounter = 0;
            char[] guessedLetters = new char[6];
            string input;
            bool matchFound;

            // pick random animal for mystery word, and create blank space version
            var rand = new Random();
            var word = wordbank[rand.Next(wordbank.Length)];
            char[] letters = new char[word.Length];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = '_';
            }
            
            while (deathCounter < 6)
            {
                matchFound = false;
                DisplayHangman(deathCounter);
                DisplayWord(letters);
                DisplayMissedLetters(guessedLetters);

                // get a letter guess from user
                do
                {
                    Console.Write("Please enter a letter: ");
                    input = Console.ReadLine();

                } while (input.Length == 0 || !Char.IsLetter(input[0]));

                Console.WriteLine();

                // see if word contains letter
                for (int i = 0; i < word.Length; i++)
                {
                    if (input[0] == word[i])
                    {
                        letterCounter++;
                        letters[i] = word[i];
                        matchFound = true;
                    }
                }

                // if letter isn't found in word, add part to hangman
                if (!matchFound)
                {
                    guessedLetters[deathCounter] = input[0];
                    deathCounter++;
                }

                // check win condition
                if (letterCounter == word.Length)
                {
                    DisplayWord(letters);
                    Console.WriteLine("You won, good job!");
                    break;
                }

                // check death condition
                if (deathCounter == 6)
                {
                    DisplayHangman(deathCounter);
                    Console.WriteLine("You're dead, sorry!");
                    Console.WriteLine($"The word was {word}.");
                    break;
                }
            }

        }

        static void DisplayHangman(int counter)
        {
            for (int i = 0; i < graphic.GetLength(1); i++)
            {
                Console.WriteLine(graphic[counter, i]);
            }
          
            Console.WriteLine();
        }

        static void DisplayWord(char[] word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                Console.Write(word[i] + "  ");
            }

            Console.WriteLine();
        }

        static void DisplayMissedLetters(char[] letters)
        {
            Console.Write("Missed letters: ");
            for (int i = 0; i < letters.Length; i++)
            {
                if (Char.IsLetter(letters[i]))
                {
                    Console.Write(letters[i] + ", ");
                }
                
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
