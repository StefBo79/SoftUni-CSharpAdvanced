using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }  

        public int Count { get { return students.Count; } }

        public string RegisterStudent(Student student) 
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student found = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            if (found == null)
            {
                return "Student not found";
            }
            students.Remove(found);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject) 
        {
            List<Student> filter = students.Where(s => s.Subject == subject).ToList();
            if (filter.Count > 0)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");
                foreach (Student student in filter)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }
            return "No students enrolled for the subject";
        }

        public int GetStudentsCount() 
        {
            return students.Count();
        }

        public Student GetStudent(string firstName, string lastName) 
        {
            return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
