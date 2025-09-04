using ExamSystem.Models;

namespace ExamSystem.Repos;

public class CourseRepo
{
    public List<Course> Courses { get; set; }
    public CourseRepo()
    {
        Courses = new List<Course>();
    }
    #region Course Management
    public void AddCourse(Course course)
    {
        foreach (var c in Courses)
        {
            if (c.Id == course.Id)
                throw new Exception("Course with this ID already exists.");
        }
        Courses.Add(course);
    }
    public void RemoveCourse(int courseID)
    {
        foreach (var c in Courses)
        {
            if (c.Id != courseID) continue;
            Courses.Remove(c);
            return;
        }
        throw new Exception("Course with this ID does not exist.");
    }
    public void EditCourse(int courseID, string newTitle, string newDescription, decimal newMaxDegree)
    {
        foreach (var c in Courses)
        {
            if (c.Id == courseID)
            {
                c.Title = newTitle;
                c.Description = newDescription;
                c.MaxDegree = newMaxDegree;
                return;
            }
        }
        throw new Exception("Course with this ID does not exist.");
    }
    public Course GetCourseByID(int courseID)
    {
        foreach (var i in Courses)
        {
            if (i.Id == courseID)
            {
                return i;
            }
        }
        return null;
    }
    public void DisplayAllCourses()
    {
        foreach (var c in Courses)
        {
            Console.WriteLine(c);
        }
    }
    #endregion

}