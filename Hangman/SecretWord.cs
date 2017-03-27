using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class SecretWord
    {
        public SecretWord(int rndInt)
        {
            string[] wordList = new string[20] {"KITTEN", "GULLIBLE", "TROPICAL", 
            "FORBIDDEN", "THERMOMETER", "CLUSTERED", "AVIATION", "SUGGESTION",
            "FORGOTTEN", "PERMITTED", "COMEDIC", "BANANA", "CLASSICAL",
            "BROODING", "GENTILE", "REFRIDGERATOR", "AMPLIFIER", "NARRATOR",
            "SIMPLIFIED", "ABSOLUTE"};

            word = wordList[rndInt];
        }

        private string word;
        public string Word
        {
            get { return word; }
        }               
    }
}
