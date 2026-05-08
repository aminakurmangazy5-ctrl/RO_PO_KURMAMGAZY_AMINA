using System;

class Student
{
    private static int nextId = 1000;

    public string Name { get; set; }
    public int StudentId { get; }
    public string Faculty { get; set; }

    private double gpa;

    public double GPA
    {
        get { return gpa; }
        set
        {
            if (value >= 0.0 && value <= 4.0)
            {
                gpa = value;
            }
            else
            {
                Console.WriteLine("Invalid GPA! GPA must be between 0.0 and 4.0.");
            }
        }
    }

    public Student(string name, double gpa, string faculty)
    {
        Name = name;
        Faculty = faculty;
        StudentId = nextId++;
        GPA = gpa;
    }

    public void Print()
    {
        Console.WriteLine($"ID: {StudentId} | Name: {Name} | GPA: {GPA:F2} | Faculty: {Faculty}");
    }
}

class Registry
{
    private Student[] students = new Student[100];
    private int count = 0;

    public void Add(Student student)
    {
        if (count < students.Length)
        {
            students[count] = student;
            count++;
            Console.WriteLine("Student added successfully.");
        }
        else
        {
            Console.WriteLine("Registry is full!");
        }
    }

    public Student FindById(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (students[i].StudentId == id)
            {
                return students[i];
            }
        }

        return null;
    }

    public Student[] FindByName(string name)
    {
        Student[] results = new Student[count];
        int resultCount = 0;

        for (int i = 0; i < count; i++)
        {
            if (students[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                results[resultCount] = students[i];
                resultCount++;
            }
        }

        Student[] finalResults = new Student[resultCount];

        for (int i = 0; i < resultCount; i++)
        {
            finalResults[i] = results[i];
        }

        return finalResults;
    }

    public Student[] GetTopStudents(int n)
    {
        if (n > count)
        {
            n = count;
        }

        Student[] sorted = new Student[count];

        for (int i = 0; i < count; i++)
        {
            sorted[i] = students[i];
        }

        
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (sorted[j].GPA < sorted[j + 1].GPA)
                {
                    Student temp = sorted[j];
                    sorted[j] = sorted[j + 1];
                    sorted[j + 1] = temp;
                }
            }
        }

        Student[] topStudents = new Student[n];

        for (int i = 0; i < n; i++)
        {
            topStudents[i] = sorted[i];
        }

        return topStudents;
    }

    public void PrintAll()
    {
        if (count == 0)
        {
            Console.WriteLine("No students in registry.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            students[i].Print();
        }
    }
}

class Program
{
    static void Main()
    {
        Registry registry = new Registry();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Student Registry System ===");
            Console.WriteLine("1. Add new student");
            Console.WriteLine("2. Find student by ID");
            Console.WriteLine("3. Find students by name");
            Console.WriteLine("4. Display top N students");
            Console.WriteLine("5. Print all students");
            Console.WriteLine("6. Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter GPA: ");
                    if (!double.TryParse(Console.ReadLine(), out double gpa))
                    {
                        Console.WriteLine("Invalid GPA input.");
                        break;
                    }

                    Console.Write("Enter faculty: ");
                    string faculty = Console.ReadLine();

                    if (gpa < 0.0 || gpa > 4.0)
                    {
                        Console.WriteLine("GPA must be between 0.0 and 4.0.");
                        break;
                    }

                    Student student = new Student(name, gpa, faculty);
                    registry.Add(student);
                    break;

                case "2":
                    Console.Write("Enter student ID: ");

                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Student found = registry.FindById(id);

                        if (found != null)
                        {
                            found.Print();
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }

                    break;

                case "3":
                    Console.Write("Enter name: ");
                    string searchName = Console.ReadLine();

                    Student[] matches = registry.FindByName(searchName);

                    if (matches.Length == 0)
                    {
                        Console.WriteLine("No students found.");
                    }
                    else
                    {
                        foreach (Student s in matches)
                        {
                            s.Print();
                        }
                    }

                    break;

                case "4":
                    Console.Write("Enter N: ");

                    if (int.TryParse(Console.ReadLine(), out int n))
                    {
                        Student[] top = registry.GetTopStudents(n);

                        if (top.Length == 0)
                        {
                            Console.WriteLine("No students available.");
                        }
                        else
                        {
                            Console.WriteLine("\nTop Students:");

                            foreach (Student s in top)
                            {
                                s.Print();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid number.");
                    }

                    break;

                case "5":
                    registry.PrintAll();
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}