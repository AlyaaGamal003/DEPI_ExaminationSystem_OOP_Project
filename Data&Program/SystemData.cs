using ExamSystem.Models;
using ExamSystem.Repos;

namespace ExamSystem;

public class SystemData
{
        public StudentRepo StudentRepo { get; private set; }
        public InstructorRepo InstructorRepo { get; private set; }
        public CourseRepo CourseRepo { get; private set; }
        public ExamService ExamService { get; private set; }
        public ExamRepo ExamRepo { get; private set; }

        public SystemData()
        {
            StudentRepo = new StudentRepo();
            InstructorRepo = new InstructorRepo();
            CourseRepo = new CourseRepo();
            ExamService = new ExamService();
            ExamRepo = new ExamRepo(); // Add this line
        }

        public void GenerateSampleData()
        {
            // Add sample instructors
            var instructor1 = new Instructor(1, "Dr. Smith", "Computer Science");
            var instructor2 = new Instructor(2, "Prof. Johnson", "Mathematics");
            InstructorRepo.AddInstructor(instructor1);
            InstructorRepo.AddInstructor(instructor2);

            // Add sample courses
            var course1 = new Course(1, "Programming Fundamentals", "Introduction to programming", 100, instructor1);
            var course2 = new Course(2, "Database Systems", "Database design and management", 100, instructor1);
            CourseRepo.AddCourse(course1);
            CourseRepo.AddCourse(course2);

            // Add sample students
            var student1 = new Student(1, "Alice Johnson", "alice@email.com");
            var student2 = new Student(2, "Bob Smith", "bob@email.com");
            StudentRepo.AddStudent(student1);
            StudentRepo.AddStudent(student2);

            // Enroll students in courses
            course1.EnrollStudent(student1);
            course1.EnrollStudent(student2);
            course2.EnrollStudent(student1);

            // Create sample exam
            var exam1 = new Exam(1, "Midterm Exam", false, course1);
            
            // Add questions to exam
            var mcqOptions = new List<string> { "Option A", "Option B", "Option C", "Option D" };
            var mcq1 = new MCQ(1, "What is inheritance?", 10, exam1, mcqOptions, 0);
            var tf1 = new TrueFalse(2, "OOP stands for Object Oriented Programming", 5, exam1, true);
            var essay1 = new Essay(3, "Explain the concept of polymorphism", 15, exam1);

            exam1.AddQuestion(mcq1);
            exam1.AddQuestion(tf1);
            exam1.AddQuestion(essay1);

            course1.Exams.Add(exam1);
            exam1.IsStarted = true; // Start the exam for testing

            Console.WriteLine("Sample data generated successfully!");
        }

        public void DisplayAllData()
        {
            Console.WriteLine("\n=== ALL INSTRUCTORS ===");
            InstructorRepo.DisplayAllInstructors();
            
            Console.WriteLine("\n=== ALL COURSES ===");
            CourseRepo.DisplayAllCourses();
            
            Console.WriteLine("\n=== ALL STUDENTS ===");
            StudentRepo.DisplayAllStudents();
        }

        public void DisplayReports()
        {
            var studentExams = ExamService.GetAllStudentExams();
            if (studentExams.Count == 0)
            {
                Console.WriteLine("No exam results available.");
                return;
            }

            Console.WriteLine("\n=== EXAM REPORTS ===");
            var reports = studentExams.Select(se => new Report(se)).ToList();
            
            foreach (var report in reports)
            {
                Console.WriteLine(report.ShowReport());
            }

            // Demonstrate comparison if we have at least 2 reports
            if (reports.Count >= 2)
            {
                Console.WriteLine("\n=== STUDENT COMPARISON ===");
                Report.CompareStudents(reports[0], reports[1]);
            }
        } 
}
