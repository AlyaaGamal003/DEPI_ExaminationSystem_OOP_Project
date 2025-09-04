namespace ExamSystem.Models;

public class MCQ : Question
{ 
  public List<string> Options{ get; set; }
  public int CorrectAnswer{ get; set; }

  public MCQ(int id, string title, decimal mark, Exam exam, List<string> options, int correctAnswer) : base(id, title, mark, exam)
  {
    Options = options ?? new List<string>();
    CorrectAnswer = correctAnswer;
  }
  public bool CheckAnswer(int option) => option - 1 == CorrectAnswer;
}

