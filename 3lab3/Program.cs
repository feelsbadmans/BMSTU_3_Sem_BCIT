using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;


namespace _3lab3
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //Array
            Console.WriteLine("Выполнил: Грызин А.Н. РТ5-31");
            Console.WriteLine("------------------------------------------------------------------\n");
            Rectangle rctngl = new Rectangle(3.5, 2);
            Square sqr = new Square(7);
            Circle crcl = new Circle(5);
            ArrayList array_l = new ArrayList();
            array_l.Add(rctngl);
            array_l.Add(sqr);
            array_l.Add(crcl);
            array_l.Sort();
            foreach(Figure element in array_l)
            {
                Console.WriteLine(element);
            }
            //List
            Console.WriteLine("------------------------------------------------------------------");
            Rectangle rctngl_1 = new Rectangle(323, 123);
            Square sqr_1 = new Square(41);
            Circle crcl_1 = new Circle(47);
            List<Figure> list_f = new List<Figure>();
            list_f.Add(rctngl_1);
            list_f.Add(sqr_1);
            list_f.Add(crcl_1);
            list_f.Sort();
            foreach (Figure element in list_f)
            {
                Console.WriteLine(element);
            }
            //Matrix
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("\nМатрица");
            Matrix<Figure> matrix = new Matrix<Figure>(3, 3, 3, new FigureMatrixCheckEmpty());
            matrix[0, 0, 0] = rctngl_1;
            matrix[1, 1, 1] = sqr_1;
            matrix[2, 2, 2] = crcl_1;
            Console.WriteLine(matrix.ToString());
            //Stack
            Console.WriteLine("------------------------------------------------------------------\nСтек\n");
            SimpleStack<Figure> stack = new SimpleStack<Figure>();
            stack.Push(rctngl);
            stack.Push(rctngl_1);
            Console.WriteLine(stack.Pop().ToString());
            stack.Push(sqr_1);
            stack.Push(crcl);
            Console.WriteLine(stack.Pop().ToString());
            Console.WriteLine(stack.Pop().ToString());
            Console.WriteLine(stack.Pop().ToString());
            Console.WriteLine("Элементов в стеке: {0}", stack.Count);
        }
    }
}
