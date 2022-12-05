namespace MyUtility
{
    class Utility
    {
        public Utility()
        {

        }

        public void StartOfTheGame() { Console.WriteLine("Debut du jeux !!"); }

        public void Ask() { Console.Write("Donnez une lettre : "); }

        public void WrongInput() { Console.WriteLine("Mauvais input !! recommencez ! "); }
    }
}