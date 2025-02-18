using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Demo
{
    internal class QuestionList :List<Question>
    {
        
        public QuestionList() {
           
        }  
        public new void Add(Question question, string File)
        {
            base.Add(question);
            if (File == null)
            {
                Console.WriteLine("File path not allowed.");
            }
            using (StreamWriter writer = new StreamWriter(File, append: true))
            {
                writer.WriteLine(question);
                writer.WriteLine($"Answer: {String.Join(",", question.CorrectAnswer)}");
            }
        }
    }
}
