class Student
{
    string name { get; set; }
}
static void ChangeValue(Student student)
{
    student.name = 'Nicolas';
}

Student Kevin = new Student();
Kevin.name = "Kévin";

ChangeValue(Kevin);

Console.WriteLine(Kevin.name);