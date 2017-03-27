using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class GuessChecker
    {
        List<char> guesses = new List<char>();
        private int correct = 0;
        public int Correct
        {
            get { return correct; }
            set { correct = value; }
        }

        private int incorrect = 0;
        public int Incorrect
        {
            get { return incorrect; }
            set { incorrect = value; }
        }

        //this method checks if the char inputted by the user matches any letters in the secret word
        public void CheckGuess(List<DisplayLetter> displayLetters, char guess, HangmanPicture draw)
        {
            bool correctGuess = false;

            Console.WriteLine();
            foreach (DisplayLetter item in displayLetters)
            {
                if (item.Letter == char.ToUpper(guess) && item.Guessed == false)
                {
                    item.Guessed = true;
                    correctGuess = true;
                    this.Correct++;
                }
            }
            if (correctGuess)
            {
                Console.WriteLine("You guessed correctly!");
            }
            else
            {
                this.Incorrect++;
                Console.WriteLine("I'm sorry, you guessed incorrectly");
                draw.Draw(this.Incorrect);
            }
            this.guesses.Add(guess);
            Console.WriteLine();
        }

        public void DisplayGuesses()
        {
            Console.Write("Guesses: ");

            foreach (char letter in guesses)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
