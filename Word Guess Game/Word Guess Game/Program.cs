using System;
using System.IO;

namespace Word_Guess_Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../guessinggamewords.txt";
            string[] words = { "FRODO", "GANDALF", "SAMWISE", "ARAGORN", "LEGOLAS", "GIMLI", "BOROMIR", "PEREGRIN", "MERIADOC" };
            string greetingMessage = PesistWordFile(filePath, words);

            Console.WriteLine(greetingMessage);
        }

        static void HomeNavigation()
        {

        }

        static void CreateWordFile(string filePath, string[] words)
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
                return "Welcome to the Lord of the Rings Character Guessing Game!";
            }
            else
            {
                return "Welcome back to the Lord of the Rings Character Guessing Game!";
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
            string[] fileWords = ReadFile(filePath);

            for (int i = 0; i < fileWords.Length; i++)
            {
                if (fileWords[i] == upperCaseWord)
                {
                    fileWords[i] = "";
                    return ($"{upperCaseWord} has been removed.");
                }
                else
                {
                    return ($"{upperCaseWord} could not be found.");
                }
            }

            CreateWordFile(filePath, fileWords);
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

        static void StartGame()
        {

        }

        static string SelectRandomWordFromFile(string filePath)
        {

        }

        static char[] PrepareWordForGame(string randomWordFromFile)
        {

        }

        static char[] LetterGuessList(char letterGuess)
        {

        }

        static void GameCompleteOptions()
        {

        }

        static char[] WordDisplay(char[] blankWordDisplay, char LetterGuess)
        {

        }

        static char[] BlankWordDisplay(char[] preparedWordForGame)
        {

        }

        static void ExceptionHandler()
        {

        }

    }
}
