namespace StudentsList.StudentManagment
{
    /// <summary>
    /// Represents an individual by name.
    /// </summary>
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
        }
    }
}