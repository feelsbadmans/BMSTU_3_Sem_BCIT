using System;

namespace _3lab3
{
    //Класс "Прямоугольник"
    class Rectangle : Figure, IPrint
    {
        private double length;
        private double height;

        public Rectangle(double length, double height)
        {
            figure_type = "Прямоугольник";
            this.length = length;
            this.height = height;
        }
        public override double Area()
        {
            return length * height;
        }

        public override string ToString()
        {
            return ($"Тип фигуры: {figure_type}; Длина = {length}; Высота = {height}; Площадь = {this.Area()}");
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
