using StudentsList;

public class StudentManager
{
    /// <summary>
    /// წარმოადგენს სტუდენტების კოლექციას.
    /// </summary>
    private List<Student> students = new List<Student>();

    /// <summary>
    /// კოლექციაში ახალი სტუდენტის დამატება, თუ მისი ნომერი უნიკალურია.
    /// </summary>
    public void AddStudent(string name, int rollNumber, char grade)
    {
        foreach (var s in students)
        {
            if (s.RollNumber == rollNumber)
            {
                Console.WriteLine("Student with this roll number already exists!\n");
                return;
            }
        }

        students.Add(new Student(name, rollNumber, grade));
        Console.WriteLine("Student was succesfully added!\n");
    }



    /// <summary>
    /// აჩვენებს სისტემაში არსებული ყველა სტუდენტის შესახებ ინფორმაციას.
    /// </summary>
    public void ShowAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("There are not Students in the system.\n");
            return;
        }

        foreach (var student in students)
        {
            student.DisplayInfo();
        }
        Console.WriteLine();
    }

    /// <summary>
    /// პოულობს და აბრუნებს სტუდენტს მითითებული ნომრით.
    /// </summary>
    public Student FindStudent(int rollNumber)
    {
        foreach (var student in students)
        {
            if (student.RollNumber == rollNumber)
                return student;
        }
        return null;
    }

    /// <summary>
    /// აახლებს სტუდენტის შეფასებას, რომელიც იდენტიფიცირებულია მისი ნომრით.
    /// </summary>
    public void UpdateGrade(int rollNumber, char newGrade)
    {
        Student student = FindStudent(rollNumber);

        if (student == null)
        {
            Console.WriteLine("Students couldn't be found!\n");
            return;
        }

        student.Grade = newGrade;
        Console.WriteLine("Grade was succesfully updated!\n");
    }
}