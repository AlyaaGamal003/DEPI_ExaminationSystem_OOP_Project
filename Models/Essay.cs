namespace ExamSystem.Models;

public class Essay : Question
{
    public Essay(int id, string title, decimal mark, Exam exam) : base(id, title, mark, exam)
    {
    }

    
}