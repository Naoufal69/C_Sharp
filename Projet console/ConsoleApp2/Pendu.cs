using System.Runtime.CompilerServices;

namespace MySpacePendu
{
    class Pendu
    {
        public string word { get; set; }
        public int[] check { get; set; }
        public Pendu()
        {
            string[] dico = { "Bonjour", "Nicolas","Test","Feu","Meilleur","Constitution"};
            var rand = new Random();
            int i = rand.Next(0, dico.Length);
            this.word = dico[i];
            this.check = new int[this.word.Length];
            for (int j = 0; j < this.check.Length; j++)
            {
                this.check[j] = 0;
            }
        }

        public void checkChar(char ch)
        {
            int i = 0;
            foreach (char c in word) {
                if (c == ch)
                {
                    this.check[i]++;
                }
            }
        }
    }
}