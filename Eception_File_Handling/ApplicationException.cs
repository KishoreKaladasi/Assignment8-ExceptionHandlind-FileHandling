using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eception_File_Handling
{
    public class InvalidEmployeeDataException : Exception
    {
        public InvalidEmployeeDataException(string message) : base(message)
        {
        }
    }

    public class Employee
    {
        private int empno;
        private string ename;
        private double sal;
        private int deptno;

        public Employee(int empno, string ename, double sal, int deptno)
        {
            ValidateEmployeeData(empno, ename, deptno);
            this.empno = empno;
            this.ename = ename;
            this.sal = sal;
            this.deptno = deptno;
        }

        private void ValidateEmployeeData(int empno, string ename, int deptno)
        {
            if (empno == 0)
            {
                throw new InvalidEmployeeDataException("Employee number cannot be zero");
            }

            if (deptno == 0)
            {
                throw new InvalidEmployeeDataException("Department number cannot be zero");
            }

            if (string.IsNullOrWhiteSpace(ename))
            {
                throw new InvalidEmployeeDataException("Employee name cannot be null or empty");
            }
        }

        
    }
}
