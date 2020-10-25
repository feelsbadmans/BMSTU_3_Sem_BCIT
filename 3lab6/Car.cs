using System;

namespace _3lab6
{

    partial class Program
    {
        public class Car : IComparable
        {
            public Car() { }
            public Car(string Name) { this.Name = Name; }
            public double GetFuelConsumption(double liters, double kilometers)
            {
                return liters / kilometers * 100;
            }
            public string Name 
            {
                get { return Name; }
                set { Name = value; }
            }
            [NewAttribute("Цена")]
            public double Cost
            {
                get { return Cost; }
                set { Cost = value; }
            }

            [NewAttribute("Тип кузова")]
            public string Body
            {
                get { return Body; }
                set { Body = value; }
            }
            [NewAttribute("Год выпуска")]
            public int Date
            {
                get { return Date; }
                set { Date = value; }
            }
            public void GetInfo()
            {
                Console.WriteLine("Название: {0}\nДата выпуска: {1}\n Кузов: {2}\nЦена: {3} рублей",
                    this.Name == null ? "-" : this.Name,
                    this.Date == null ? 0 : this.Date,
                    this.Cost == null ? 0 : this.Cost,
                    this.Body == null ? "-" : this.Body);
            }
            public int CompareTo(object obj)
            {
                return 0;
            }

        }
    }
}
