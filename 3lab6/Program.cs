using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _3lab6
{
    //Делегат сравнения
    delegate string Comparing(double x, double y);

    partial class Program
    {
        //1-я часть

        //Методы соответстующие делегату
        static string Bigger(double x, double y)
        {
            if (x > y) return $"{x} больше, чем {y}";
            else if (y > x) return $"{y} больше, чем {x}";
            else  return $"{x} и {y} равны";
        }
        static string Lower(double x, double y)
        {
            if (x < y) return $"{x} меньше, чем {y}";
            else if (y < x) return $"{y} меньше, чем {x}";
            else return $"{x} и {y} равны";
        }
        
        //Метод с делегатным параметром
        static void ComparingMethod(double x, double y, Comparing parameter)
        {
            string result = parameter(x, y);
            Console.WriteLine(result);
        }
        //Метод с обобщенным делегатом
        static void ComparingMethodFunc(double x, double y, Func<double, double, string> parameter)
        {
            string result = parameter(x, y);
            Console.WriteLine(result);
        }

        //2-я часть

        // Проверка, что у свойства есть атрибут заданного типа
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;

            //Поиск атрибутов с заданным типом
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }

            return Result;
        }

        // Получение информации о текущей сборке

        static void AssemblyInfo()
        {
            Console.WriteLine("Вывод информации о сборке:");
            Assembly i = Assembly.GetExecutingAssembly();
            Console.WriteLine("Полное имя:" + i.FullName);
            Console.WriteLine("Исполняемый файл:" + i.Location);
        }

        // Получение информации о типе
        static void TypeInfo()
        {
            Car obj = new Car();
            Type t = obj.GetType();

            //другой способ
            //Type t = typeof(Car);

            Console.WriteLine("\nИнформация о типе:");
            Console.WriteLine("Тип " + t.FullName + " унаследован от " + t.BaseType.FullName);
            Console.WriteLine("Пространство имен " + t.Namespace);
            Console.WriteLine("Находится в сборке " + t.AssemblyQualifiedName);

            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nПоля данных (public):");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nCar реализует IComparable -> " +
            t.GetInterfaces().Contains(typeof(IComparable))
            );
        }

        // Пример использования метода InvokeMember
        static void InvokeMemberInfo()
        {
            Type t = typeof(Car);
            Console.WriteLine("\nВызов метода:");
            Car fi = (Car)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });

            //Параметры вызова метода
            object[] parameters = new object[] {40, 500};
            //Вызов метода
            object Result = t.InvokeMember("GetFuelConsumption", BindingFlags.InvokeMethod, null, fi, parameters);
            Console.WriteLine("GetFuelConsumption(40,500) - {0}", Result);
        }
        /// Работа с атрибутами
        static void AttributeInfo()
        {
            Type t = typeof(Car);
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(NewAttribute), out attrObj))
                {
                    NewAttribute attr = attrObj as NewAttribute;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
        }
        static void Main(string[] args)
        {
            double x, y;
            Console.WriteLine("Введите Х");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите Y");
            y = Convert.ToDouble(Console.ReadLine());
            ComparingMethod(x, y, Bigger);
            ComparingMethod(x, y, Lower);
            //Лямбда-выражение
            Comparing biggerlambda = (double x, double y) =>
            {
                if (x > y) return $"{x} больше, чем {y}";
                else if (y > x) return $"{y} больше, чем {x}";
                else return $"{x} и {y} равны";
            };
            ComparingMethod(x, y, biggerlambda);
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
            //Обобщенные делегаты
            ComparingMethodFunc(x, y, Lower);
            Console.WriteLine("----------------------------------------------------------");
            AssemblyInfo();
            TypeInfo();
            InvokeMemberInfo();
            AttributeInfo();

        }
    }
}
