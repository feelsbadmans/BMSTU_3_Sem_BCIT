using System;

namespace _3lab2
{
    //Абстрактный класс "Геометрическая фигура"
    abstract class Figure
    {
        public string figure_type;
        public abstract double Area();
    }
    
    //Интерфейс "IPrint"
    public interface IPrint
    {
        public void Print();
    }

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
            return ($"\nТип фигуры: {figure_type}\nДлина = {length}\nВысота = {height}\nПлощадь = {this.Area()}\n");
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    //Класс "Квадрат"
    class Square : Rectangle
    {
        private double length;
        public Square(double length) : base(length, length) 
        {
            figure_type = "Квадрат";
            this.length = length;
        }

        public override string ToString()
        {
            return ($"\nТип фигуры: {figure_type}\nДлина стороны = {length}\nПлощадь = {this.Area()}\n");
        }

    }

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
            return ($"\nТип фигуры: {figure_type}\nРадиус = {radius}\nПлощадь = {this.Area()}\n");
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выполнил: Грызин А.Н. РТ5-31");
            Rectangle rctngl = new Rectangle(3.5, 2);
            Square sqr = new Square(7);
            Circle crcl = new Circle(25);
            rctngl.Print();
            sqr.Print();
            crcl.Print();
        }
    }
}
