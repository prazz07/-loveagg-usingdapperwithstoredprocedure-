using SPDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPDapper.IServices
{
    public interface IStudentService
    {
        Student Save(Student oStudent);
        List<Student> Gets();
        Student Get(int studentid);
        string Delete(int studentid);

    }
}
