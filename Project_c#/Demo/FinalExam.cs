using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class FinalExam:Exam,ICloneable
    {

        public FinalExam(DateTime _time, int _numberquestion, StartingMode _mode) :
            base(_time, _numberquestion, _mode)
        {
            TotalDegree = 0;
        }

        public object Clone()
        {
            return new FinalExam(Time,NumberQuestions,mode);
        }
        public void ShowExam()
        {
            Console.Clear();
            Console.WriteLine(">> The exam contains different types of questions, and the answers will depend on the question type. Let's start solving!\n");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var timerTask = Task.Run(() => StartTimer(30, cancellationTokenSource.Token));

            foreach (var answer in CorrectAnswer)
            {
                if (examFinished) break;               
                Console.WriteLine(answer.Key);
                Console.Write("Enter Answer: ");               
                string Ans = ReadLineWithTimeout();
                if (Ans == null)
                {
                    examFinished = true;
                    cancellationTokenSource.Cancel();
                    break;
                }
                
                List<string> str = Ans.Split(',').Select(a => a.Trim()).ToList();
                foreach (var item in str)
                {
                    answer.Value.Add(new Answer(item));
                }
                answer.Key.CorrectAnswer.Sort();
                str.Sort();

                
                if (CompareTwoList(answer.Key.CorrectAnswer, str))
                {
                    TotalDegree += answer.Key.Marks;
                }
            }

            
            if (!examFinished)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nExam finished by user.");
                cancellationTokenSource.Cancel();
                Console.ResetColor();
            }

           
            printExam();
        }

        private bool examFinished = false;

        private string ReadLineWithTimeout()
        {
            var task = Task.Run(() => Console.ReadLine());
            while (!task.IsCompleted)
            {
                if (examFinished)
                {
                    return null; 
                }
                Thread.Sleep(100);
            }
            return task.Result;
        }

        private void StartTimer(int duration, CancellationToken cancellationToken)
        {
            int timeLeft = duration;
            while (timeLeft > 0 && !examFinished)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return; 
                }

                Thread.Sleep(1000); 
                timeLeft--;
            }

            
            if (timeLeft == 0 && !examFinished)
            {
                examFinished = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nTime's up! Exam finished.");
                Console.ResetColor();
            }
        }


        public void printExam()
        {
            Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine("************************************************************************************************");
            Console.WriteLine("You have finished the exam. Your answers are submitted but not yet evaluated for correctness....");
            Console.WriteLine("************************************************************************************************\n");
            double percentage = ((double)TotalDegree / NumberQuestions) * 100;

            if (percentage >= 50)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully passed the exam!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You did not pass the exam.");
            }
            Console.ResetColor();

            Console.WriteLine($"\nTotal degrees: {TotalDegree}/ {NumberQuestions}");
            Console.WriteLine($"Percentage: {percentage:f2}%");
            Console.WriteLine("\nThank you for using the Examination System!");
            Thread.Sleep(7000);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
