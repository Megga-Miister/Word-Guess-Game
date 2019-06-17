using System;
using Xunit;
using Word_Guess_Game;

namespace Word_Guess_Game_Unit_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void WordFileCanBeUpdatedWithNewWord()
        {
            string filePath = "../../../guessinggamewordstest.txt";
            Program.AddWordToFile(filePath, "TESTWORD");

            string[] wordsInFile = Program.ReadFile(filePath);
            string wordsString = String.Join(" ", wordsInFile);

            bool containing = wordsString.Contains("TESTWORD");
            string result = containing.ToString();

            Assert.Equal("True", result);   
        }

        [Fact]
        public void CanRetrieveAllWordsFromTheFile()
        {
            string filePath = "../../../guessinggamewordstest.txt";
            string[] testWords = new string[] { "TEST1", "TEST2", "TEST3" };
            Program.CreateWordFile(filePath, testWords);

            string[] resultArray = Program.ReadFile(filePath);

            Assert.Equal(testWords, resultArray);
        }

        //[Fact]
        //public void LetterDoesExistInWord()
        //{
        //    contains();
        //}

        //[Fact]
        //public void LetterDoesNotExistInWord()
        //{

        //}
    }
}
