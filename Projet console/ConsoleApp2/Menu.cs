namespace MainMenu{
    class Menu{
        bool isInProgress {get; set;}

        public Menu(){
            Console.WriteLine("Voulez vous lancer le jeux ? (O/N)");
            string awnsers = Console.ReadLine();
            while(awnsers != "O" || awnsers != "N"){
                WrongInput();
                awnsers = Console.ReadLine();
            }
            if (awnsers == "O"){
                this.isInProgress = true;
                StartOfTheGame();
            }
            else{
                this.isInProgress = false;
                EndOfTheGame();
            }
        }
    }
}