namespace ExamSystem.Models;

public class Instructor : User
{
    public string Specialization { get; set; }
    public List<Course> Courses { get; set; }
    
    public Instructor(int id, string name, string specialization) : base(id, name)
    {
        Specialization = specialization;
        Courses = new List<Course>();
    }

    public override string ToString()
    {
        return $"Instructor ID: {Id}, Name: {Name}, Specialization: {Specialization}";
    }

    
   
}