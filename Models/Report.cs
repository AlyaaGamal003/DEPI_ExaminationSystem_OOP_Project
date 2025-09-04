namespace ExamSystem.Models;

public class Report : IComparable<Report>
{
    public StudentExams StudentExam { get; set; }
    private const decimal PassPercentage = 0.5m;
        
    public bool IsPassed => StudentExam.Score >= (StudentExam.Exam.TotalMarks * PassPercentage);

    public Report(StudentExams studentExam)
    {
        StudentExam = studentExam;
    }

    public string ShowReport()
    {
        return $"Exam: {StudentExam.Exam.Title}, Student: {StudentExam.Student.Name}, " +
               $"Course: {StudentExam.Exam.Course.Title}, Score: {StudentExam.Score}/{StudentExam.Exam.TotalMarks}, " +
               $"Result: {(IsPassed ? "Pass" : "Fail")}";
    }

    // The system should support comparing two students by their scores in an exam
    public int CompareTo(Report other)
    {
        if (other == null) return 1;
        return other.StudentExam.Score.CompareTo(this.StudentExam.Score); 
    }

    public static void CompareStudents(Report student1Report, Report student2Report)
    {
        Console.WriteLine("=== Student Comparison ===");
        Console.WriteLine(student1Report.ShowReport());
        Console.WriteLine(student2Report.ShowReport());
            
        var comparison = student1Report.CompareTo(student2Report);
        if (comparison < 0)
            Console.WriteLine($"{student2Report.StudentExam.Student.Name} scored higher than {student1Report.StudentExam.Student.Name}");
        else if (comparison > 0)
            Console.WriteLine($"{student1Report.StudentExam.Student.Name} scored higher than {student2Report.StudentExam.Student.Name}");
        else
            Console.WriteLine("Both students scored equally");
    }
}