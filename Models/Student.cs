namespace ExamSystem.Models;

public class Student : User
{ 
    public string Email { get; set; }
    public List<Exam> Exams { get; set; }
    public List<Course> Courses { get; set; }
    
   
    
    public Student(int id, string name, string email):base(id, name)
    {
        Email = email;
        Exams = new List<Exam>();
        Courses = new List<Course>();
       
    }

    public override string ToString()
    {
        return $"Student ID {Id}, Name: {Name}, Email: {Email}";
    }

   

   
}