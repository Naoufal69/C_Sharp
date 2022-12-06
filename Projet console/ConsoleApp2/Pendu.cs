using Drawing;
using System.Runtime.CompilerServices;

namespace MySpacePendu
{
    class Pendu: Draw
    {
        /* Some properties. */
        public string word { get; set; }
        public int[] check { get; set; }
        public bool game { get; set; }
        public int errorNumber { get; set; }

        /* The constructor of the class. It is called when you create a new instance of the class. */
        public Pendu()
        {
            string text = File.ReadAllText(@"liste_francais.txt");
            string[] dico = text.Split("\n");
            this.game = true;
            var rand = new Random();
            int i = rand.Next(0, dico.Length);
            this.word = dico[i].ToLower().Trim();
            this.check = new int[this.word.Length];
            for (int j = 0; j < this.check.Length; j++)
            {
                this.check[j] = 0;
            }
            this.errorNumber = 0;
        }

        /// <summary>
        /// This function prints the word to guess, replacing letters that have not been guessed with
        /// underscores
        /// </summary>
        public void PrintWordToGuess()
        {
            for (int j = 0; j < this.word.Length; j++)
            {
                if (this.check[j] == 0)
                {
                    if (j != this.word.Length)
                    {
                        Console.Write("_");
                    }
                }
                else
                    Console.Write(this.word[j]);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// This function checks if the player has won or lost the game
        /// </summary>
        /// <returns>
        /// The sum of the check array.
        /// </returns>
        public int CheckIfWinOrLoose()
        {
            DrawTheHangMan(this.errorNumber);
            if (this.errorNumber >= 9)
            {
                this.game = false;
                Console.WriteLine($"Vous avez perdu ! le mot était {this.word}");
                return -1;
            }  
            int sum = 0;
            for (int i = 0; i < this.check.Length; i++)
                sum += this.check[i];
            return sum;
        }

        /// <summary>
        /// This function checks if the character entered by the user is in the word to guess
        /// </summary>
        /// <param name="ch">the character that the user entered</param>
        public void CheckChar(char ch)
        {
            int i = 0;
            bool isIn = false;
            for (int j = 0; j < this.word.Length; j++)
            {
                if (ch == this.word[j] && this.check[j]==0)
                {
                    this.check[j]++;
                    isIn = true;
                }
                else if (ch == this.word[j] && this.check[j] != 0)
                {
                    isIn = true;
                }
            }

            if (isIn)
                Console.WriteLine($"La lettre {ch} est présent dans le mot");
            else
                this.errorNumber++;
            int numberToCheck = CheckIfWinOrLoose();
            if (numberToCheck == this.check.Length && numberToCheck > 0)
            {
                this.game = false;
                Console.WriteLine($"Vous avez gagné !! Bravo !! le mot était {this.word}");
            }
        }

        /// <summary>
        /// It generates a new word to guess and resets the error number
        /// </summary>
        public void RegenrateTheGame()
        {
            Console.Clear();
            string text = File.ReadAllText(@"liste_francais.txt");
            string[] dico = text.Split("\n");
            this.game = true;
            var rand = new Random();
            int i = rand.Next(0, dico.Length);
            while (this.word == dico[i].ToLower())
            {
                i = rand.Next(0, dico.Length);
            }
            this.word = dico[i].ToLower().Trim();
            Console.WriteLine(this.word.Length);
            this.check = new int[this.word.Length];
            for (int j = 1; j < this.check.Length; j++)
            {
                this.check[j] = 0;
            }
            this.errorNumber = 0;
        }
    }
}