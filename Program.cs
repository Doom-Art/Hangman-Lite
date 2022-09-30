namespace Hangman_Lite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HangmanSoloMode();
        }
        public static void HangmanSoloMode()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Welcome to Hangman Lite, you get up to three incorrect guesses for the secret word.");
            Console.WriteLine("Good Luck");
            List<string> words = new List<string> { "COMPUTER", "CHEESE", "WRAP", "WOLF", "HANGMAN", "KEYBOARD", "RADDISH", "TEACHER", "BOX", "HAPPY", "PHONE", "ROSE", "PROGRAM" };
            string secretWord = "COMPUTERR";
            string displayWord = "";
            List<string> alreadyGuessed = new List<string>();
            int replace;
            for (int i = 0; i < secretWord.Length; i++)
            {
                displayWord += "_";
            }
            while (true)
            {
                if (alreadyGuessed.Count > 0){
                    Console.WriteLine("You have already guessed: ");
                    foreach (string i in alreadyGuessed)
                        Console.Write(i + " ");
                }
                Console.WriteLine("\n");
                drawHangman(alreadyGuessed.Count);
                for (int i = 0; i < displayWord.Length; i++)
                {
                    Console.Write($"{displayWord[i]} ");
                }
                if (alreadyGuessed.Count >= 3){
                    Console.WriteLine($"\n\nYou lose, the secret word was {secretWord}");
                    Console.WriteLine("Press enter to return to main menu.");
                    Console.ReadLine();
                    break;
                }
                else if (displayWord == secretWord){
                    Console.WriteLine($"\n\nYou Won, the secret word was {secretWord}");
                    Console.WriteLine("Press enter to return to main menu.");
                    Console.ReadLine();
                    break;
                }
                Console.WriteLine("\n\nTake a guess: ");
                string userGuess = Console.ReadLine().ToUpper();
                foreach (string i in alreadyGuessed)
                    if (userGuess == i)
                        userGuess = "";
                while (userGuess.Length != 1)
                {
                    Console.WriteLine("You did not make a valid guess please try again?");
                    userGuess = Console.ReadLine().ToUpper();
                    foreach (string i in alreadyGuessed)
                        if (userGuess == i)
                            userGuess = "";
                }
                if (secretWord.Contains(userGuess)){
                    replace = secretWord.IndexOf(userGuess);
                    displayWord = displayWord.Remove(replace, 1);
                    displayWord = displayWord.Insert(replace, userGuess);
                }
                else
                    alreadyGuessed.Add(userGuess);
                Console.Clear();
            }
        }
        public static void drawHangman(int num)
        {
            if (num == 0)
                Console.WriteLine(@"  +---+
  |   |
      |
      |
      |
      |
=========");
            else if (num == 1)
                Console.WriteLine(@"  +---+
  |   |
  O   |
  |   |
      |
      |
=========");
            else if (num == 2)
                Console.WriteLine(@"  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========");
            else if (num == 3){
                Console.WriteLine(@"  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========");
                Thread.Sleep(600);
                Console.WriteLine(@"  +---+
      |
      | 
 \O/  |
  |   |
 / \  |
=========");
            }
        }
    }
}