using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System
{
    class Student
    {
        #region[variables]

        private string enrollment;
        private string name;
        private string semester;
        private double cgpa;
        private string department;
        private string university;

        #endregion

        #region[Constructors]

        public Student()
        {
            this.enrollment = "";
            this.name = "";
            this.semester = "";
            this.cgpa = 0;
            this.department = "";
            this.university = "";
        }

        public Student(string enrollment, string name, string semester, double cgpa, string department, string university)
        {
            this.enrollment = enrollment;
            this.name = name;
            this.semester = semester;
            this.cgpa = cgpa;
            this.department = department;
            this.university = university;
        }

        #endregion

        #region[Accessor Functions]

        public string getenrollment()
       {
           return enrollment;
       }
       public string getname()
       {
           return name;
       }
       public string getsemester()
       {
           return semester;
       }
       public double getcgpa()
       {
           return cgpa;
       }
       public string getdepartment()
       {
           return department;
       }
       public string getuniversity()
       {
           return university;
       }

        #endregion

        #region[setter functions]

       public bool setenrollment(string enrollment)
       {
           this.enrollment=enrollment;
           return true;
       }
       public bool setname(string name)
       {
           this.name = name;
           return true;
       }
       public bool setsemester(string semester)
       {
           this.semester = semester;
           return true;
       }
       public bool setcgpa(double cgpa)
       {
           this.cgpa = cgpa;
           return true;
       }
       public bool setdepartment(string department)
       {
           this.department = department;
           return true;
       }
       public bool setuniversity(string university)
       {
           this.university = university;
           return true;
       }

       #endregion

                
    }
}
