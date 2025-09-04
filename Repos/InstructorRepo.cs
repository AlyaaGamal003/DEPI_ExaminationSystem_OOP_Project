using ExamSystem.Models;

namespace ExamSystem.Repos;

public class InstructorRepo
{
    public List<Instructor> Instructors { get; set; }
    public InstructorRepo()
    {
        Instructors = new List<Instructor>();
    }
    #region Instructor Management

    public void AddInstructor(Instructor instructor)
    {
        foreach (var i in Instructors)
        {
            if (i.Id == instructor.Id)
                throw new Exception("Instructor with this ID already exists.");
        }
        Instructors.Add(instructor);
    }

    public void RemoveInstructor(int instructorID)
    {
        foreach (var i in Instructors)
        {
            if (i.Id != instructorID) continue;
            Instructors.Remove(i);
            return;
        }
        throw new Exception("Instructor with this ID does not exist.");
    }

    public void EditInstructor(int instructorID, string newName, string newSpecialization)
    {
        foreach (var i in Instructors)
        {
            if (i.Id == instructorID)
            {
                i.Name = newName;
                i.Specialization = newSpecialization;
                return;
            }
        }
        throw new Exception("Instructor with this ID does not exist.");
    }
    public Instructor GetInstructorByID(int instructorID )
    {
        foreach (var i in Instructors)
        {
            if (i.Id == instructorID)
            {
                return i;
            }
        }
        return null;
    }
    public void DisplayAllInstructors()
    {
        foreach (var I in Instructors)
        {
            Console.WriteLine(I);
        }
    }
    #endregion
}