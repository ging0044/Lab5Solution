using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution
{
    class RegistractionSystem
    {
        static void Main(string[] args)
        {
            ArrayList courses = GetCourses();
            ArrayList students = new ArrayList();

            //add your implementation here
            bool addAnotherStudent = true;
            do
            {
                Console.WriteLine("Enter the student's name:\n->");
                string name = Console.ReadLine();

                Console.WriteLine("What type of student?\n1. Full-time\n2. Part-time\n3. Co-op");
                Student newStudent = null;
                switch (Console.ReadLine())
                {
                    case "1":
                        newStudent = new FullTimeStudent(name);
                        break;
                    case "2":
                        newStudent = new PartTimeStudent(name);
                        break;
                    case "3":
                        newStudent = new CoopStudent(name);
                        break;
                }

                bool addAnotherCourse = true;
                do
                {
                    Console.WriteLine("Select a course:\n");
                    int i = 1;
                    Course[] courseArray;
                    courseArray = new Course[5];
                    foreach (Course course in GetCourses())
                    {
                        courseArray[i - 1] = course;
                        Console.WriteLine("{0}. {1}: {2}", i, course.Code, course.Title);
                        i++;
                    }
                    Course selectedCourse = null;
                    switch (Console.ReadLine())
                    {
                        case "1":
                            selectedCourse = courseArray[0];
                            break;
                        case "2":
                            selectedCourse = courseArray[1];
                            break;
                        case "3":
                            selectedCourse = courseArray[2];
                            break;
                        case "4":
                            selectedCourse = courseArray[3];
                            break;
                        case "5":
                            selectedCourse = courseArray[4];
                            break;
                    }
                    if (selectedCourse != null && newStudent != null)
                    {
                        RegistrationResult result = newStudent.addCourse(selectedCourse);
                        switch (result)
                        {
                            case RegistrationResult.ALREADY_REGISTERED:
                                Console.WriteLine("Course already registered");
                                break;
                            case RegistrationResult.EXCEED_MAX_HOURS:
                                Console.WriteLine("Course exceeds student max hours");
                                break;
                            case RegistrationResult.EXCEED_MAX_NUM_OF_COURSES:
                                Console.WriteLine("Course exceeds student max courses");
                                break;
                            case RegistrationResult.EXCEED_MAX_REGISTRATION:
                                Console.WriteLine("Course full, cannot register");
                                break;
                            case RegistrationResult.SUCCESS:
                                Console.WriteLine("Course registered successfully");
                                break;
                        }
                    }

                    if (newStudent != null)
                    {
                        Console.WriteLine("Enter another course? (y/n)\n->");
                        switch (Console.ReadLine())
                        {
                            case "y":
                                break;
                            default:
                                addAnotherCourse = false;
                                break;
                        }
                    }
                } while (addAnotherCourse); 

                Console.WriteLine("Add another student? (y/n)\n->");
                switch (Console.ReadLine())
                {
                    case "y":
                        break;
                    default:
                        addAnotherStudent = false;
                        break;
                }
            } while (addAnotherStudent);
        }

        private static ArrayList GetCourses()
        {
            ArrayList courses = new ArrayList();

            Course course = new Course("CST8282", "Introduction to Database Systems");
            course.WeeklyHours = 4;
            course.MaxEnrollment = 3;
            course.Fee = 300.0;
            courses.Add(course);

            course = new Course("CST8253", "Web Programming II");
            course.WeeklyHours = 2;
            course.MaxEnrollment = 4;
            course.Fee = 250.0;
            courses.Add(course);

            course = new Course("CST8256", "Web Programming Language I");
            course.WeeklyHours = 5;
            course.MaxEnrollment = 4;
            course.Fee = 400.0;
            courses.Add(course);

            course = new Course("CST8255", "Web Imaging and Animations");
            course.WeeklyHours = 2;
            course.MaxEnrollment = 3;
            course.Fee = 300.0;
            courses.Add(course);

            return courses;
        }
    }
}
