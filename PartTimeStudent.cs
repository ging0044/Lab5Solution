using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution
{
    class PartTimeStudent : Student
    {
        public const int MAX_NUM_COURSES = 2;

        //add your implementation here

        public PartTimeStudent(string name)
        {
            this.name = name;
            courses = new ArrayList();
        }
    }
}
