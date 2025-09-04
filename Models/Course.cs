namespace ExamSystem.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Decimal MaxDegree { get; set; }
    public Instructor Instructor { get; set; }
    public List<Exam> Exams { get; set; }
    public List<Student> Students { get; set; }
    
    public Course(int id, string title, string description, Decimal maxDegree,Instructor instructor)
    {
        Id = id;
        Title = title;
        Description = description;
        MaxDegree = maxDegree;
        Instructor = instructor;
        Exams = new List<Exam>();
        Students = new List<Student>();
    }
    
    public bool CanAddQuestion(Question question)
    {
        Decimal totalMarks = 0;

        foreach (var e in Exams)
            totalMarks += e.TotalMarks;

        return totalMarks + question.Mark <= MaxDegree;
    }
    
    public void EnrollStudent(Student student)
    {
        if (!Students.Contains(student))
        {
            Students.Add(student);
            if (student.Courses == null)
                student.Courses = new List<Course>();
            if (!student.Courses.Contains(this))
                student.Courses.Add(this);
        }
    }
    public override string ToString()
    {
        return $"Course ID: {Id}, Title: {Title}, Description: {Description}, MaxDegree: {MaxDegree}, Instructor: {Instructor}";
    }
}