using System.Numerics;

namespace Hangman_Lite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            int choice = 0;
            while (choice != 3)
            {
                Console.Clear();
                Console.WriteLine("Here is the HangMan Lite menu.  Please select an option:");
                Console.WriteLine();
                Console.WriteLine("1 - Go to Solo Mode");
                Console.WriteLine("2 - Go to Multiplayer Mode");
                Console.WriteLine("3 - Quit");
                Int32.TryParse(Console.ReadLine(), out choice);

                if (choice == 1)
                    HangmanSoloMode();
                else if (choice == 2)
                    HangmanMultiplayerMode();
                else if (choice == 3)
                    Console.WriteLine("Goodbye");
                else
                {
                    Console.WriteLine("Invalid choice, press ENTER to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// plays hangman in multiplayer mode where user can enter the secret word manually
        /// </summary>
        public static void HangmanMultiplayerMode()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Welcome to Hangman Lite, you get up to three incorrect guesses for the secret word.");
            Console.WriteLine("Good Luck");
            Console.WriteLine("Please enter the secret word: ");
            Console.ForegroundColor = Console.BackgroundColor;
            string secretWord = Console.ReadLine().ToUpper();
            while (secretWord == null || secretWord.Contains('0'))
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Please enter a valid secret word.");
                Console.ForegroundColor = Console.BackgroundColor;
                secretWord = Console.ReadLine().ToUpper();
            }
            Console.ForegroundColor = ConsoleColor.Black;
            string displayWord = "";
            List<string> alreadyGuessed = new List<string>();
            int replace;
            for (int i = 0; i < secretWord.Length; i++)
            {
                displayWord += "_";
            }
            while (true)
            {
                if (alreadyGuessed.Count > 0)
                {
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
                if (alreadyGuessed.Count >= 3)
                {
                    Console.WriteLine($"\n\nYou lose, the secret word was {secretWord}");
                    Console.WriteLine("Press enter to return to main menu.");
                    Console.ReadLine();
                    break;
                }
                else if (displayWord == secretWord)
                {
                    Console.WriteLine($"\n\nYou Won, the secret word was {secretWord}");
                    Console.WriteLine("Press enter to return to main menu.");
                    Console.ReadLine();
                    break;
                }
                Console.WriteLine("\n\nTake a guess: ");
                string userGuess = Console.ReadLine().ToUpper().Trim();
                foreach (string i in alreadyGuessed)
                    if (userGuess == i)
                        userGuess = "";
                while (userGuess.Length != 1)
                {
                    Console.WriteLine("You did not make a valid guess please try again?");
                    userGuess = Console.ReadLine().ToUpper().Trim();
                    foreach (string i in alreadyGuessed)
                        if (userGuess == i)
                            userGuess = "";
                }
                if (secretWord.Contains(userGuess))
                {
                    replace = secretWord.IndexOf(userGuess);
                    string secretWord2 = secretWord.Remove(replace, 1);
                    secretWord2 = secretWord2.Insert(replace, "0");
                    displayWord = displayWord.Remove(replace, 1);
                    displayWord = displayWord.Insert(replace, userGuess);
                    while (true)
                    {
                        int count = 0;
                        for (int i = 0; i < secretWord2.Length; i++)
                        {
                            if (secretWord2[i] != userGuess[0])
                                count++;
                        }
                        if (count == secretWord2.Length)
                            break;
                        replace = secretWord2.IndexOf(userGuess);
                        secretWord2 = secretWord2.Remove(replace, 1);
                        secretWord2 = secretWord2.Insert(replace, "0");
                        displayWord = displayWord.Remove(replace, 1);
                        displayWord = displayWord.Insert(replace, userGuess);
                    }
                }
                else
                    alreadyGuessed.Add(userGuess);
                Console.Clear();
            }
        }
        /// <summary>
        /// starts hangman in solo mode where it generates the secret word based off of a pre set list
        /// </summary>
        public static void HangmanSoloMode()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Welcome to Hangman Lite Solo, you get up to three incorrect guesses for the secret word.");
            Console.WriteLine("Good Luck");
            List<string> words = new List<string> { "COMPUTER", "TROLLING","CHEESE", "SEVEN","HIPPO","DISCORD","WING","DEATH","DOOM","GRIM","BOOK","MONKEY","LOKI","THOR","VAMPIRE","HALLOWEEN","YACHT","CAMPING","MONKEYMONKEY", "AI","RATIO","BLANK","WORD","SNAKE","HUNTER","HUNDRED","SWORD","ART","ONLINE","ANIME","SIR","CANADA","LETTER","NUMBER","STUDENT","KEY","ENCRYPT","DECRYPT","TROLL","HEHEHEHEHEHE","TREE","RAM","WRAP", "COOKIE", "WATER", "LEARN","WOLF", "HANGMAN", "KEYBOARD", "RADDISH", "TEACHER", "BOX", "HAPPY", "PHONE", "ROSE", "PROGRAM", "SWEET", "CRUTCH", "TAYLOR"};
            Random rand = new Random();
            string secretWord = words[rand.Next(0, words.Count)];
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
                string userGuess = Console.ReadLine().ToUpper().Trim();
                foreach (string i in alreadyGuessed)
                    if (userGuess == i)
                        userGuess = "";
                while (userGuess.Length != 1)
                {
                    Console.WriteLine("You did not make a valid guess please try again?");
                    userGuess = Console.ReadLine().ToUpper().Trim();
                    foreach (string i in alreadyGuessed)
                        if (userGuess == i)
                            userGuess = "";
                }
                if (secretWord.Contains(userGuess)){
                    replace = secretWord.IndexOf(userGuess);
                    string secretWord2 = secretWord.Remove(replace, 1);
                    secretWord2 = secretWord2.Insert(replace, "0");
                    displayWord = displayWord.Remove(replace, 1);
                    displayWord = displayWord.Insert(replace, userGuess);
                    while (true)
                    {
                        int count = 0;
                        for (int i = 0; i < secretWord2.Length; i++)
                        {
                            if (secretWord2[i] != userGuess[0])
                                count++;
                        }
                        if (count == secretWord2.Length)
                            break;
                        replace = secretWord2.IndexOf(userGuess);
                        secretWord2 = secretWord2.Remove(replace, 1);
                        secretWord2 = secretWord2.Insert(replace, "0");
                        displayWord = displayWord.Remove(replace, 1);
                        displayWord = displayWord.Insert(replace, userGuess);
                    }
                }
                else
                    alreadyGuessed.Add(userGuess);
                Console.Clear();
            }
        }
        /// <summary>
        /// Draws the hangman picture based on the amount of incorrect guesses
        /// </summary>
        /// <param name="num"></param> how many current incorrect guesses from 0-3
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
      |");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" \\O/  ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("|");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  |   ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("|");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" / \\  ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("|");
                Console.WriteLine("=========");
            }
        }
    }
}