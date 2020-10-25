namespace _3lab3
{
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
            return ($"Тип фигуры: {figure_type}; Длина стороны = {length}; Площадь = {this.Area()}");
        }

    }
}
