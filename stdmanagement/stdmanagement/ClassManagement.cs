using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stdmanagement
{
    class ClassManagement
    {
        public Class[] GetClasses()
        {
            var db = new OOPCSEntities1();
            var classes = db.Classes.ToArray();
            return classes;
        }

        public void AddClass(string name, string description)
        {
            var Class = new Class();
            Class.Name = name;
            Class.Description = description;

            var db = new OOPCSEntities1();
            db.Classes.Add(Class);
            db.SaveChanges();
        }

        public void EditClass(int id, string name, string description)
        {
            var db = new OOPCSEntities1();
            var oldClass = db.Classes.Find(id);
            oldClass.Name = name;
            oldClass.Description = description;

            db.Entry(oldClass).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteClass(int id)
        {
            var db = new OOPCSEntities1();
            var Class = db.Classes.Find(id);
            db.Classes.Remove(Class);
            db.SaveChanges();
        }

        public Class GetClass(int id)
        {
            var db = new OOPCSEntities1();
            var Class = db.Classes.Find(id);
            return Class;
        }
    }
}
