using ExamSystem.Models;
namespace ExamSystem.Repos;

public class ExamRepo
{
    public List<Exam> Exams { get; set; }
    public List<Course> Courses { get; set; }
    #region Exam Management
       public void AddExam(Exam exam)
       {
          foreach (var e in Exams)
          {
              if (e.Id == exam.Id) 
                  throw new Exception("Exam already exists");
          }
          Exams.Add(exam);
       }

       public Exam GetExamByID(int examID)
       {
           foreach (var course in Courses)
           {
               if (course.Exams != null)
               {
                   foreach (var exam in course.Exams)
                   {
                       if (exam.Id == examID)
                       {
                           return exam;
                       }
                   }
               }
           }
           return null;
       }
       public void DisplayAllExams()
       {
           foreach (var c in Courses)
           {
               if (c.Exams != null)
               {
                   Console.WriteLine(c.Exams);
               }
           }
       }

       public void RemoveExam(int examID)
       {
           foreach (var course in Courses)
           {
               if (course.Exams != null)
               {
                   for (int i = course.Exams.Count - 1; i >= 0; i--)
                   {
                       if (course.Exams[i].Id == examID)
                       {
                           course.Exams.RemoveAt(i);
                           return;
                       }
                   }
               }
           }
           throw new Exception("Exam with this ID does not exist.");
       }

       public void EditExam(int examID, string newTitle, decimal newTotalMarks, DateTime newStartDate)
       {
           Exam exam = GetExamByID(examID);
           if (exam == null)
           {
               throw new Exception("Exam with this ID does not exist.");
           }
       
           if (exam.IsStarted)
           {
               throw new Exception("Cannot edit an exam that has already started.");
           }
           if (newTotalMarks > exam.Course.MaxDegree)
           {
               throw new Exception($"Total marks cannot exceed course maximum degree ({exam.Course.MaxDegree}).");
               return;
           }
       
           exam.Title = newTitle;
           exam.TotalMarks = newTotalMarks;
           exam.IsStarted = true;
       }
       #endregion
}