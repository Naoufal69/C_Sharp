using MySpacePendu;
using MyUtility;

Pendu pendu = new Pendu();
Utility utility = new Utility();
string guess;
char ch;

utility.StartOfTheGame();
while (pendu.game == true)
{
    utility.Ask();
    try
    {
        guess = Console.ReadLine();
        ch = guess[0];
        pendu.CheckChar(ch);
    }
    catch (IndexOutOfRangeException)
    {
        utility.WrongInput();
    }
}