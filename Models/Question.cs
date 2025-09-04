namespace ExamSystem.Models;

public class Question 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Decimal Mark { get; set; }
    public Exam Exam { get; set; }
    public Question(int id, string title, Decimal mark, Exam exam)
    {
        Id = id;
        Title = title;
        Mark = mark;
        Exam = exam;
    }
    public void EditQuestion(string newTitle)
    {
        newTitle = newTitle.Trim();
        if (string.IsNullOrEmpty(newTitle))
        {
            throw new Exception("Question text cannot be empty.");
        }
        Title = newTitle;
    }
}