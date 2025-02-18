﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demo
{
    internal class ChooseOne:Question,ICloneable,IComparable<ChooseOne>
    {
        public ChooseOne(int _num, string _header, string _body, float _marks, List<string> _choose, AnswerList _list) : 
            base(_num, _header, _body, _marks,_choose,_list)
        {

        }

        public override string ToString()
        {
            return $"{Header}. (Degree: {Marks} Points)\n{Number} - {Body}\n{string.Join('\n',
                list.Select((answer,index)=>$"{Convert.ToChar('A' + index)}- {answer}"))}";
        }
        public override bool Equals(object? obj)
        {   
            if(obj == null) return false;   
            ChooseOne q = obj as ChooseOne;
            if(q == null) return false;
            return Body == q.Body && Header == q.Header && CorrectAnswer == q.CorrectAnswer && list == q.list;
        }
        public int CompareTo(ChooseOne? other)
        {
            return this.Body.CompareTo(other.Body);
        }
        public object Clone()
        {
            return new ChooseOne(Number, Header, Body, Marks, CorrectAnswer, list);
        }


    }
}
