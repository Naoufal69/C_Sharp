using MyUtility;

namespace MainMenu{
    class Menu: Utility{
        public string answers;

        public bool isInProgress {get; set;}

        public Menu(){
            bool passed = false;
            Console.WriteLine("Voulez vous lancer le jeux ? (O/N)");
            while (passed == false)
            {
                try
                {
                    this.answers = Console.ReadLine();
                    passed = true;
                }
                catch (IndexOutOfRangeException)
                {
                    this.WrongInput();
                }
            }
            passed = false;

            while (this.answers.ToUpper() != "O" && this.answers.ToUpper() != "N"){
                while (passed == false)
                {
                    try
                    {
                        this.answers = Console.ReadLine();
                        passed = true;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        this.WrongInput();
                    }
                }
                passed = false;
            }
            if (this.answers.ToUpper() == "O"){
                this.isInProgress = true;
                this.StartOfTheGame();
            }
            else{
                this.isInProgress = false;
                this.EndOfTheGame();
            }
        }

        /// <summary>
        /// It asks the user if he wants to restart the game, if he answers "O" (for "Oui" in french) it
        /// returns true, if he answers "N" (for "Non" in french) it returns false.
        /// </summary>
        /// <returns>
        /// A boolean value.
        /// </returns>
        public bool RestartTheGame()
        {
            bool passed = false;
            Console.Write("Voulez vous recommencer ? (O/N) ");
            while (passed == false)
            {
                try
                {
                    this.answers = Console.ReadLine();
                    passed = true;
                }
                catch (IndexOutOfRangeException)
                {
                    this.WrongInput();
                }
            }
            passed = false;
            while (this.answers.ToUpper() != "O" && this.answers.ToUpper() != "N")
            {
                while (passed == false)
                {
                    try
                    {
                        this.answers = Console.ReadLine();
                        passed = true;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        this.WrongInput();
                    }
                }
                passed = false;
            }

            if (this.answers.ToUpper() == "O")
            {
                return true;
            }
            else
            {
                this.isInProgress = false;
                return false;
            }
        }
    }
}