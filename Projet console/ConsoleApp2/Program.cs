using MySpacePendu;

Pendu pendu = new Pendu();
string guess;
char ch;
Console.WriteLine(pendu.word);
while (pendu.game == true)
{
    Console.Write("Donnez une lettre : ");
    try
    {
        guess = Console.ReadLine();
        ch = guess[0];
        pendu.checkChar(ch);
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("Mauvais input !! recommencez ! ");
    }
}