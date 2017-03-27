using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class SecretWord
    {
        public SecretWord()
        {
        }

        public SecretWord(string word)
        {
            Word = word;
        }

        private string word;
        public string Word
        {
            get { return word; }
            set { word = value;  }
        }               
    }
}
