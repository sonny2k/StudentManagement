using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace std_management
{
    class StudentView
    {
        public StudentView(PM14010 T)
        {
            this.id = T.id;
            this.Code = T.Code;
            this.Name = T.Name;
            if (T.Gender == true)
                this.Gender = "Male";
            if (T.Gender == false)
                this.Gender = "Female";
            this.Hometown = T.Hometown;
        }
        public int id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Hometown { get; set; }
    }
}
