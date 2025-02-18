using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    abstract class Question
    {

        public List<string> CorrectAnswer { get; set; }

        public AnswerList list;
        public int Number { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public float Marks { get; set; }        
        public Question(int _num , string _header , string _body , float _marks, List<string> _CorrectAnswer, AnswerList _list)
        {
            Number = _num ;
            Header = _header ;
            Body = _body ;
            Marks = _marks;
            CorrectAnswer = _CorrectAnswer ;
            list = _list ;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Question)) return false;
            Question question = (Question)obj;

            return base.Equals(obj);
        }
        public override string ToString()
        {
            return $"{Number} - {Header} : {Marks}\n{Body}";
        }


    }
}
