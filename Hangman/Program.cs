using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        enum GameState { GamePlaying, GameWon, GameOver };      

        static void Main(string[] args)
        {
            //game loop
            do
            {
                string again;

                GameState currentGameState = GameState.GamePlaying;
                GuessChecker checkCharacter = new GuessChecker();
                HangmanDrawer drawHangman = new HangmanDrawer();
                SecretWord currentWord = new SecretWord("BANANA");

                //can probably move the following section to the SecretWord class 
                //when I write a function to randomly select a word.
                char[] currentArray = currentWord.Word.ToCharArray();
                List<DisplayLetter> secretLetters = new List<DisplayLetter>();
               
                foreach (char letter in currentArray)
                {
                    DisplayLetter character = new DisplayLetter(letter);
                    secretLetters.Add(character);
                }
                //end of section.

                //Happy little intro message
                Console.WriteLine("Welcome to Hangman\n");
                do
                {
                    //runs through each letter in the word and displays either an underscore
                    //or the letter if it was already guessed
                    foreach (DisplayLetter item in secretLetters)
                    {
                        item.DisplayCharacters(item);
                    }

                    Console.WriteLine();
                    Console.WriteLine();

                    //prompts the user for input
                    //TODO: write some code that prevents the user from entering 
                    //non-alpha characters
                    Console.Write("Please enter a letter: ");
                    ConsoleKeyInfo info = Console.ReadKey();
                    string keyString = info.Key.ToString();
                    char guess = keyString[0];
                    Console.WriteLine();

                    checkCharacter.CheckGuess(secretLetters, guess, drawHangman);
                    Console.WriteLine(drawHangman.HangImg);

                    //checks to see if the user has guessed all the letters or made 
                    //too many incorrect guesses
                    if (checkCharacter.Correct == currentArray.Length)
                    {
                        foreach (DisplayLetter item in secretLetters)
                        {
                            item.DisplayCharacters(item);
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("You have Won!");
                        Console.WriteLine();
 
                        currentGameState = GameState.GameWon;
                    }
                    if (checkCharacter.Incorrect == 10)
                    {
                        Console.WriteLine("Hangman!");
                        currentGameState = GameState.GameOver;
                    }
                } while (currentGameState == GameState.GamePlaying);

                do
                {
                    Console.WriteLine("Play again? (Y/N)");
                    ConsoleKeyInfo keyPress = Console.ReadKey();
                    again = keyPress.Key.ToString();

                    if (again.ToUpper() != "Y" && again.ToUpper() != "N")
                    {
                        Console.WriteLine("Invalid response, please enter Y or N");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                if (again.ToUpper() == "Y")
                {
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    break;
                }
            } while (true);
        }
    }
}
