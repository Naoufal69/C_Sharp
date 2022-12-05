using System.Runtime.CompilerServices;

namespace MySpacePendu
{
    class Pendu
    {
        public string word { get; set; }
        public int[] check { get; set; }
        public bool game { get; set; }
        public int errorNumber { get; set; }
        public Pendu()
        {
            string[] dico = { "Bonjour","Nicolas","Test","Feu","Meilleur","Constitution"};
            this.game = true;
            var rand = new Random();
            int i = rand.Next(0, dico.Length);
            this.word = dico[i].ToLower();
            this.check = new int[this.word.Length];
            for (int j = 0; j < this.check.Length; j++)
            {
                this.check[j] = 0;
            }
            this.errorNumber = 0;
            printWordToGuess();
        }

        public void printWordToGuess()
        {
            for (int j = 0; j < this.check.Length; j++)
            {
                if (this.check[j] == 0)
                    Console.Write("_");
                else
                    Console.Write(this.word[j]);
            }
            Console.WriteLine();
        }

        public int checkIfWinOrLoose()
        {
            if (this.errorNumber >= 10)
            {
                this.game = false;
                Console.WriteLine("Vous avez perdu !");
                return -1;
            }  
            int sum = 0;
            for (int i = 0; i < this.check.Length; i++)
                sum += this.check[i];
            return sum;
        }

        public void checkChar(char ch)
        {
            int i = 0;
            bool isIn = false;
            for (int j = 0; j < this.word.Length; j++)
            {
                if (ch == this.word[j])
                {
                    this.check[j]++;
                    isIn = true;
                }
            }

            if (isIn)
                Console.WriteLine($"La lettre {ch} est présent dans le mot");
            else
                this.errorNumber++;
            int numberToCheck = checkIfWinOrLoose();
            if (numberToCheck == this.check.Length && numberToCheck > 0)
                this.game = false;
            printWordToGuess();
        }
    }
}