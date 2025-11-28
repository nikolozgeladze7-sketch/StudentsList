using StudentsList;


        StudentManager manager = new StudentManager();
        char choice;

        do
        {
            Console.WriteLine("   Student Management System");
            Console.WriteLine("1. Add new student");
            Console.WriteLine("2. Show all students");
            Console.WriteLine("3. Search students with UI");
            Console.WriteLine("4. Update Grade");
            Console.WriteLine("5. Exit");
            Console.Write("Choose Operation: ");

            choice = Console.ReadKey().KeyChar;
            Console.WriteLine("\n");

            switch (choice)
            {
                case '1':
                    AddStudentUI(manager);
                    break;

                case '2':
                    manager.ShowAllStudents();
                    break;

                case '3':
                    SearchStudentUI(manager);
                    break;

                case '4':
                    UpdateGradeUI(manager);
                    break;

                case '5':
                    Console.WriteLine("Program has ended.");
                    break;

                default:
                    Console.WriteLine("Wrong Choice, Try again.\n");
                    break;
            }

        } while (choice != '5');
    /// <summary>
    /// მომხმარებელს სთხოვს სტუდენტის მონაცემების შეყვანას და სტუდენტს მითითებულ <see
    /// cref="StudentManager"/>-ში ამატებს.
    /// </summary>
    static void AddStudentUI(StudentManager manager)
    {
        Console.Write("Enter student's name: ");
        string? name = Console.ReadLine();

        int roll;
        while (true)
        {
            Console.Write("Enter roll number: ");
            if (int.TryParse(Console.ReadLine(), out roll))
                break;

            Console.WriteLine("Please enter right number!");
        }

        char grade;
        while (true)
        {
            Console.Write("Enter Grade (A-F): ");
        if (char.TryParse(Console.ReadLine()?.ToUpper(), out grade) && "ABCDEF".Contains(grade))
                break;

            Console.WriteLine(" Please enter right grade (A-F)!");
        }

        manager.AddStudent(name ?? "Unknown", roll, grade);
    }

    /// <summary>
    /// ეძებს სტუდენტს მისი ნომრის მიხედვით და აჩვენებს მის ინფორმაციას, თუ ის მოიძებნება.
    /// </summary>
    static void SearchStudentUI(StudentManager manager)
    {
        Console.Write("Roll number: ");
        if (int.TryParse(Console.ReadLine(), out int roll))
        {
            Student? s = manager.FindStudent(roll);
            if (s != null)
                s.DisplayInfo();
            else
                Console.WriteLine("Student was not found!\n");
        }
        else
        {
            Console.WriteLine(" Wrong format!\n");
        }
    }

    /// <summary>
    /// სტუდენტის შეფასებას აახლებს მისი ნომრის მიხედვით.
    /// </summary>
    static void UpdateGradeUI(StudentManager manager)
    {
        Console.Write("Enter Roll number: ");
        if (!int.TryParse(Console.ReadLine(), out int roll))
        {
            Console.WriteLine("Wrong number!\n");
            return;
        }

        Console.Write("Enter new grade (A-F): ");
        if (!char.TryParse(Console.ReadLine()?.ToUpper(), out char grade) || !"ABCDEF".Contains(grade))
        {
            Console.WriteLine("Wrong grade!\n");
            return;
        }

        manager.UpdateGrade(roll, grade);
    }