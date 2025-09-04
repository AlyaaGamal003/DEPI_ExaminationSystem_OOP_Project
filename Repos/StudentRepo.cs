using ExamSystem.Models;

namespace ExamSystem.Repos;

public class StudentRepo
{
    public List<Student> Students { get; set; }
    public StudentRepo()
    {
        Students = new List<Student>();
    }
    #region Student Management
    public void AddStudent(Student student)
    {
        foreach (var s in Students)
        {
            if (s.Id == student.Id)
                throw new Exception("Student with this ID already exists.");
        }
        Students.Add(student);
    }
    public void RemoveStudent(int studentID)
    {
        foreach (var s in Students)
        {
            if (s.Id == studentID)
            {
                Students.Remove(s);
                return;
            }
        }
        throw new Exception("Student with this ID does not exist.");
    }
    public void EditStudent(int studentID, string newName, string newEmail)
    {
        foreach (var s in Students)
        {
            if (s.Id == studentID)
            {
                s.Name = newName;
                s.Email = newEmail;
                return;
            }
        }
        throw new Exception("Student with this ID does not exist.");
    }

    public Student GetStudentByID(int studentID)
    {
        foreach (var s in Students)
        {
            if (s.Id == studentID)
            {
                return s;
            }
        }
        return null;
    }

    public void DisplayAllStudents()
    {
        foreach (var s in Students)
        {
           Console.WriteLine(s);
        }
    }
    #endregion
}