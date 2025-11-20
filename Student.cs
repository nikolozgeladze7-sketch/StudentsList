namespace StudentsList
{
    /// <summary>
    /// წარმოადგენს სტუდენტს, რომელსაც აქვს ნომრისა და შეფასების ნიშანი, რომელიც მემკვიდრეობით მიიღება <see cref="Person"/> კლასიდან.
    /// </summary>
    public class Student : Person
    {
        public int RollNumber { get; set; }
        public char Grade { get; set; }

        public Student(string name, int rollNumber, char grade)
            : base(name)
        {
            RollNumber = rollNumber;
            Grade = grade;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Roll Number: {RollNumber}, Grade: {Grade}");
        }
    }
}

