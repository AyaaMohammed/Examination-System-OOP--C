using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo

{
    enum StartingMode  { Starting=1, Queued, Finished };
     internal class Exam : EventArgs
    {
      
        public DateTime Time
        {
            get;
            set;
        }
        public int NumberQuestions { get; set; }
        public StartingMode mode;
        public Dictionary<Question, AnswerList> CorrectAnswer { get; set; } = new Dictionary<Question, AnswerList>();
        int count = 0;
        public double TotalDegree;
        public Exam(DateTime _time, int _numberquestion, StartingMode _mode)
        {
            Time = _time;
            NumberQuestions = _numberquestion;
            mode = _mode;
        }

        
        public void AddToDict(string File)
        {
            List<Question> list = new List<Question>();
            list = Read(File);
            foreach (var item in list)
            {                
                if (NumberQuestions > count)
                {
                    if (CorrectAnswer.ContainsKey(item))
                    {
                        Console.WriteLine("Question is already exist in the dict.");
                    }
                    else
                    {
                        CorrectAnswer.Add(item, new AnswerList());
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("The maximum number of questions is added.");
                    break;
                }
            }           
        }

        protected bool CompareTwoList(List<string> l1, List<string> l2)
        {
            if (l1 == null || l2 == null) return false;
            if (l1.Count != l2.Count) return false;
            for (int i = 0; i < l1.Count; i++)
            {
                if (l1[i].ToUpper() != l2[i].ToUpper()) return false;
            }
            return true;
        }
        private bool OneLine(string text)
        {
            return !text.Contains("\n") && !text.Contains("\r");
        }
 
        private  void AddAnswer(TextReader reader, ref List<string> correctAnswers, ref AnswerList ansList)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("Answer:"))
                {
                    string answer = line.Substring(7).Trim();
                    
                    if (answer.Contains(","))
                    {
                        correctAnswers.AddRange(answer.Split(',').Select(a => a.Trim()));

                    }
                    else
                    {
                        correctAnswers.Add(answer);

                    }
                    break; 
                }
                var matches = Regex.Matches(line, @"[A-D]-\s(.*)");
                foreach (Match match in matches)
                {                  
                    ansList.Add(new Answer(match.Groups[1].Value.Trim()));


                }
            }
        }
        private  List<Question> Read(string File)
        {
            List<Question> list = new List<Question>();
            string body = "";
            int num = 0;
            string questionType = "";
            using (TextReader reader = new StreamReader(File))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Select True or False") || line.StartsWith("Select One Option Only") || line.StartsWith("Choose any applicable choices"))
                    {
                        questionType = line;
                        List<string> CorrectAnswer = new List<string>(); 
                        AnswerList Anslist = new AnswerList(); 
                        line = reader.ReadLine();
                        if (line != null && !string.IsNullOrWhiteSpace(line) && char.IsDigit(line[0]) && OneLine(line))
                        {
                            num = line[0] - '0';                            
                            body = Regex.Replace(line, @"^\d+\s*-\s*", "").Trim();
                            AddAnswer(reader, ref CorrectAnswer, ref Anslist);
         
                            if (questionType.StartsWith("Select True or False"))
                            {
                                TrueOrFalse q = new TrueOrFalse(num, "Select True or False", body, 1, CorrectAnswer, Anslist);
                                list.Add(q);
                                
                            }
                            else if (questionType.StartsWith("Select One Option Only"))
                            {
                                ChooseOne q = new ChooseOne(num, "Select One Option Only", body, 1, CorrectAnswer, Anslist);
                                list.Add(q);
                               
                            }
                            else if (questionType.StartsWith("Choose any applicable choices"))
                            {
                                ChooseAll q = new ChooseAll(num, "Choose any applicable choices", body, 1, CorrectAnswer, Anslist);
                                list.Add(q);
                               
                            }
                        }                       
                    }
                }
            }
            return list;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
