using MySpacePendu;
using MainMenu;

Pendu pendu = new Pendu();
Menu menu = new Menu();
string guess;
char ch;

while (menu.isInProgress){
    while (pendu.game == true)
    {
        menu.Ask();
        pendu.PrintWordToGuess();
        try
        {
            guess = Console.ReadLine();
            ch = guess[0];
            pendu.CheckChar(ch);
        }
        catch (IndexOutOfRangeException)
        {
            menu.WrongInput();
        }
    }
    pendu.game = menu.RestartTheGame();
    Console.WriteLine(pendu.game);
    if (pendu.game == true)
    {
        pendu.RegenrateTheGame();
    }
}
