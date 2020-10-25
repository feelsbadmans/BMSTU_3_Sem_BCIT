using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _3lab3
{
    //Абстрактный класс "Геометрическая фигура"
    abstract class Figure : IComparable
    {
        string Type;
        public string figure_type
        {
            get
            {
                return this.Type;
            }
            protected set
            {
                this.Type = value;
            }
        }
        public abstract double Area();
        
        public int CompareTo(object obj)
        {
            //Приведение параметра к типу "фигура"
            Figure p = (Figure)obj;
            //Сравнение
            if (this.Area() < p.Area()) return -1;
            else if (this.Area() == p.Area()) return 0;
            else return 1; //(this.Area() > p.Area())

        }
    }
}
