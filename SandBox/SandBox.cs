using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PCB.SandBox
{
    [Serializable()]    //Set this attribute to all the classes that want to serialize
    public class Employee : ISerializable //derive your class from ISerializable
    {
        public int EmpId;
        public string EmpName;
        public string test2;

        //Default constructor
        public Employee()
        {
            EmpId = 0;
            EmpName = null;
        }

        public Employee(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            EmpId = (int)info.GetValue("EmployeeId", typeof(int));
            EmpName = (String)info.GetValue("EmployeeName", typeof(string));
        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("EmployeeId", EmpId);
            info.AddValue("EmployeeName", EmpName);
        }
    }
  
}
