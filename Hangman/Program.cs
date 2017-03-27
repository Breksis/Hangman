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
            Console.WriteLine("Welcome to Hangman\n");

            //game loop
            do
            {
                string again;

                GameState currentGameState = GameState.GamePlaying;
                GuessChecker checkCharacter = new GuessChecker();
                HangmanPicture drawHangman = new HangmanPicture();
                Random rnd = new Random();
                SecretWord currentWord = new SecretWord(rnd.Next(20));

                //converts the secret word into a char array, then creates a DisplayLetter object for
                //each char in the array and adds these to a list
                char[] currentArray = currentWord.Word.ToCharArray();
                List<DisplayLetter> secretLetters = new List<DisplayLetter>();
               
                foreach (char letter in currentArray)
                {
                    DisplayLetter character = new DisplayLetter(letter);
                    secretLetters.Add(character);
                }
             
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

                    checkCharacter.DisplayGuesses();
                    checkCharacter.CheckGuess(secretLetters, drawHangman);
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
                    Console.WriteLine();

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
