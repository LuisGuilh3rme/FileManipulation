namespace FileManipulation
{
    internal class Person
    {
        public string Name { get; set; }
        public char Gender { get; set; }

        public Person(string name, char gender)
        {
            Name = name;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"Nome: {Name} | Genero: {Gender}";
        }
    }
}
