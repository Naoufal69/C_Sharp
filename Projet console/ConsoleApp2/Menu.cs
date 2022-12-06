using MyUtility;

namespace MainMenu{
    class Menu: Utility{
        public string awnsers;

        public bool isInProgress {get; set;}

        public Menu(){
            bool passed = false;
            Console.WriteLine("Voulez vous lancer le jeux ? (O/N)");
            while (passed == false)
            {
                try
                {
                    this.awnsers = Console.ReadLine();
                    passed = true;
                }
                catch (IndexOutOfRangeException)
                {
                    WrongInput();
                }
            }
            passed = false;

            while (this.awnsers != "O" && this.awnsers != "N"){
                Console.WriteLine("LA");
                while (passed == false)
                {
                    try
                    {
                        this.awnsers = Console.ReadLine();
                        passed = true;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        WrongInput();
                    }
                }
                passed = false;
            }
            if (this.awnsers == "O"){
                this.isInProgress = true;
                StartOfTheGame();
            }
            else{
                this.isInProgress = false;
                EndOfTheGame();
            }
        }

        public bool RestartTheGame()
        {
            bool passed = false;
            Console.WriteLine("Voulez vous recommencer ? (O/N)");
            while (passed == false)
            {
                try
                {
                    this.awnsers = Console.ReadLine();
                    passed = true;
                }
                catch (IndexOutOfRangeException)
                {
                    WrongInput();
                }
            }
            passed = false;
            while (this.awnsers != "O" || this.awnsers != "N")
            {
                while (passed == false)
                {
                    try
                    {
                        this.awnsers = Console.ReadLine();
                        passed = true;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        WrongInput();
                    }
                }
                passed = false;
            }

            if (this.awnsers == "O")
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