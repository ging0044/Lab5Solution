using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution
{
    public class Course
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int WeeklyHours { get; set; }
        public double Fee { get; set; }
        public int MaxEnrollment {get; set;}

        ArrayList students;

        public Course(string code, string title)
        {
            Code = code;
            Title = title;
            students = new ArrayList();
        }

        //add your implementation here

        public RegistrationResult addCourse(Student student)
        {
            if (students != null)
            {
                if (students.Contains(student))
                {
                    return RegistrationResult.ALREADY_REGISTERED;
                }
                if (students.Count == MaxEnrollment)
                {
                    return RegistrationResult.EXCEED_MAX_REGISTRATION;
                }
            }
            students.Add(student);
            return RegistrationResult.SUCCESS;
        }
    }
}
