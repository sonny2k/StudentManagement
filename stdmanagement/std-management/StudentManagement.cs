using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace std_management
{
    class StudentManagement
    {
        public PM14010[] GetStudents()
        {
            var db = new OOPCSEntities();
            var Students = db.PM14010.ToArray();
            return Students;
        }

        public void CreateStudent(string Code, string Name, bool Gender, string Hometown)
        {
            var Student = new PM14010();
            Student.Code = Code;
            Student.Name = Name;
            Student.Hometown = Hometown;
            Student.Gender = Gender;

            var db = new OOPCSEntities();
            db.PM14010.Add(Student);
            db.SaveChanges();
        }

        public void UpdateStudent(int id, string Code, string Name,bool Gender, string Hometown)
        {
            var db = new OOPCSEntities();
            var oldStudent = db.PM14010.Find(id);
            oldStudent.Code = Code;
            oldStudent.Name = Name;
            oldStudent.Gender = Gender;
            oldStudent.Hometown = Hometown;

            db.Entry(oldStudent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var db = new OOPCSEntities();
            var std = db.PM14010.Find(id);
            db.PM14010.Remove(std);
            db.SaveChanges();
        }

        public PM14010 GetStudent(int id)
        {
            var db = new OOPCSEntities();
            var std = db.PM14010.Find(id);
            return std;
        }
    }
}
