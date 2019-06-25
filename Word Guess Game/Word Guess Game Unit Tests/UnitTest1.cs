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

        [Fact]
        public void LetterDoesExistInWord()
        {
            char[] testWord = { 'T', 'E', 'S', 'T' };
            char testLetter = 'E';
            string testExample = Convert.ToString(Program.WordDisplay(testWord, testLetter));
            bool testResult = testExample.Contains('e');

            Assert.True(testResult);
        }

        [Fact]
        public void LetterDoesNotExistInWord()
        {
            char[] testWord = { 'T', 'E', 'S', 'T' };
            char testLetter = 'F';
            string testExample = Convert.ToString(Program.WordDisplay(testWord, testLetter));
            bool testResult = testExample.Contains('F');

            Assert.False(testResult);
        }
    }
}
