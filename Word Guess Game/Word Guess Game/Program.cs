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

        /// <summary>
        /// Runs upon start and acts as a hub to all the Menu options for the app.
        /// </summary>
        static void HomeNavigation()
        {
            string filePath = "../../../guessinggamewords.txt";
            string lettersFilePath = "../../../guessedletters.txt";
            string[] words = new string[] { "FRODO", "GANDALF", "SAMWISE", "ARAGORN", "LEGOLAS", "GIMLI", "BOROMIR", "PEREGRIN", "MERIADOC" };
            string greetingMessage = PersistWordFile(filePath, words);

            Console.WriteLine($"{greetingMessage}");

            Console.WriteLine("Please choose from one of the following options:\n");
            Console.WriteLine("     1) Start Game \n     2) View Characters \n     3) Add Character \n     4) Remove Character \n     5) Exit Game");

            string userSelection = Console.ReadLine();
            int actionSelection = Convert.ToInt32(userSelection);

            switch (actionSelection)
            {
                case 1:
                    StartGame(filePath, lettersFilePath);
                    ReturnToMenu();
                    break;
                case 2:
                    string[] characterListFromFile = ReadFile(filePath);
                    string characterList = String.Join(" ", characterListFromFile);
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

        /// <summary>
        /// Creates a new text document in desired location with given words.
        /// </summary>
        /// <param name="filePath">Desired destination and name of file that will be created</param>
        /// <param name="words">String array of words that will populate in the text file created</param>
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

        /// <summary>
        /// Persists word file that is created from previous play of game, 
        /// or creates a new word file if game has not been previously played
        /// </summary>
        /// <param name="filePath">Location of persisting character list file or destination of new character 
        /// list file will be created</param>
        /// <param name="words">A list of words that will populate the character list if no word file exists</param>
        /// <returns></returns>
        static string PersistWordFile(string filePath, string[] words)
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

        /// <summary>
        /// Will append a new word to the end of the character list file
        /// </summary>
        /// <param name="filePath">Location of character list file</param>
        /// <param name="newWord">User entered new character name to add to character list</param>
        public static void AddWordToFile(string filePath, string newWord)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(newWord);
            }
        }

        /// <summary>
        /// Finds existing file at given location and destroys said file
        /// </summary>
        /// <param name="filePath">Location of file to be deleted</param>
        static void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        /// <summary>
        /// Reads existing character list file and if given character exists in list, will create new 
        /// character list without the given character
        /// </summary>
        /// <param name="upperCaseWord">Undesired character name in uppercase format</param>
        /// <returns>A message letting user know if character was removed or didn't exist on character list</returns>
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

        /// <summary>
        /// Takes a file address and captures any text sitting in said file to later display
        /// </summary>
        /// <param name="filePath">Location of file to get it's contents read</param>
        /// <returns>Contents of existing file </returns>
        public static string[] ReadFile(string filePath)
        {
            string[] wordsInFile = File.ReadAllLines(filePath);
            return wordsInFile;
        }

        /// <summary>
        /// Closes out console application
        /// </summary>
        static void ExitGame()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Initiates set up of files and runs game for user to play
        /// </summary>
        /// <param name="filePath">Location of character list file</param>
        /// <param name="lettersFilePath">Location of file that will contain all user guesses from</param>
        static void StartGame(string filePath, string lettersFilePath)
        {
            char[] preppedWordForGame = SelectRandomWordFromFile(filePath);
            string displayWordForGame = new string(preppedWordForGame);
            char[] hiddenWord = BlankWordDisplay(preppedWordForGame);
            string displayHiddenWord = String.Join(" ",hiddenWord);
            char[] guessedWord = WordDisplay(preppedWordForGame, ' ');
            string displayGuessedWord = new string(guessedWord);

            Console.WriteLine($"\nPlease try to guess the following character: {displayHiddenWord}");

            while (guessedWord != preppedWordForGame)
            {
                char currentLetterGuess = UserLetterGuess();
                char[] updatedBlankArray = WordDisplay(preppedWordForGame, currentLetterGuess);
                string updatedHiddenWord = String.Join(" ", updatedBlankArray);
                Console.WriteLine($"\nPlease try to guess the following character: {updatedHiddenWord}");
                LetterGuessList(lettersFilePath, currentLetterGuess);

            }

            DeleteFile(lettersFilePath);
            Console.WriteLine("Congrats!\n");
        }

        /// <summary>
        /// Will grab a random character from the character list and formatt the name
        /// </summary>
        /// <param name="filePath">Location of character list file</param>
        /// <returns>Character name prepped formatted as an array for game</returns>
        static char[] SelectRandomWordFromFile(string filePath)
        {
            Random randomGenerator = new Random();

            string[] wordsFromFile = ReadFile(filePath);
            int randomIndex = randomGenerator.Next(wordsFromFile.Length);
            string randomWord = wordsFromFile[randomIndex];

            char[] preparedWordForGame = randomWord.ToCharArray();
            return preparedWordForGame;
        }

        /// <summary>
        /// Takes user letter guess and either creates a new file or adds to an existing file so user can 
        /// see their previous guesses
        /// </summary>
        /// <param name=ePath">Location or destination of file to store user guessed letters</param>
        /// <param name="letterGuess">Particular character the user has guessed</param>
        static void LetterGuessList(string lettersFilePath, char letterGuess)
        {
            string saveInFileLetter = letterGuess.ToString();
            AddWordToFile(lettersFilePath, saveInFileLetter);

            string[] guessArray = ReadFile(lettersFilePath);
            string guessList = String.Join(" ", guessArray);

            Console.WriteLine($"\nYou have guessed: {guessList}\n");
        }


        /// <summary>
        /// Will present user option to exit application or return to the home navigation menu
        /// </summary>
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

        /// <summary>
        /// Prompts user for a letter guess and will capture users entry
        /// </summary>
        /// <returns>Formatted users letter guess to character</returns>
        static char UserLetterGuess()
        {
            Console.WriteLine("Please enter a letter to guess:");
            string userGuess = Console.ReadLine();

            try
            {
                char letterGuess = char.Parse(userGuess);
                return letterGuess;
            }
            catch (FormatException fe)
            {
                Console.WriteLine("You have not entered a valid letter. Please try again.");
                UserLetterGuess();
                return '-';
            }
        }

        /// <summary>
        /// Compares user letter guess to hidden character name and will display corrected guessed letters
        /// </summary>
        /// <param name="preparedWordForGame">Character name formatted for game</param>
        /// <param name="letterGuess">Formatted user character guess</param>
        /// <returns></returns>
        public static char[] WordDisplay(char[] preparedWordForGame, char letterGuess)
        {
            char[] blankDisplay = new char[preparedWordForGame.Length];

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

        /// <summary>
        /// Creates a "hidden" version of the character name for the user to see
        /// </summary>
        /// <param name="preparedWordForGame">Character name that has been formatted for the game</param>
        /// <returns>Hidden version of the character name</returns>
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
