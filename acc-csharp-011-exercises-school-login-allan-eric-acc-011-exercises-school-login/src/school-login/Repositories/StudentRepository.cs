using SchoolLogin.Models;

namespace SchoolLogin.Repositories
{
    public class StudentRepository
    {
        public static bool StudentExists(Student student)
        {
            if (string.IsNullOrEmpty(student.Email) || string.IsNullOrEmpty(student.Password))
            {
                throw new NullReferenceException("Fill in the required fields.");
            } 

            return GetStudents().Any(x => x.Email.ToLower() == student.Email.ToLower() && x.Password == student.Password);
        }

        public static List<Student> GetStudents()
        {
            List<Student> students = new()
            {
                new Student() { Email = "tulio.olivieri@betrybe.com", Password = "Tulio123" },
                new Student() { Email = "marina.novais@betrybe.com", Password = "Marina123" },
                new Student() { Email = "jaqueline.milsted@betrybe.com", Password = "Jack123" },
                new Student() { Email = "arthur.procopio@betrybe.com", Password = "Arthur123" }
            };
            return students;
        }
    }
}
