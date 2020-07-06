using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPDapper.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }

        public string Message { get; set; }

        /*internal List<Student> FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        /*

         public static implicit operator List<object>(Student v)
         {
             throw new NotImplementedException();
         }
     */
    }
}
