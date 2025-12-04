using System.Text.Json;
using StudentsList.StudentManagment;

public class StudentManager
{
    /// <summary>
    /// List of students in the system.
    /// </summary>
    private List<Student> students = new List<Student>();
    private readonly string filePath;

    /// <summary>
    /// Student manager constructor. Initializes the student list from a JSON file.
    /// </summary>
    public StudentManager()
    {
        // Project directory
        string projectDir = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;

        // Data folder
        string dataDir = Path.Combine(projectDir, "Data");

        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);

        // JSON file path
        filePath = Path.Combine(dataDir, "students.json");

        // If file does not exist → create it
        if (!File.Exists(filePath))
        {
            using var f = File.Create(filePath);
            File.WriteAllText(filePath, "[]");
        }

        // Load data from JSON
        try
        {
            string json = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }
        catch
        {
            students = new List<Student>();
        }
    }

    /// <summary>
    /// Saves the current student list to the JSON file.
    /// </summary>
    private void SaveChanges()
    {
        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    /// <summary>
    /// Adds a new student to the system.
    /// </summary>
    public void AddStudent(string name, int rollNumber, char grade)
    {
        if (students.Any(s => s.RollNumber == rollNumber))
        {
            Console.WriteLine("Student with this roll number already exists!\n");
            return;
        }

        students.Add(new Student(name, rollNumber, grade));
        SaveChanges();

        Console.WriteLine("Student was successfully added!\n");
    }

    /// <summary>
    /// Shows all students in the system.
    /// </summary>
    public void ShowAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("There are no students in the system.\n");
            return;
        }

        foreach (var student in students)
            student.DisplayInfo();

        Console.WriteLine();
    }

    /// <summary>
    /// Finds a student by roll number.
    /// </summary>
    public Student? FindStudent(int rollNumber)
    {
        return students.FirstOrDefault(s => s.RollNumber == rollNumber);
    }

    /// <summary>
    /// Updates the grade of a student identified by roll number.
    /// </summary>
    public void UpdateGrade(int rollNumber, char newGrade)
    {
        Student? student = FindStudent(rollNumber);

        if (student == null)
        {
            Console.WriteLine("Student couldn't be found!\n");
            return;
        }

        student.Grade = newGrade;
        SaveChanges();

        Console.WriteLine("Grade was successfully updated!\n");
    }
}