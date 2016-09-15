using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ModelValidation
{
    class Program
    {
        static void Main(string[] args)
        {

            Validator();            
        }      

        private static void Validator()
        {
            var student = new Student()
            {
                //RollNo = 1,
                //Name = "Test"
            };

            var rules = new List<Rule<Student>>
                            {
                                new Rule<Student>(){ ValidateModel = (r)=> r.RollNo > 0, Message="Invalid Roll number."},
                                new Rule<Student>(){ ValidateModel = (r)=> !String.IsNullOrEmpty(r.Name), Message="Name cannot be empty."}
                            };

            var result = rules.Any(x => !x.ValidateModel(student));

            if (result)
            {
                var message = rules.Where(x => !x.ValidateModel(student)).Aggregate(new StringBuilder(), (sb, r) => sb.AppendLine(r.Message));

                Console.WriteLine(message);
            }
        }
    }


    public class Rule<T>
    {

        public Func<T, bool> ValidateModel;
        public string Message { get; set; }

    }

    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
    }

}

