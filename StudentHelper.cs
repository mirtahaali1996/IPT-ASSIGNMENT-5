using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBIT.sqldataProject1.ClassHelper

{
    public class StudentHelper
    {
       

       private volatile Type _dependency;

        public void MyClass()
        {
            _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

                            //only this method will be exected HERE in this section to store the values in Student  Table. in SQL
        public void AddStudent(string SeatNo, string Name,string FatherName,string Address) 
        {
            Student std = new Student();
            std.SeatNo = SeatNo;
            std.Name = Name;
            std.FatherName = FatherName;
            std.Address = Address;
           

            var db = new IPTEntities1();               // Object for IPT DataBase.

            db.Students.Add(std);       //  values  will be added in Student table 

            db.SaveChanges();
          //  db.Dispose();
        }

        public List<Student> GetAllStudents()
        {

            var db = new IPTEntities1();

            var students = db.Students.ToList();

            return students;
        }

        public Student GetStudent(string SeatNo)
        {
            var db = new IPTEntities1();
            var temp = db.Students.Where(s => s.SeatNo == SeatNo).First();

            return temp;
            

        }
    }
}
