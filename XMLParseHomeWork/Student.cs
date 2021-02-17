using System;
using System.Collections.Generic;
using System.Text;

namespace XMLParseHomeWork
{
    public class Student
    {
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string GroupName { get; set; }

        //Оценки
        public int[] Ratings { get; set; }

    }
}
