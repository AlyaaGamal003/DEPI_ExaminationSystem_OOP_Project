namespace ExamSystem.Models;

public class StudentExams
{
    public Decimal Score { get; set; }
    public Student Student { get; set; }
    public Exam Exam { get; set; }

    public StudentExams(Decimal score,Student student  ,Exam exam)
    {
        Score = score;
        Student = student;
        Exam = exam;
    }
}