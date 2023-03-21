using FileManipulation;

internal class Program
{
    private static void Main(string[] args)
    {
        FileManipulator fm = new("backup");

        do
        {
            Console.Clear();
            fm.WritePerson(CreatePerson());
            Console.WriteLine("Tecle C para acrescentar mais alguém");
        } while (Console.ReadLine().ToLower() == "c");

        Console.WriteLine(fm);

    }

    private static Person CreatePerson()
    {
        string name;
        char gender;

        Console.WriteLine("Informe o nome da pessoa: ");
        name = Console.ReadLine();

        do
        {
            Console.WriteLine("Gênero da pessoa (M/F): ");
            char.TryParse(Console.ReadLine().ToUpper(), out gender);
        } while (gender != 'M' && gender != 'F');

        return new Person(name, gender);
    }
}