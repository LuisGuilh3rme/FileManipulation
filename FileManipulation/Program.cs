﻿using FileManipulation;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Digite o nome para seu arquivo: ");
        string fileName = Console.ReadLine();

        FileManipulator fm = new(fileName);

        int opt = 0;
        do
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Ler lista");
                Console.WriteLine("2 - Ler quantidade de linhas");
                Console.WriteLine("3 - Adicionar pessoa");
                Console.WriteLine("4 - Sair");
                int.TryParse(Console.ReadLine(), out opt);
            } while (opt < 1 || opt > 4);

            if (opt == 4) Environment.Exit(0);

            if (opt == 1) Console.WriteLine(fm);

            if (opt == 2)
            {
                int range = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Escolha a quantidade de linhas:");
                    int.TryParse(Console.ReadLine(), out range);
                } while (range == 0);

                string[] rangeText = fm.ReadFileLines(range);

                foreach (string line in rangeText)
                {
                    if (line == null) break;
                    Console.WriteLine(line);
                }
            }
            
            if (opt == 3)
            {
                Console.Clear();
                fm.WritePerson(CreatePerson());
            }

            Console.WriteLine("Digite ENTER para continuar: ");
            Console.ReadLine();
        } while (true);
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