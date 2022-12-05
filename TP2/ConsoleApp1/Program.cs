// See https://aka.ms/new-console-template for more information
int x = 5;
if (x > 23)
    x -= 3;
else if (x == 23)
    x -= 2;
else
    x += 4; //La variable prendera donc +4 et sera a 9
Console.WriteLine(x); // Compilé avec succès

string MajorVersion;
if (soft != null && soft.Version != null)
{
    MajorVersion = soft.Version.Major;
}
//^ font le même traitement v
string MajorVersionV2 = soft?.Version?.Major;