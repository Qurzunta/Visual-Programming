using Student_Information_System.DBOP;
using Student_Information_System.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string path = "";
            if (args.Count() >0)
            {
                if (args[0].Contains(".txt"))
                    path = args[0];
                else
                    path = args[0] + "file.txt";
            }
            if (path == "")
            {
                path = "e:/file.txt";
            }
            DBOPStudent dbop = new DBOPStudent(path);
            Student student = new Student();

            string choice="";
            
            Console.WriteLine("\t\t\t\tVisual Programming Assignment # 1\n\n");
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t\t\t1 :  Create Student Profile");
            Console.WriteLine("\t\t\t\t2 :  Search Student");
            Console.WriteLine("\t\t\t\t3 :  Delete Student Record");
            Console.WriteLine("\t\t\t\t4 :  Top 3 Student");
            Console.WriteLine("\t\t\t\t5 :  Mark Student Attendance");
            Console.WriteLine("\t\t\t\t6 :  View Attendance");
            Console.WriteLine("\t\t\t\t7 :  To Exit");

            Console.Write("\n\t\t\t\tYour Choice.....: ");
            choice = Console.ReadLine();
          
            Console.Clear();

            switch (choice)
            {
                case "1":
                   
                    Console.Write("\n\n\t\t\t\tEnter Enrollment   : ");
                    student.setenrollment(Console.ReadLine());
                    Console.Write("\t\t\t\tEnter Name         : ");
                    student.setname(Console.ReadLine());
                    Console.Write("\t\t\t\tEnter Semester     : ");
                    student.setsemester(Console.ReadLine());
                    Console.Write("\t\t\t\tEnter CGPA         : ");
                    student.setcgpa(double.Parse(Console.ReadLine()));
                    Console.Write("\t\t\t\tEnter Department   : ");
                    student.setdepartment(Console.ReadLine());
                    Console.Write("\t\t\t\tEnter University   : ");
                    student.setuniversity(Console.ReadLine());

                    bool result = dbop.Add_Student(student);
                    if (result.Equals(true))
                        Console.WriteLine("\n\t\t\t\tStudent Has Been Added Successfully");
                    else
                        Console.WriteLine("\n\t\t\t\tStudent Alreay Exist With This Enrollment");
                   
                    Console.ReadLine();
                    Main(args);
                    break;
                case "2":
                    #region[Search Student]
                    Console.WriteLine("\n\t\t\t\tSearch Student");
                    Console.WriteLine("\n\n");
                    Console.WriteLine("\t\t\t\t1 : Search By Enrollment");
                    Console.WriteLine("\t\t\t\t2 : Search By Name");
                    Console.WriteLine("\t\t\t\t3 : Search By Semester");
                    Console.Write("\n\t\t\t\tYour Choice      : ");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("\t\t\t\tSearch By Enrollment");
                            Console.WriteLine("\n\n");
                            Console.Write("\t\t\t\tEnter Enrollment  : ");
                            choice = Console.ReadLine();
                            student = dbop.SearchByID(choice);
                            if (student.getenrollment() != "")
                            {
                                Console.WriteLine("\n\n\t\t\t\tStudent Found !");
                                Program.print_Student(student);
                            }
                            else
                                Console.WriteLine("\n\n\t\t\t\tNot Found!");
                           
                            Console.ReadLine();
                            Main(args);
                    
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("\t\t\t\tSearch By Name");
                            Console.WriteLine("\n\n");
                            Console.Write("\t\t\t\tEnter Name  : ");
                            choice = Console.ReadLine();
                            //student = dbop.SearchByName(choice);
                            //if (student.getenrollment() != "")
                            //{
                            //    Console.WriteLine("\n\n\t\t\t\tStudent Found !");
                            //    Program.print_Student(student);
                            //}
                            //else
                            //    Console.WriteLine("\n\n\t\t\t\tNot Found!");

                            ArrayList _aryStd = new ArrayList();
                            _aryStd = dbop._SearchByName(choice);
                            if(_aryStd!=null)
                            {
                                for (int i = 0; i < _aryStd.Count; i++)
                                {
                                    student = (Student)_aryStd[i];
                                    print_Student(student);
                                }

                            }else
                                Console.WriteLine("Not Found !");
                           
                            Console.ReadLine();
                            Main(args);
                    
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("\t\t\t\tSearch By Semester");
                            Console.WriteLine("\n\n");
                            Console.Write("\t\t\t\tEnter Semester  : ");
                            choice = Console.ReadLine();

                            ArrayList std = new ArrayList();
                            std = dbop.SearchBySemester(choice);
                            
                            if (std.Count.Equals(0))
                                Console.WriteLine("\n\n\t\t\t\tStudents Not Found!");
                            else{
                                Console.WriteLine("\n\n\t\t\t\tStudents Found !");
                                for (int i = 0; i < std.Count; i++)
                                {
                                    Program.print_Student((Student)std[i]);
                                }
                            }
                            
                            Console.ReadLine();
                            Main(args);
                            break;
                        default:
                            
                            break;
                    }
                    
                    Console.ReadLine();
                    Main(args);
                    break;
                    #endregion
                case "3":
                     Console.Clear();
                     Console.WriteLine("\t\t\t\tDelete By Enrollment");
                     Console.WriteLine("\n\n");
                     Console.Write("\t\t\t\tEnter Enrollment  : ");
                     choice = Console.ReadLine();
                     bool isDeleted = dbop.Delete_Student(choice);
                     if (isDeleted == true)
                        Console.WriteLine("\n\n\t\t\t\tStudent Has Been Deleted Successfully");
                     else
                        Console.WriteLine("\n\n\t\t\t\tStudent Doesnot Exist!");
                     
                    Console.ReadLine();
                    Main(args);

                    break;
                case "4":

                    Console.Clear();
                    Console.WriteLine("\t\t\t\tTop 3 Students");
                    ArrayList topStudent = new ArrayList();

                    Console.Write("\n\n\t\t\t\tEnter Semester  : ");
                    choice = Console.ReadLine();

                    topStudent = dbop.Top3Student(choice);
                    if (topStudent != null)
                    {
                        for (int i = 0; i < topStudent.Count; i++)
                        {
                            print_Student((Student)topStudent[i]);
                        }
                    }
                    else {
                        Console.WriteLine("\n\n\n\t\t\t\tNot Enough Records !");
                    }
                    
                    Console.ReadLine();
                    Main(args);
                    break;
                case "5":

                    Console.Clear();
                    Console.WriteLine("\t\t\t\tMark Attendance");
                    Console.Write("\n\n\t\t\t\tEnter Semester  : ");
                    choice = Console.ReadLine();


                    ArrayList aryStd = new ArrayList();
                    aryStd = dbop.SearchBySemester(choice);
                    int[] attendance = new int[aryStd.Count];
                    if (aryStd.Count != 0)
                    {
                        Console.WriteLine("\n\n\t\t\tEnter 0 For Absent And 1 For Present");
                        Console.WriteLine("\n\n");
                        Console.WriteLine("\t\t\tEnrollment\tName\n\n");
                        for (int i = 0; i < aryStd.Count; i++)
                        {
                            Student std = new Student();
                            std = (Student)aryStd[i];
                            Console.Write("\t\t\t" + std.getenrollment());
                            Console.WriteLine("\t" + std.getname());
                            //Console.WriteLine("\t\t\t" + std.get);
                        }
                        Console.WriteLine("\n\n\t\t\tEnrollment\tStatus\n");
                        for (int i = 0; i < aryStd.Count; i++)
                        {
                            Student std = new Student();
                            std = (Student)aryStd[i];
                            Console.Write("\t\t\t" + std.getenrollment()+"\t:  ");
                            attendance[i] = getAttendanceInput();
                            
                        }
                        dbop.Mark_Attendance(choice, attendance);
                        Console.WriteLine("\n\n\t\t\t\tAttendance Has Been Recorded");
                    }
                    else {
                        Console.WriteLine("No Record Found!");
                    }

                    
                    Console.ReadLine();
                    Main(args);

                    break;
                case "6":
                    Console.WriteLine("\t\t\t\tView Attendance");
                    Console.Write("\n\n\t\t\t\tEnter Semester  : ");
                    choice = Console.ReadLine();

                    ArrayList aryViewAttendance = new ArrayList();
                    aryViewAttendance = dbop.View_Attendance(choice);

                    Console.WriteLine("\n\n\t\t\tEnrollment\t\tName\t\tStatus\n\n");

                    if (aryViewAttendance != null)
                    {
                        for (int i = 0; i < aryViewAttendance.Count; i++)
                        {
                            Attendance atd = new Attendance();
                            atd = (Attendance)aryViewAttendance[i];
                            Console.Write("\t\t\t"+atd.enrollment);
                            Console.Write("\t\t"+atd.name);
                            if (atd.status == 0)
                                Console.WriteLine("\t\t" + "Absent");
                            else
                                Console.WriteLine("\t\t" + "Present");
                            

                        }
                    }
                    else
                        Console.WriteLine("\n\n\t\t\t\tAttendance Doesn't Exist");
                    
                    Console.ReadLine();
                    Main(args);
                    break;
                case "7":
                    return;
                    
                default:
                    
                    Console.ReadLine();
                    Main(args);
                    break;
            }

            
            Console.ReadLine();
            Main(args);        
        }
        private static int getAttendanceInput()
        {
            string input = "";
            while(true)
            {
                  input = Console.ReadLine();
                  if (input == "1")
                      return 1;
                  else if (input == "0")
                      return 0;
                  else
                      Console.Write("\n\t\t\tIncorrect Input ! Write Again\n\t\t\t\t\t:  ");

            }
          
        }
        public static void print_Student(Student student)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t\t\tEnrollment   : " + student.getenrollment());
            Console.WriteLine("\t\t\t\tName         : " + student.getname());
            Console.WriteLine("\t\t\t\tSemester     : " + student.getsemester());
            Console.WriteLine("\t\t\t\tCGPA         : " + student.getcgpa());
            Console.WriteLine("\t\t\t\tDepartment   : " + student.getdepartment());
            Console.WriteLine("\t\t\t\tUniversity   : " + student.getuniversity());
        }
    }

}
