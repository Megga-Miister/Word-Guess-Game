using System;
using System.IO;

namespace Word_Guess_Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../words.txt";
            string[] words = { "FRODO", "GANDALF", "SAMWISE", "ARAGORN", "LEGOLAS", "GIMLI", "BOROMIR", "PEREGRIN", "MERIADOC" };

            Console.WriteLine("Welcome to the Lord of the Rings Character Guessing Game!");
            Console.WriteLine(" ");
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

        static void AddWordToFile(string word)
        {

        }

        static void RemoveWordFromFile(string word)
        {

        }

        static void ExitGame()
        {

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
