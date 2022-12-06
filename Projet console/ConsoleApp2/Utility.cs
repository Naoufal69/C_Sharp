namespace MyUtility
{
    //Peut être pas pertinent, mais, c'était pour avoir une classe sans constructeur
    class Utility
    {
        /// <summary>
        /// This function is called at the beginning of the game
        /// </summary>
        public void StartOfTheGame() { Console.WriteLine("Debut du jeux !!"); }

        /// <summary>
        /// It asks the user to enter a letter
        /// </summary>
        public void Ask() { Console.Write("Donnez une lettre : "); }
        
        /// <summary>
        /// This function is used to display a message to the user when he enters a wrong input
        /// </summary>
        public void WrongInput() { Console.WriteLine("Mauvais input !! recommencez ! ");}

        /// <summary>
        /// When the game is over, display a message to the user.
        /// </summary>
        public void EndOfTheGame() { Console.WriteLine("Fin du jeux !!"); }
    }
}