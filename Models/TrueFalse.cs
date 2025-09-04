namespace ExamSystem.Models;

public class TrueFalse : Question
{
    public bool CorrectAnswer {get; set;}
    public TrueFalse(int id, string title, decimal mark, Exam exam, bool correctAnswer) : base(id, title, mark, exam)
    {
        CorrectAnswer = correctAnswer;
    }
    
    public bool CheckAnswer(bool option) => option == CorrectAnswer;

   
}