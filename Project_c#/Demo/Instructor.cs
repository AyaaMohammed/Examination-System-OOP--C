using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    
    internal class Instructor:Login
    {
        
        public string Name { get; set; }
        public int Id { get; set; }
        public long Password { get; set; }
        public Subject Subject { get; set; }
        public Exam exam { get; set; }        
        public List<Student> Students { get; set; } = new List<Student>();
        
        public event Action<Instructor, Exam ,Student> NotifyExam;


        public Dictionary<Student,double> dict { get; set; }= new Dictionary<Student,double>();
        public void NotifyExamMode(Student std)
        {
            if (exam.mode == StartingMode.Starting && std.StartingMode == StartingMode.Starting)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Exam for subject: {Subject.NameSubject} at {exam.Time} in mode: {exam.mode}\n");
                Console.ResetColor();
                NotifyExam?.Invoke(this, exam, std);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The exam is not allowed at this time.");
                Console.ResetColor();
            }
        }


        public void AddStudentToExam(Student student)
        {
            Students.Add(student);
        }
        public void ListOfDegreeOfStudent()
        {
            if (dict.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No student grades available.");
                Console.ResetColor();
                return;
            }

            foreach (KeyValuePair<Student, double> student in dict)
            {
                if (student.Value * 100 >= 50)
                    Console.ForegroundColor = ConsoleColor.Green; 
                else
                    Console.ForegroundColor = ConsoleColor.Red; 

                Console.WriteLine($"{student.Key} - Grade: {student.Value * 100:F2}%");             
                               
            }
            Console.ResetColor();
        }

        public Instructor(int _id,string _name,long _password , Subject subject) 
        {
            Id = _id;
            Name = _name;
            Password = _password;
            Subject = subject;
        }
        public QuestionList AddQuestionsFile(List<Question> questions,string File)
        {
            QuestionList list = new QuestionList();
            foreach (Question question in questions)
            {             
                  list.Add(question,File);              
            }
            Console.WriteLine("You have successfully added all questions to the file.");
            return list;
        }
        public override string ToString()
        {
            return $"instructor {Name} : {Id} : {Subject}";
        }


    }
}
