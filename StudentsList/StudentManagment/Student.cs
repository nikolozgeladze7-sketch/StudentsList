namespace StudentsList.StudentManagment
{
    /// <summary>
    /// Represents a student with a number and grade, inherited from the <see cref="Person"/> class.
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

        /// <summary>
        /// Overrides the DisplayInfo method to include roll number and grade.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Roll Number: {RollNumber}, Grade: {Grade}");
        }
    }
}