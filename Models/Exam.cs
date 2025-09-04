namespace ExamSystem.Models;

public class Exam
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Decimal TotalMarks { get; set; }
    public bool IsStarted { get; set; }
    public Course Course { get; set; }
    public List<Question> Questions { get; set; }
    

    public Exam(int id, string title, bool isStarted,Course course)
    {
        Id = id;
        Title = title;
        IsStarted = isStarted;
        Course = course;
        Questions = new List<Question>();
        TotalMarks = 0;
    }

    public void isStarted()
    {
        if (IsStarted)
            throw new Exception("Cannot Edit questions after the exam has started.");
    }

    #region Add, Delete, Update, Clear Question
        // Add
        public void AddQuestion(Question question)
        {
            isStarted();
            foreach (var q in Questions)
            {
                if (q.Title == question.Title)
                {
                    throw new Exception("Question already exists in the exam.");
                }
            }
            if (!Course.CanAddQuestion(question))
            {
                throw new Exception("Adding this question exceeds the maximum degree allowed for the course.");
            }
            Questions.Add(question);
            TotalMarks += question.Mark;
        }
        // remove 
        public void RemoveQuestion(int id)
        {
            isStarted();
            Question? foundQuestion = null;
            foreach (var q in Questions)
            {
                if (q.Id == id)
                {
                    foundQuestion = q;
                    break;
                }
            }
            if (foundQuestion != null)  
            { 
                Questions.Remove(foundQuestion);
                TotalMarks -= foundQuestion.Mark;
            }
            else throw new Exception("Question not found.");
        }
        public void Clear()
        {
            isStarted();
            Questions.Clear();
            TotalMarks = 0;
        }
        public void EditQuestion(int id, string newQuestion)
        {
            isStarted();
            Question? foundQuestion = null;
            foreach (var q in Questions)
            {
                if (q.Id == id)
                {
                    foundQuestion = q;
                    break;
                }
            }
            if (foundQuestion == null) throw new Exception("Question not found.");
            foundQuestion.EditQuestion(newQuestion);
        }
    #endregion
    
    public Exam DuplicateForCourse(int newId, Course newCourse)
    {
        var duplicatedExam = new Exam(newId, this.Title + " (Copy)", false, newCourse);
            
        foreach (var question in this.Questions)
        {
            Question newQuestion = null;
                
            if (question is MCQ mcq)
            {
                newQuestion = new MCQ(question.Id, question.Title, question.Mark, duplicatedExam, 
                    new List<string>(mcq.Options), mcq.CorrectAnswer);
            }
            else if (question is TrueFalse tf)
            {
                newQuestion = new TrueFalse(question.Id, question.Title, question.Mark, duplicatedExam, tf.CorrectAnswer);
            }
            else if (question is Essay essay)
            {
                newQuestion = new Essay(question.Id, question.Title, question.Mark, duplicatedExam);
            }

            if (newQuestion != null)
            {
                duplicatedExam.Questions.Add(newQuestion);
                duplicatedExam.TotalMarks += newQuestion.Mark;
            }
        }

        return duplicatedExam;
    }

    
}