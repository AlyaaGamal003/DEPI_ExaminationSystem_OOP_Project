namespace ExamSystem.Models;

public class StudentCourses
{
    public Student Student { get; set; }
    public Course Course { get; set; }

    public StudentCourses(Student student, Course course)
    {
        Student = student;
        Course = course;
    }
    
}