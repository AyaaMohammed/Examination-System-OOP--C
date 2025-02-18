using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Answer
    {
        public string ans { get; set; }
        public Answer(string _ans) 
        {
           ans = _ans;
        }
        public Answer() { }
        public override string ToString()
        {
            return ans;
        }
    }
}
