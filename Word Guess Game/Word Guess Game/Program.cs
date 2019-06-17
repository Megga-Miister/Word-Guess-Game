using System;
using System.IO;

namespace Word_Guess_Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            HomeNavigation();
        }

        static void HomeNavigation()
        {
            string filePath = "../../../guessinggamewords.txt";
            string lettersFilePath = "../../../guessedletters.txt";
            string[] words = new string[] { "FRODO", "GANDALF", "SAMWISE", "ARAGORN", "LEGOLAS", "GIMLI", "BOROMIR", "PEREGRIN", "MERIADOC" };
            string greetingMessage = PesistWordFile(filePath, words);

            Console.WriteLine($"{greetingMessage}");

            Console.WriteLine("Please choose from one of the following options:\n");
            Console.WriteLine("     1) Start Game \n     2) View Characters \n     3) Add Character \n     4) Remove Character \n     5) Exit Game");

            string userSelection = Console.ReadLine();
            int actionSelection = Convert.ToInt32(userSelection);

            switch (actionSelection)
            {
                case 1:
                    StartGame(filePath, lettersFilePath);
                    DeleteFile(lettersFilePath);
                    ReturnToMenu();
                    break;

                case 2:
                    string[] characterListFromFile = ReadFile(filePath);
                    string characterList = String.Join(", ", characterListFromFile);
                    Console.WriteLine($"\n{characterList}\n");

                    ReturnToMenu();
                    break;

                case 3:
                    Console.WriteLine("\nPlease write the name of the character you would like to add:");
                    string newCharacter = Console.ReadLine();
                    string characterToFile = newCharacter.ToUpper();

                    AddWordToFile(filePath, characterToFile);
                    Console.WriteLine($"\nYou have added {characterToFile} to the characters list.\n");
                    ReturnToMenu();
                    break;

                case 4:
                    Console.WriteLine("\nPlease write the name of the character you would like to remove:");
                    string removeCharacter = Console.ReadLine();
                    string characterFromFile = removeCharacter.ToUpper();

                    string removeMessage = RemoveWordFromFile(characterFromFile);
                    Console.WriteLine(removeMessage);
                    ReturnToMenu();
                    break;

                case 5:
                    ExitGame();
                    break;

                default:
                    ExitGame();
                    break;

            }
        }

        public static void CreateWordFile(string filePath, string[] words)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {

                foreach (string word in words)
                {
                    if (word != null)
                    {
                        sw.WriteLine(word);
                    }
                }
            }
        }

        static string PesistWordFile(string filePath, string[] words)
        {
            if (!File.Exists(filePath))
            {
                CreateWordFile(filePath, words);
                return "Welcome to the Lord of the Rings Character Guessing Game!\n";
            }
            else
            {
                return "Welcome back to the Lord of the Rings Character Guessing Game!\n";
            }
        }

        public static void AddWordToFile(string filePath, string newWord)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(newWord);
            }
        }

        static void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        static string RemoveWordFromFile(string upperCaseWord)
        {
            string filePath = "../../../guessinggamewords.txt";
            string statusMessage = "";
            string[] fileWords = ReadFile(filePath);

            for (int i = 0; i < fileWords.Length; i++)
            {
                if (fileWords[i] == upperCaseWord)
                {
                    fileWords[i] = "";
                    statusMessage = ($"{upperCaseWord} has been removed.\n");
                }
                else
                {
                    statusMessage = ($"{upperCaseWord} could not be found.\n");
                }
            }

            CreateWordFile(filePath, fileWords);
            return statusMessage;
        }

        public static string[] ReadFile(string filePath)
        {
            string[] wordsInFile = File.ReadAllLines(filePath);
            return wordsInFile;
        }

        static void ExitGame()
        {
            Environment.Exit(0);
        }

        static void StartGame(string filePath, string lettersFilePath)
        {
            char[] preppedWordForGame = SelectRandomWordFromFile(filePath);
            char[] hiddenWord = BlankWordDisplay(preppedWordForGame);
            char[] guessedWord = WordDisplay(preppedWordForGame, ' ');

            Console.WriteLine($"\nPlease try to guess the following character: {hiddenWord}");

            while (guessedWord != preppedWordForGame)
            {
                char currentLetterGuess = UserLetterGuess();
                WordDisplay(preppedWordForGame, currentLetterGuess);
                LetterGuessList(lettersFilePath, currentLetterGuess);
            }

            Console.WriteLine("Congrats!\n");
        }

        static char[] SelectRandomWordFromFile(string filePath)
        {
            Random randomGenerator = new Random();

            string[] wordsFromFile = ReadFile(filePath);
            int randomIndex = randomGenerator.Next(wordsFromFile.Length);
            string randomWord = wordsFromFile[randomIndex];

            char[] preparedWordForGame = randomWord.ToCharArray();
            return preparedWordForGame;
        }


        static void LetterGuessList(string lettersFilePath, char letterGuess)
        {
            string saveInFileLetter = letterGuess.ToString();
            AddWordToFile(lettersFilePath, saveInFileLetter);

            string[] guessArray = ReadFile(lettersFilePath);
            string guessList = String.Join(" ", guessArray);

            Console.WriteLine($"\nYou have guessed:{guessList}\n");
        }

        static void ReturnToMenu()
        {
            Console.WriteLine("Would you like to return to main menu or exit the game? (MENU/EXIT)\n");

            string userResponse = Console.ReadLine();
            string userDecision = userResponse.ToUpper();

            if (userDecision == "MENU")
            {
                HomeNavigation();
            }
            else if (userDecision == "EXIT")
            {
                ExitGame();
            }
            else
            {
                HomeNavigation();
            }
        }

        static char UserLetterGuess()
        {
            Console.WriteLine("Please enter a letter to guess:");
            string userGuess = Console.ReadLine();

            //try
            //{
                char letterGuess = char.Parse(userGuess);
                return letterGuess;
            //}
            //catch(FormatException fe)
            //{
            //    Console.WriteLine("You have not entered a valid letter. Please try again.");
            //    UserLetterGuess();
            //    return '';
            //}
        }

        static char[] WordDisplay(char[] preparedWordForGame, char letterGuess)
        {
            char[] blankDisplay = BlankWordDisplay(preparedWordForGame);

            for (int i = 0; i < preparedWordForGame.Length; i++)
            {
                if(preparedWordForGame[i] == letterGuess)
                {
                    blankDisplay[i] = letterGuess;         
                }
                else
                {
                    blankDisplay[i] = '_';
                }
            }
            return blankDisplay;
        }

        static char[] BlankWordDisplay(char[] preparedWordForGame)
        {
            char[] blankWordDisplay = new char[preparedWordForGame.Length];
            for (int i = 0; i < blankWordDisplay.Length; i++)
            {
                blankWordDisplay[i] = '_';
            }
            return blankWordDisplay;
        }

    }
}
