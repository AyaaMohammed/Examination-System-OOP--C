using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Student:Login
    {
        public int Id { get; set; }
        public long Password { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }

        public StartingMode StartingMode { get; set; }
        public Student(int _id , string _name ,int _password,Subject _subject) 
        {
            Id = _id;
            Password = _password;
            Name = _name;
            Subject = _subject;
            StartingMode = StartingMode.Starting;
        }
        public void NotifyStudent(Instructor s ,Exam exam , Student std)
        {
            int num = 0;
           
            if (Subject.NameSubject == s.Subject.NameSubject && std.Id == this.Id && std.Password == this.Password)
            {
                Console.WriteLine($"{Name} notify for the exam {s.Subject.NameSubject}.\n");
                Console.Write("Select exam type - Practical (1) or Final (2): ");
                if (int.TryParse(Console.ReadLine(),out num))
                {
                    switch (num)
                    {
                        case 1:
                            PracticeExam p = new PracticeExam(exam.Time, exam.NumberQuestions, exam.mode);
                            p.CorrectAnswer = exam.CorrectAnswer;
                            p.ShowExam();
                            std.StartingMode = StartingMode.Finished;                                                  
                            break;
                        case 2:
                            FinalExam f = new FinalExam(exam.Time, exam.NumberQuestions, exam.mode);
                            f.CorrectAnswer = exam.CorrectAnswer;
                            f.NumberQuestions = exam.NumberQuestions;
                            f.ShowExam();                            
                            s.dict[this] = (double)(f.TotalDegree / f.NumberQuestions);
                            std.StartingMode = StartingMode.Finished;
                            break;
                        default:
                            Console.WriteLine("Invalid choice , try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid type , try again.");
                }


            }
           
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Subject.ToString()}";
        }
    }
}
