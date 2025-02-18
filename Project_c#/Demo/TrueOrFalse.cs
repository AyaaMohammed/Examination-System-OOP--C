using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class TrueOrFalse:Question,ICloneable,IComparable<TrueOrFalse>
    {
        public TrueOrFalse(int _num, string _header, string _body, float _marks, List<string> _choose, AnswerList _list) :
            base(_num, _header, _body, _marks, _choose, _list)
        {

        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            TrueOrFalse q = obj as TrueOrFalse;
            if (q == null) return false;
            return Body == q.Body && Header == q.Header && CorrectAnswer == q.CorrectAnswer && list == q.list;
        }
        public int CompareTo(TrueOrFalse? other)
        {
            return this.Body.CompareTo(other.Body);
        }
        public object Clone()
        {
            return new TrueOrFalse(Number, Header, Body, Marks, CorrectAnswer, list);
        }
        public override string ToString()
        {
            return $"{Header} : (Degree: {Marks} Points)\n{Number} - {Body}\nA- True \nB- False ";
        }
    }
}
