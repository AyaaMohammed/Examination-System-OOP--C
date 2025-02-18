using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Subject
    {
        public string NameSubject { get; set; }       

        public Subject(string _namesub) 
        {
            NameSubject = _namesub;     

        }

        public override string ToString()
        {
            return NameSubject;
        }
    }
}
