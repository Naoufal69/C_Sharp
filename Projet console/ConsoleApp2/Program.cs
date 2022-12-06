using MySpacePendu;
using MyUtility;
using MainMenu;

Pendu pendu = new Pendu();
MainMenu menu = new MainMenu();
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
}
