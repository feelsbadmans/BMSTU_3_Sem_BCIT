using System;

namespace _3lab3
{
    //Класс "Круг"
    class Circle : Figure, IPrint
    {
        private double radius;

        public Circle(double radius)
        {
            figure_type = "Круг";
            this.radius = radius;
        }
        public override double Area()
        {
            return 3.14 * radius * radius;
        }

        public override string ToString()
        {
            return ($"Тип фигуры: {figure_type}; Радиус = {radius}; Площадь = {this.Area()}");
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
