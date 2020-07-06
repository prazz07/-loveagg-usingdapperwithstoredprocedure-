using Dapper;
using SPDapper.Common;
using SPDapper.IServices;
using SPDapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SPDapper.Services
{
    public class StudentService : IStudentService
    {
        Student _ostudent = new Student();
        List<Student> _oStudent = new List<Student>();
        public string Delete(int studentid)
        {
            string message = "";
            try
            {
                _ostudent = new Student()
                {
                    StudentId=studentid
                };
                
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    var oStudents = con.Query<Student>("SP_Student",
                        this.SetParameters(_ostudent, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);
                    if (oStudents != null && oStudents.Count() > 0)
                    {
                        _ostudent = _oStudent.FirstOrDefault();
                    }
                }

            }
            catch(Exception ex)
             {
                message = ex.Message;
            }
            return message;
        }

        public Student Get(int studentid)
        {
            _ostudent = new Student();
            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                var oStudents = con.Query<Student>("SELECT * FROM Student WHERE studentid ="+studentid).ToList();

                if (oStudents != null && oStudents.Count() > 0)
                {
                    _ostudent = oStudents.SingleOrDefault();
                }
                return _ostudent;
            }
        }

        public List<Student> Gets()
        {
            _oStudent = new List<Student>();
            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                var oStudents = con.Query<Student>("SELECT * FROM Student").ToList();

                if (oStudents != null && oStudents.Count() > 0)
                {
                    _oStudent = oStudents;
                }
                return oStudents;
            }

        }

        public Student Save(Student oStudent)
        {
            _ostudent = new Student();
            try
            {
                int operationType = Convert.ToInt32(oStudent.StudentId == 0 ? OperationType.Insert:OperationType.Update);
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    var oStudents = con.Query<Student>("SP_Student",
                        this.SetParameters(oStudent,operationType),
                        commandType:CommandType.StoredProcedure); 
                    
                }
            
            }
            catch(Exception ex)
            {
                _ostudent.Message = ex.Message;

            }
            return _ostudent;

        }
        private DynamicParameters SetParameters(Student oStudent,int operationtype)
        {
            DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("@StudentId", oStudent.StudentId);
            //parameters.Add("@StudentId", oStudent.Name);
            //parameters.Add("@StudentId", oStudent.Roll);
            //parameters.Add("@OperationType", operationtype);
            //return parameters;
            parameters.Add("@StudentId", oStudent.StudentId);
            parameters.Add("@Name", oStudent.Name);
            parameters.Add("@Roll", oStudent.Roll);
            parameters.Add("@OperationType", operationtype);
            return parameters;

        }
    }
}
