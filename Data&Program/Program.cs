using ExamSystem;
using ExamSystem.Models;
using ExamSystem.Repos;

class Program
{
    private static SystemData systemData = new SystemData();
    
    static void Main(string[] args)
    {
        Console.WriteLine("=== Exam System Management ===");
        systemData.GenerateSampleData();
        bool exit = false;
        while (!exit)
        {
            DisplayMainMenu();
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    ManageStudents();
                    break;
                case "2":
                    ManageInstructors();
                    break;
                case "3":
                    ManageCourses();
                    break;
                case "4":
                    ManageExams();
                    break;
                case "5":
                    TakeExam();
                    break;
                case "6":
                    systemData.DisplayAllData();
                    break;
                case "7":
                    systemData.DisplayReports();
                    break;
                case "8":
                    exit = true;
                    Console.WriteLine("Exiting system. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
    
    static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("=== MAIN MENU ===");
        Console.WriteLine("1. Manage Students");
        Console.WriteLine("2. Manage Instructors");
        Console.WriteLine("3. Manage Courses");
        Console.WriteLine("4. Manage Exams");
        Console.WriteLine("5. Take Exam");
        Console.WriteLine("6. Core Data");
        Console.WriteLine("7. Exam Reports");
        Console.WriteLine("8. Exit");
        Console.Write("Enter your choice: ");
    }
    
    static void ManageStudents()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== STUDENT MANAGEMENT ===");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Remove Student");
            Console.WriteLine("3. Edit Student");
            Console.WriteLine("4. View All Students");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Enter your choice: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    RemoveStudent();
                    break;
                case "3":
                    EditStudent();
                    break;
                case "4":
                    systemData.StudentRepo.DisplayAllStudents();
                    break;
                case "5":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            
            if (!back)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
    
    static void AddStudent()
    {
        try
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            
            Console.Write("Enter Student Email: ");
            string email = Console.ReadLine();
            
            Student student = new Student(id, name, email);
            systemData.StudentRepo.AddStudent(student);
            Console.WriteLine("Student added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static void RemoveStudent()
    {
        try
        {
            Console.Write("Enter Student ID to remove: ");
            int id = int.Parse(Console.ReadLine());
            
            systemData.StudentRepo.RemoveStudent(id);
            Console.WriteLine("Student removed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static void EditStudent()
    {
        try
        {
            Console.Write("Enter Student ID to edit: ");
            int id = int.Parse(Console.ReadLine());
            
            Student currentStudent = systemData.StudentRepo.GetStudentByID(id);
            if (currentStudent == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }
        
            Console.Write($"Enter new Name (current: {currentStudent.Name}): ");
            string name = Console.ReadLine();
        
            Console.Write($"Enter new Email (current: {currentStudent.Email}): ");
            string email = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(name))
                name = currentStudent.Name;
            
            if (string.IsNullOrWhiteSpace(email))
                email = currentStudent.Email;
        
            systemData.StudentRepo.EditStudent(id, name, email);
            Console.WriteLine("Student updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static void ManageInstructors()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== INSTRUCTOR MANAGEMENT ===");
            Console.WriteLine("1. Add Instructor");
            Console.WriteLine("2. Remove Instructor");
            Console.WriteLine("3. Edit Instructor");
            Console.WriteLine("4. View All Instructors");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Enter your choice: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    AddInstructor();
                    break;
                case "2":
                    RemoveInstructor();
                    break;
                case "3":
                    EditInstructor();
                    break;
                case "4":
                    systemData.InstructorRepo.DisplayAllInstructors();
                    break;
                case "5":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            
            if (!back)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
    
    static void AddInstructor()
    {
        try
        {
            Console.Write("Enter Instructor ID: ");
            int id = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Instructor Name: ");
            string name = Console.ReadLine();
            
            Console.Write("Enter Instructor Specialization: ");
            string specialization = Console.ReadLine();
            
            Instructor instructor = new Instructor(id, name, specialization);
            systemData.InstructorRepo.AddInstructor(instructor);
            Console.WriteLine("Instructor added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static void RemoveInstructor()
    {
        try
        {
            Console.Write("Enter Instructor ID to remove: ");
            int id = int.Parse(Console.ReadLine());
            
            systemData.InstructorRepo.RemoveInstructor(id);
            Console.WriteLine("Instructor removed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static void EditInstructor()
    {
        try
        {
            Console.Write("Enter Instructor ID to edit: ");
            int id = int.Parse(Console.ReadLine());
            
            Instructor currentInstructor = systemData.InstructorRepo.GetInstructorByID(id);
            if (currentInstructor == null)
            {
                Console.WriteLine("Instructor not found!");
                return;
            }
        
            Console.Write($"Enter new Name (current: {currentInstructor.Name}): ");
            string name = Console.ReadLine();
        
            Console.Write($"Enter new Specialization (current: {currentInstructor.Specialization}): ");
            string specialization = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(name))
                name = currentInstructor.Name;
            
            if (string.IsNullOrWhiteSpace(specialization))
                specialization = currentInstructor.Specialization;
        
            systemData.InstructorRepo.EditInstructor(id, name, specialization);
            Console.WriteLine("Instructor updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static void ManageCourses()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== COURSE MANAGEMENT ===");
            Console.WriteLine("1. Add Course");
            Console.WriteLine("2. Remove Course");
            Console.WriteLine("3. Edit Course");
            Console.WriteLine("4. View All Courses");
            Console.WriteLine("5. Enroll Student in Course");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Enter your choice: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    AddCourse();
                    break;
                case "2":
                    RemoveCourse();
                    break;
                case "3":
                    EditCourse();
                    break;
                case "4":
                    systemData.CourseRepo.DisplayAllCourses();
                    break;
                case "5":
                    EnrollStudentInCourse();
                    break;
                case "6":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            
            if (!back)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
    
    static void AddCourse()
    {
        try
        {
            Console.Write("Enter Course ID: ");
            int id = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();
            
            Console.Write("Enter Course Description: ");
            string description = Console.ReadLine();
            
            Console.Write("Enter Course Max Degree: ");
            decimal maxDegree = decimal.Parse(Console.ReadLine());
            
            Console.Write("Enter Instructor ID: ");
            int instructorId = int.Parse(Console.ReadLine());
            
            Instructor instructor = systemData.InstructorRepo.GetInstructorByID(instructorId);
            if (instructor == null)
            {
                Console.WriteLine("Instructor not found!");
                return;
            }
            
            Course course = new Course(id, title, description, maxDegree, instructor);
            systemData.CourseRepo.AddCourse(course);
            Console.WriteLine("Course added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static void RemoveCourse()
    {
        try
        {
            Console.Write("Enter Course ID to remove: ");
            int id = int.Parse(Console.ReadLine());
            
            systemData.CourseRepo.RemoveCourse(id);
            Console.WriteLine("Course removed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static void EditCourse()
    {
        try
        {
            Console.Write("Enter Course ID to edit: ");
            int id = int.Parse(Console.ReadLine());
            
            Course currentCourse = systemData.CourseRepo.GetCourseByID(id);
            if (currentCourse == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }
        
            Console.Write($"Enter new Title (current: {currentCourse.Title}): ");
            string title = Console.ReadLine();
        
            Console.Write($"Enter new Description (current: {currentCourse.Description}): ");
            string description = Console.ReadLine();
        
            Console.Write($"Enter new Max Degree (current: {currentCourse.MaxDegree}): ");
            string maxDegreeInput = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(title))
                title = currentCourse.Title;
            
            if (string.IsNullOrWhiteSpace(description))
                description = currentCourse.Description;
            
            decimal maxDegree;
            if (string.IsNullOrWhiteSpace(maxDegreeInput))
                maxDegree = currentCourse.MaxDegree;
            else
                maxDegree = decimal.Parse(maxDegreeInput);
        
            systemData.CourseRepo.EditCourse(id, title, description, maxDegree);
            Console.WriteLine("Course updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static void EnrollStudentInCourse()
    {
        try
        {
            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());
            
            Student student = systemData.StudentRepo.GetStudentByID(studentId);
            Course course = systemData.CourseRepo.GetCourseByID(courseId);
            
            if (student == null || course == null)
            {
                Console.WriteLine("Student or Course not found!");
                return;
            }
            
            course.EnrollStudent(student);
            Console.WriteLine("Student enrolled successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static void ManageExams()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== EXAM MANAGEMENT ===");
            Console.WriteLine("1. Add Exam");
            Console.WriteLine("2. Remove Exam");
            Console.WriteLine("3. Edit Exam");
            Console.WriteLine("4. View All Exams");
            Console.WriteLine("5. Add Question to Exam");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Enter your choice: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    AddExam();
                    break;
                case "2":
                    RemoveExam();
                    break;
                case "3":
                    EditExam();
                    break;
                case "4":
                    DisplayAllExams();
                    break;
                case "5":
                    AddQuestionToExam();
                    break;
                case "6":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            
            if (!back)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    static void AddExam()
    {
        try
        {
            Console.Write("Enter Exam ID: ");
            int id = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Exam Title: ");
            string title = Console.ReadLine();
            
            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());
            
            Course course = systemData.CourseRepo.GetCourseByID(courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }
            
            Exam exam = new Exam(id, title, false, course);
            
            course.Exams.Add(exam);
            
            Console.WriteLine("Exam added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void RemoveExam()
    {
        try
        {
            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Exam ID to remove: ");
            int examId = int.Parse(Console.ReadLine());
            
            Course course = systemData.CourseRepo.GetCourseByID(courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }
            
            Exam examToRemove = course.Exams.FirstOrDefault(e => e.Id == examId);
            if (examToRemove == null)
            {
                Console.WriteLine("Exam not found in this course!");
                return;
            }
            
            course.Exams.Remove(examToRemove);
            Console.WriteLine("Exam removed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void EditExam()
    {
        try
        {
            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Exam ID to edit: ");
            int examId = int.Parse(Console.ReadLine());
            
            Course course = systemData.CourseRepo.GetCourseByID(courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }
            
            Exam exam = course.Exams.FirstOrDefault(e => e.Id == examId);
            if (exam == null)
            {
                Console.WriteLine("Exam not found!");
                return;
            }
            
            Console.Write($"Enter new Title (current: {exam.Title}): ");
            string title = Console.ReadLine();
            
            Console.Write($"Enter new Total Marks (current: {exam.TotalMarks}): ");
            string totalMarksInput = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(title))
                title = exam.Title;
                
            decimal totalMarks;
            if (string.IsNullOrWhiteSpace(totalMarksInput))
                totalMarks = exam.TotalMarks;
            else
                totalMarks = decimal.Parse(totalMarksInput);
            
            exam.Title = title;
            exam.TotalMarks = totalMarks;
            
            Console.WriteLine("Exam updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void DisplayAllExams()
    {
        Console.WriteLine("\n=== ALL EXAMS ===");
        
        foreach (var course in systemData.CourseRepo.Courses)
        {
            if (course.Exams.Count > 0)
            {
                Console.WriteLine($"\nCourse: {course.Title}");
                foreach (var exam in course.Exams)
                {
                    Console.WriteLine($"  Exam ID: {exam.Id}, Title: {exam.Title}, Total Marks: {exam.TotalMarks}, Status: {(exam.IsStarted ? "Started" : "Not Started")}");
                }
            }
        }
        
        if (systemData.CourseRepo.Courses.All(c => c.Exams.Count == 0))
        {
            Console.WriteLine("No exams found.");
        }
    }

    static void AddQuestionToExam()
    {
        try
        {
            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Exam ID: ");
            int examId = int.Parse(Console.ReadLine());
            
            Course course = systemData.CourseRepo.GetCourseByID(courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }
            
            Exam exam = course.Exams.FirstOrDefault(e => e.Id == examId);
            if (exam == null)
            {
                Console.WriteLine("Exam not found!");
                return;
            }
            
            Console.WriteLine("\nSelect Question Type:");
            Console.WriteLine("1. Multiple Choice (MCQ)");
            Console.WriteLine("2. True/False");
            Console.WriteLine("3. Essay");
            Console.Write("Enter your choice: ");
            
            string choice = Console.ReadLine();
            
            Console.Write("Enter Question ID: ");
            int questionId = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Question Text: ");
            string questionText = Console.ReadLine();
            
            Console.Write("Enter Question Marks: ");
            decimal marks = decimal.Parse(Console.ReadLine());
            
            Question question = null;
            
            switch (choice)
            {
                case "1": // MCQ
                    Console.Write("Enter number of options: ");
                    int optionCount = int.Parse(Console.ReadLine());
                    
                    List<string> options = new List<string>();
                    for (int i = 0; i < optionCount; i++)
                    {
                        Console.Write($"Enter option {i + 1}: ");
                        options.Add(Console.ReadLine());
                    }
                    
                    Console.Write("Enter correct option number (1-" + optionCount + "): ");
                    int correctOption = int.Parse(Console.ReadLine()) - 1;
                    
                    question = new MCQ(questionId, questionText, marks, exam, options, correctOption);
                    break;
                    
                case "2": // True/False
                    Console.Write("Is the statement true? (true/false): ");
                    bool isTrue = bool.Parse(Console.ReadLine());
                    
                    question = new TrueFalse(questionId, questionText, marks, exam, isTrue);
                    break;
                    
                case "3": // Essay
                    question = new Essay(questionId, questionText, marks, exam);
                    break;
                    
                default:
                    Console.WriteLine("Invalid question type.");
                    return;
            }
            
            exam.AddQuestion(question);
            Console.WriteLine("Question added to exam successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void TakeExam()
    {
        try
        {
            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Exam ID: ");
            int examId = int.Parse(Console.ReadLine());
            
            Student student = systemData.StudentRepo.GetStudentByID(studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }
            
            Course course = systemData.CourseRepo.GetCourseByID(courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }
            
            Exam exam = course.Exams.FirstOrDefault(e => e.Id == examId);
            if (exam == null)
            {
                Console.WriteLine("Exam not found!");
                return;
            }
            
            if (!exam.IsStarted)
            {
                exam.IsStarted = true;
            }
            
            systemData.ExamService.TakeExam(student, exam);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}