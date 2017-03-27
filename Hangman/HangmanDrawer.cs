using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class HangmanPicture
    {
        private string hangImg = "";
        public string HangImg
        {
            get { return hangImg; }
        }

        public void Draw(int incorrectGuess)
        {
            switch (incorrectGuess)
            {
                case 0:
                    break;
                case 1:
                    this.hangImg = "\n\n\n\n\n\n-------";
                    break;
                case 2:
                    this.hangImg = this.hangImg.Remove(1, 5);
                    this.hangImg = this.hangImg.Insert(1, "   |\n   |\n   |\n   |\n   |\n");
                    break;
                case 3:
                    this.hangImg = this.hangImg.Remove(0, 1);
                    this.hangImg = this.hangImg.Insert(0, "    ---\n");
                    break;
                case 4:
                    this.hangImg = this.hangImg.Insert(12, "   |");
                    break;
                case 5:
                    this.hangImg = this.hangImg.Insert(21, "   O");
                    break;
                case 6:
                    this.hangImg = this.hangImg.Insert(30, "   |");
                    break;
                case 7:
                    this.hangImg = this.hangImg.Remove(32, 1);
                    this.hangImg = this.hangImg.Insert(32, "-");
                    break;
                case 8:
                    this.hangImg = this.hangImg.Insert(34, "-");
                    break;
                case 9:
                    this.hangImg = this.hangImg.Insert(40, "  /");
                    break;
                case 10:
                    this.hangImg = this.hangImg.Insert(43, " \\");
                        break;
            }
        }
    }
}
