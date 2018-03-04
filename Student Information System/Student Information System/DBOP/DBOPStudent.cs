using Student_Information_System.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.DBOP
{
    class DBOPStudent
    {
        string path;
        public DBOPStudent(string path)
        {
            this.path = path;
        }
        public bool Add_Student(Student student)
        {
            // First Check Student ID
            Student std = new Student();
            std = SearchByID(student.getenrollment());

            // if student doesnot exist 
            if (std.getenrollment() == "")
            {
                StreamWriter obj = new StreamWriter(path, true);
                obj.AutoFlush = true;
                obj.WriteLine(student.getenrollment());
                obj.WriteLine(student.getname());
                obj.WriteLine(student.getsemester());
                obj.WriteLine(student.getcgpa());
                obj.WriteLine(student.getdepartment());
                obj.WriteLine(student.getuniversity());
                obj.Close();
                return true;
            }

           
            return false;
        }

        #region[Searching Algos]

        public Student SearchByID(string enrollment)
        {
            string line;
            Student student;
            student = new Student();
            try
            {
                StreamReader obj = new StreamReader(path);
                while ((line = obj.ReadLine()) != null)
                {
                    if (line.Equals(enrollment))
                    {
                        student = new Student(enrollment, obj.ReadLine(), obj.ReadLine(), double.Parse(obj.ReadLine()), obj.ReadLine(), obj.ReadLine());
                        obj.Close();
                        return student;
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            obj.ReadLine();
                        }
                    }
                }
                obj.Close();
            }
            catch (Exception)
            {
                
                //throw;
                // if file doesn't exist will be executed for the first time.
                return student;
            }

            return student;
        }
        public Student SearchByName(string name)
        {
            string line;
            string enroll;
            Student student;
            student = new Student();
            StreamReader obj = new StreamReader(path);

            while ((line = obj.ReadLine()) != null)
            {
                //saving enrollment
                enroll = line;
                line = obj.ReadLine();
                if (line.Equals(name))
                {
                    student = new Student(enroll, line, obj.ReadLine(), double.Parse(obj.ReadLine()), obj.ReadLine(), obj.ReadLine());
                    obj.Close();
                    return student;
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        obj.ReadLine();
                    }
                }
            }
            obj.Close();
            return student;
        }
        public ArrayList _SearchByName(string name)
        {

            ArrayList aryStd = new ArrayList();
            string line;
            string enroll;
            Student student;
            student = new Student();
            try
            {
                 StreamReader obj = new StreamReader(path);

            while ((line = obj.ReadLine()) != null)
            {
                //saving enrollment
                enroll = line;
                line = obj.ReadLine();
                if (line.Equals(name))
                {
                    student = new Student(enroll, line, obj.ReadLine(), double.Parse(obj.ReadLine()), obj.ReadLine(), obj.ReadLine());
                    aryStd.Add(student);
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        obj.ReadLine();
                    }
                }
            }
            obj.Close();
            }
            catch (Exception)
            {
                
                //throw;
            }
            return aryStd;
        }
        public ArrayList SearchBySemester(string semester)
        {
            ArrayList studentArray = new ArrayList();

            Student student;
            
            string enroll;
            string name;

            string line;

            try
            {
                  StreamReader obj = new StreamReader(path);

            while ((line = obj.ReadLine()) != null)
            {
                // saving enrollment
                enroll = line;
                // saving name
                name = obj.ReadLine();

                line = obj.ReadLine();
                if (line.Equals(semester))
                {
                    student = new Student(enroll, name, line, double.Parse(obj.ReadLine()), obj.ReadLine(), obj.ReadLine());
                    studentArray.Add(student);
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        obj.ReadLine();
                    }
                }
            }
            obj.Close();
            }
            catch (Exception)
            {
                
                //throw;
            }
            return studentArray;

        }
        public ArrayList Top3Student(string semester)
        {
            ArrayList top3 = new ArrayList();
            ArrayList std = new ArrayList();

            Student student = new Student();

            std = SearchBySemester(semester);

            for (int i = 0; i < 3; i++)
            {
                int index = Top_Index(std);
                if (index != -1)
                {
                    student = (Student)std[index];

                    top3.Add(student);

                    std.RemoveAt(index);
                }
                else
                {
                  //  Console.WriteLine("Operation Could Not Be Completed");
                    return null;
                    
                }
            }    
            return top3;
        }
        private int Top_Index(ArrayList students)
        {
            Student std = new Student();
            Student top = new Student();
            double max = 0;
            int index = -1;

            if (students.Count != 0)
            {

                std = (Student)students[0];
                index = 0;
                top = std;
                max = std.getcgpa();

                for (int i = 0; i < students.Count; i++)
                {
                    std = (Student)students[i];
                    if (max < std.getcgpa())
                    {
                        max = std.getcgpa();
                        top = std;
                        index = i;
                    }
                }
            }

            return index;
        }

        #endregion

        public bool Delete_Student(string enrollment)
        {
            bool isDelete = false;
            string line;
            Student student;
            student = new Student();
            try
            {
                StreamReader obj = new StreamReader(path);
            string newPath = path;
            newPath = newPath.Replace(".txt", "1.txt");
            StreamWriter writer = new StreamWriter(newPath);
            writer.AutoFlush = true;

            while ((line = obj.ReadLine()) != null)
            {
                if (line.Equals(enrollment))
                {
                    isDelete = true;
                    obj.ReadLine();
                    obj.ReadLine();
                    obj.ReadLine();
                    obj.ReadLine();
                    obj.ReadLine();
                    line = obj.ReadLine();
                }
                if(line!=null)
                    writer.WriteLine(line);
            }
            
            obj.Close();
            writer.Close();

            obj = new StreamReader(newPath);
           
            writer = new StreamWriter(path);
            writer.AutoFlush = true;

            writer.Write(obj.ReadToEnd());
            writer.Close();
            obj.Close();

            File.Delete(newPath);
            }
            catch (Exception)
            {
                
                //throw;
            }

            return isDelete;
        }

        #region[Attendance]
        public bool Mark_Attendance(string semester, int[] status)
        {
            string newPath = path;
            newPath = newPath.Replace(".txt", semester+".txt");
            StreamWriter writer = new StreamWriter(newPath);
            writer.AutoFlush = true;


            ArrayList std = new ArrayList();
            std = SearchBySemester(semester);

            Student student = new Student();

            for (int i = 0; i < std.Count; i++)
            {
                student = (Student)std[i];
                writer.WriteLine(student.getenrollment());
                writer.WriteLine(student.getname());
                writer.WriteLine(status[i]);
            }
            writer.Close();
            return true;
        }
        public ArrayList View_Attendance(string semester)
        {
            ArrayList result = new ArrayList();
            string newPath = path;
            newPath = newPath.Replace(".txt", semester + ".txt");
            try
            {
                StreamReader reader = new StreamReader(newPath);
                string line = "";
                
                while((line=reader.ReadLine())!=null)
                {
                    Attendance atd = new Attendance();
                    atd.enrollment = line;
                    atd.name = reader.ReadLine();
                    atd.status = int.Parse(reader.ReadLine());

                    result.Add(atd);

                }
                reader.Close();

            }
            catch (Exception)
            {
                return null;
                //throw;
            }
            return result;
        }

        #endregion

    }
}
