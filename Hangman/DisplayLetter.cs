using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class DisplayLetter
    {
        public DisplayLetter(char letter)
        {
            Letter = letter;
        }

        private char letter;
        public char Letter
        {
            get { return letter; }
            set { letter = value; }
        }

        private bool guessed = false;
        public bool Guessed
        {
            get { return guessed; }
            set { guessed = value; }
        }

        public void DisplayCharacters (DisplayLetter character)
        {
            if (guessed == true)
            {
                Console.Write(character.letter + " ");
            }
            else
            {
                Console.Write("_ ");
            }
        }
    }
}
