namespace Hangman_Lite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Welcome to Hangman Lite, you get up to three incorrect guesses for the secret word.");
            Console.WriteLine("Good Luck");
            string secretWord = "COMPUTER";
            List<string> words = new List<string>() { "COMPUTER", "CHEESE", "WRAP", "WOLF", "HANGMAN", "KEYBOARD", "RADDISH", "TEACHER", "BOX", "HAPPY", "PHONE", "ROSE", "PROGRAM"};
            string displayWord = "";
            for (int i = 0; i < secretWord.Length; i++)
            {
                displayWord += "_";
            }

            Console.WriteLine(@"  +---+
  |   |
      |
      |
      |
      |
========="); //Ascii art part 1
            for (int i = 0; i < displayWord.Length; i++)
            {
                Console.Write($"{displayWord[i]} ");
            }
            Console.WriteLine("\nTake your first guess: ");
            string userGuess = Console.ReadLine();
            while (userGuess.Length != 1)
            {
                Console.WriteLine("You did not make a valid guess please try again?");
                userGuess = Console.ReadLine();
            }
        }
    }
}