using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class PracticeExam:Exam,ICloneable
    {

        public PracticeExam(DateTime _time, int _numberquestion, StartingMode _mode) :
            base(_time, _numberquestion, _mode)
        {
            TotalDegree = 0;
        }
        public object Clone()
        {
            return new FinalExam(Time, NumberQuestions, mode);
        }
        public void ShowExam()
        {
            Console.WriteLine("\n>>The exam contains different types of questions, and the answers will depend on the question type. Let's start solving!\n");
            foreach (var answer in CorrectAnswer)
            {
                Console.WriteLine(answer.Key);
                Console.Write("Enter Answer : ");
                string Ans = Console.ReadLine().Trim();
                List<string> str = Ans.Split(',').Select(a => a.Trim()).ToList();
                foreach (var item in str)
                {
                    answer.Value.Add(new Answer(item));
                }
                answer.Key.CorrectAnswer.Sort();
                str.Sort();
                
                if (CompareTwoList(answer.Key.CorrectAnswer, str))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your answer is correct: {string.Join(", ", str)}");
                    Console.ResetColor();
                    TotalDegree += answer.Key.Marks;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Your answer is wrong: {string.Join(", ", str)}. Correct answer: {string.Join(", ", answer.Key.CorrectAnswer)}");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("\nThank you for using the Examination System!");
            Thread.Sleep(2000);
        }
        

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
