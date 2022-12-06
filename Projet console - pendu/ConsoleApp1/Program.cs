/*Zone pour simuler le dessin du pendu*/
int value = 8;
switch (value)
{
    case 1:
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine();
        }
        Console.WriteLine("-----");
        break;
    case 2:
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("  |");
        }
        Console.WriteLine("-----");
        break;
    case 3:
        Console.WriteLine("_________");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("  |");
        }
        Console.WriteLine("-----");
        break;
    case 4:
        Console.WriteLine("_________");
        for (int i = 0; i < 5; i++)
        {
            if (i < 2)
                Console.WriteLine("  |  |");
            else
                Console.WriteLine("  |");
        }
        Console.WriteLine("-----");
        break;
    case 5:
        Console.WriteLine("_________");
        for (int i = 0; i < 5; i++)
        {
            if (i < 2)
                Console.WriteLine("  |  |");
            else if (i == 2)
                Console.WriteLine("  |  O");
            else
                Console.WriteLine("  |");
        }
        Console.WriteLine("-----");
        break;
    case 6:
        Console.WriteLine("_________");
        for (int i = 0; i < 5; i++)
        {
            if (i < 2)
                Console.WriteLine("  |  |");
            else if (i == 2)
                Console.WriteLine("  |  O");
            else if (i > 2 && i < 4)
                Console.WriteLine("  |  |");
            else
                Console.WriteLine("  |");
        }
        Console.WriteLine("-----");
        break;
    case 7:
        Console.WriteLine("_________");
        for (int i = 0; i < 5; i++)
        {
            if (i < 2)
                Console.WriteLine("  |  |");
            else if (i == 2)
                Console.WriteLine("  |  O");
            else if (i > 2 && i < 4)
                Console.WriteLine("  |  |");
            else if (i == 4)
                Console.WriteLine("  |  ^");
            else
                Console.WriteLine("  |");
        }
        Console.WriteLine("-----");
        break;
    case 8:
        Console.WriteLine("_________");
        for (int i = 0; i < 5; i++)
        {
            if (i < 2)
                Console.WriteLine("  |  |");
            else if (i == 2)
            {
                Console.WriteLine("  |  O");
                Console.WriteLine("  | ---");
            }
            else if (i > 2 && i < 4)
                Console.WriteLine("  |  |");
            else if (i == 4)
                Console.WriteLine("  |  ^");
            else
                Console.WriteLine("  |");
        }
        Console.WriteLine("-----");
        break;
    case 9:
        Console.WriteLine("_________");
        for (int i = 0; i < 5; i++)
        {
            if (i < 2)
                Console.WriteLine("  |  |");
            else if (i == 2)
            {
                Console.WriteLine("  |  O");
                Console.WriteLine("  | ---");
            }
            else if (i > 2 && i < 4)
                Console.WriteLine("  |  |");
            else if (i == 4)
                Console.WriteLine("  |  ^");
            else
                Console.WriteLine("  |");
        }
        Console.WriteLine("-----");
        Console.WriteLine();
        Console.WriteLine("Vous êtes pendu !!");
        break;
}