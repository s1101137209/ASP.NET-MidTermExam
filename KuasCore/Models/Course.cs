using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Models
{
    public class Course
    {
        public string ID { get; set; }

        public string NAME { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return "Course: Id = " + ID + ", Name = " + NAME + ".";
        }
    }
}
