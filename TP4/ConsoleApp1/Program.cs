static void ChangeValue(int x)
{
    x = 10;
    Console.Write("La valeur de x est : ");
    Console.WriteLine(x);
}

int i = 100;
Console.WriteLine(i); //100
ChangeValue(i); //10
Console.WriteLine(i); //10
