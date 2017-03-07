using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution
{
    public class Student
    {
        private string name;

        protected ArrayList courses;

        protected Student(string name)
        {
            this.name = name;
            courses = new ArrayList();
        }
        
        public string Name
        {
            get { return name; }
        }

        public ArrayList getEnrolledCourses()
        {
            return courses;
        }

        public int totalWeeklyHours()
        {
            int hours = 0;
            foreach (Course course in courses)
            {
                hours += course.WeeklyHours;
            }
            return hours;
        }

        public int numEnrolledCourses()
        {
            int num = 0;
            if (courses != null)
            {
                foreach (Course course in courses)
                {
                    num += 1;
                }
            }
            return num;
        }

        public virtual double feePayable()
        {
            double fee = 0;
            if (courses != null)
            {
                foreach (Course course in courses)
                {
                    fee += course.Fee;
                }
            }
            if (TUITION_CAP)
            {
                return fee < TUITION_CAP ? fee : TUITION_CAP;
            }
            if (COOP_FEE)
            {
                return fee + COOP_FEE;
            }
        }

        public virtual RegistrationResult addCourse(Course course)
        {
            if (MAX_NUM_COURSES && numEnrolledCourses() == MAX_NUM_COURSES)
            {
                return RegistrationResult.EXCEED_MAX_NUM_OF_COURSES;
            }
            if (MAX_WEEKLY_HOURS && totalWeeklyHours() == MAX_WEEKLY_HOURS)
            {
                return RegistrationResult.EXCEED_MAX_HOURS;
            }
            RegistrationResult result = course.addCourse(this);
            if (result == RegistrationResult.SUCCESS)
            {
                courses.Add(course);
                return RegistrationResult.SUCCESS;
            }
            return result;
        }
    }
}
