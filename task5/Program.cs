using System;
using System.Linq;

namespace StudentRegistrySystem
{
    // ─────────────────────────────────────────
    // CLASS: Student
    // ─────────────────────────────────────────
    class Student
    {
        private static int _nextId = 1000;

        public int StudentId { get; private set; }
        public string Name { get; set; }
        public string Faculty { get; set; }

        private double _gpa;
        public double GPA
        {
            get => _gpa;
            set
            {
                if (value < 0.0 || value > 4.0)
                    throw new ArgumentOutOfRangeException(nameof(GPA), "GPA must be between 0.0 and 4.0.");
                _gpa = value;
            }
        }

        public Student(string name, double gpa, string faculty)
        {
            StudentId = _nextId++;
            Name = name;
            Faculty = faculty;
            GPA = gpa;           // validated via property setter
        }

        public override string ToString()
        {
            return $"  ID: {StudentId,-6} | Name: {Name,-20} | GPA: {GPA:F2} | Faculty: {Faculty}";
        }
    }

    // ─────────────────────────────────────────
    // CLASS: Registry
    // ─────────────────────────────────────────
    class Registry
    {
        private const int MaxCapacity = 100;
        private Student[] _students = new Student[MaxCapacity];
        private int _count = 0;

        // Add a student to the registry
        public void Add(Student student)
        {
            if (_count >= MaxCapacity)
                throw new InvalidOperationException("Registry is full. Maximum capacity of 100 students reached.");

            _students[_count++] = student;
            Console.WriteLine($"\n  [OK] Student added successfully. Assigned ID: {student.StudentId}");
        }

        // Find a student by ID — returns null if not found
        public Student FindById(int id)
        {
            for (int i = 0; i < _count; i++)
                if (_students[i].StudentId == id)
                    return _students[i];
            return null;
        }

        // Find all students matching a name (case-insensitive)
        public Student[] FindByName(string name)
        {
            return _students
                .Take(_count)
                .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        // Return top N students sorted by GPA descending
        public Student[] GetTopStudents(int n)
        {
            return _students
                .Take(_count)
                .OrderByDescending(s => s.GPA)
                .Take(n)
                .ToArray();
        }

        // Print all students in the registry
        public void PrintAll()
        {
            if (_count == 0)
            {
                Console.WriteLine("  Registry is empty.");
                return;
            }

            Console.WriteLine($"\n  All Students ({_count}/{MaxCapacity}):");
            Console.WriteLine("  " + new string('─', 65));
            for (int i = 0; i < _count; i++)
                Console.WriteLine($"  {i + 1,3}. {_students[i]}");
            Console.WriteLine("  " + new string('─', 65));
        }

        public int Count => _count;
    }

    // ─────────────────────────────────────────
    // MAIN PROGRAM
    // ─────────────────────────────────────────
    class Program
    {
        static Registry registry = new Registry();

        static void Main(string[] args)
        {
            Console.WriteLine("\n  ╔══════════════════════════════════════╗");
            Console.WriteLine("  ║      STUDENT REGISTRY SYSTEM         ║");
            Console.WriteLine("  ╚══════════════════════════════════════╝");

            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": FindById(); break;
                    case "3": FindByName(); break;
                    case "4": DisplayTopStudents(); break;
                    case "5": registry.PrintAll(); break;
                    case "6":
                        Console.WriteLine("\n  Goodbye! Registry session ended.\n");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\n  [!] Invalid choice. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }

        // ── Menu ──────────────────────────────
        static void ShowMenu()
        {
            Console.WriteLine("\n  ┌──────────────────────────────────┐");
            Console.WriteLine("  │             MENU                 │");
            Console.WriteLine("  ├──────────────────────────────────┤");
            Console.WriteLine("  │  1. Add a new student            │");
            Console.WriteLine("  │  2. Find student by ID           │");
            Console.WriteLine("  │  3. Find students by name        │");
            Console.WriteLine("  │  4. Display top N students       │");
            Console.WriteLine("  │  5. Print all students           │");
            Console.WriteLine("  │  6. Exit                         │");
            Console.WriteLine("  └──────────────────────────────────┘");
            Console.Write("  Select an option: ");
        }

        // ── Option 1: Add Student ─────────────
        static void AddStudent()
        {
            Console.WriteLine("\n  ── Add New Student ──");

            string name = ReadNonEmpty("  Enter name: ");

            double gpa = ReadGPA("  Enter GPA (0.0 – 4.0): ");

            string faculty = ReadNonEmpty("  Enter faculty: ");

            try
            {
                var student = new Student(name, gpa, faculty);
                registry.Add(student);
                Console.WriteLine(student);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\n  [!] {ex.Message}");
            }
        }

        // ── Option 2: Find by ID ──────────────
        static void FindById()
        {
            Console.WriteLine("\n  ── Find Student by ID ──");
            Console.Write("  Enter student ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("  [!] Invalid ID. Please enter a number.");
                return;
            }

            Student s = registry.FindById(id);
            if (s == null)
                Console.WriteLine($"  [!] No student found with ID {id}.");
            else
            {
                Console.WriteLine("  Found:");
                Console.WriteLine(s);
            }
        }

        // ── Option 3: Find by Name ────────────
        static void FindByName()
        {
            Console.WriteLine("\n  ── Find Students by Name ──");
            string name = ReadNonEmpty("  Enter name to search: ");

            Student[] results = registry.FindByName(name);
            if (results.Length == 0)
                Console.WriteLine($"  [!] No students found matching \"{name}\".");
            else
            {
                Console.WriteLine($"  Found {results.Length} student(s):");
                Console.WriteLine("  " + new string('─', 65));
                foreach (var s in results)
                    Console.WriteLine(s);
                Console.WriteLine("  " + new string('─', 65));
            }
        }

        // ── Option 4: Top N Students ──────────
        static void DisplayTopStudents()
        {
            Console.WriteLine("\n  ── Top Students by GPA ──");
            Console.Write("  Enter N: ");

            if (!int.TryParse(Console.ReadLine(), out int n) || n < 1)
            {
                Console.WriteLine("  [!] Please enter a positive integer.");
                return;
            }

            if (registry.Count == 0)
            {
                Console.WriteLine("  Registry is empty.");
                return;
            }

            Student[] top = registry.GetTopStudents(n);
            Console.WriteLine($"\n  Top {top.Length} Student(s) by GPA:");
            Console.WriteLine("  " + new string('─', 65));
            for (int i = 0; i < top.Length; i++)
                Console.WriteLine($"  #{i + 1,-4}{top[i]}");
            Console.WriteLine("  " + new string('─', 65));
        }

        // ── Helpers ───────────────────────────
        static string ReadNonEmpty(string prompt)
        {
            string value;
            do
            {
                Console.Write(prompt);
                value = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("  [!] This field cannot be empty.");
            } while (string.IsNullOrEmpty(value));
            return value;
        }

        static double ReadGPA(string prompt)
        {
            double gpa;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out gpa) && gpa >= 0.0 && gpa <= 4.0)
                    return gpa;
                Console.WriteLine("  [!] Invalid GPA. Must be a number between 0.0 and 4.0.");
            }
        }
    }
}