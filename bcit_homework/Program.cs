using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bcit_homework
{
    
        class Program
    {
        //Пример данных
        static List<Employee> empl = new List<Employee>()
            {
                new Employee(1, "Иванов", 1),
                new Employee(2, "Петров", 3),
                new Employee(3, "Сидоров", 4),
                new Employee(4, "Демченко", 5),
                new Employee(6, "Абрамов", 1),
                new Employee(7, "Колков", 7),
                new Employee(8, "Фернандес", 8),
                new Employee(9, "Артеев", 2),
                new Employee(10, "Аистов", 2),
                new Employee(11, "Антонов", 2),
                new Employee(12, "Васин", 7),
                new Employee(13, "Уткин", 8)
            };

        static List<Department> deps = new List<Department>()
            {
                new Department(1, "МейлРу"),
                new Department(2, "ОбществоЛюдейСФамилиейНаА"),
                new Department(3, "Борщ"),
                new Department(4, "Самокат"),
                new Department(5, "БургерКинг"),
                new Department(6, "КФС"),
                new Department(7, "МГТУ"),
                new Department(8, "МВД")
            };

        
        static List<Employee_Dep> lnk = new List<Employee_Dep>()
        {
            new Employee_Dep(1,1),
            new Employee_Dep(1,6),
            new Employee_Dep(2,9),
            new Employee_Dep(2,10),
            new Employee_Dep(2,11),
            new Employee_Dep(3,2),
            new Employee_Dep(4,3),
            new Employee_Dep(5,4),
            new Employee_Dep(7,7),
            new Employee_Dep(7,12),
            new Employee_Dep(8,8),
            new Employee_Dep(8,13)
        };


        static void Main(string[] args)
        {
            Console.WriteLine("\nГрызин А.Н. РТ5-31");
            //Задание 1
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("Список сотрудников, отсортированный по отделам");
            var q1 = from x in empl
                     orderby x.id_department ascending
                     select x;
            foreach (var x in q1) Console.WriteLine(x);

            //Задание 2
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("\nСписок сотрудников с фамилией, начинающейся на 'A'");
            var q2 = from x in empl
                     where (x.name_employee[0].ToString().ToUpper() == "A" || x.name_employee[0].ToString().ToUpper() == "А")
                     select x;
            foreach (var x in q2) Console.WriteLine(x);

            //Задание 3
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("\nСписок всех отделов с количеством сотрудников");
            var q3 = from x in empl.Union(empl)
                     group x by x.id_department into g
                     select new { Key = g.Key, Values = g };

            foreach (var x in q3)
            {
                Department temp_dep = new Department(0,"");
                var f1 = (from y in deps select y).First(y => y.id_department == x.Key);
                temp_dep = f1;
                Console.WriteLine(temp_dep.name_department + " - " + x.Values.Count().ToString() + " сотр.");

            }

            //Задание 4
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("\nСписок всех отделов, у всех сотрудников которых фамилия начинается на 'A'");
            var q4 = from x in q2.Union(q2)
                     group x by x.id_department into g
                     select new { Key = g.Key, Values = g};
            foreach (var x in q4)
            {
                foreach (var y in q3)
                    if (x.Key == y.Key && x.Values.Count() == y.Values.Count())
                    {
                        Department temp_dep = new Department(0, "");
                        var f1 = (from z in deps select z).First(z => z.id_department == y.Key);
                        temp_dep = f1;
                        Console.WriteLine(temp_dep.name_department);
                    }

            }

            //Задание 5
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("\nСписок всех отделов, хотя бы у одного из сотрудников которых фамилия начинается на 'A'");
            foreach (var x in q4)
            {
                foreach (var y in q3)
                    if (x.Key == y.Key)
                    {
                        Department temp_dep = new Department(0, "");
                        var f1 = (from z in deps select z).First(z => z.id_department == y.Key);
                        temp_dep = f1;
                        Console.WriteLine(temp_dep.name_department);
                    }

            }

            //Задание 6
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("\nСписок всех отделов и список сотрудников в каждом отделе");
            var lnk1 = from x in deps
                       join l in lnk on x.id_department equals l.id_department into temp
                       from t1 in temp
                       join y in empl on t1.id_employee equals y.id_employee into temp2
                       from t2 in temp2
                       select new { id1 = x.id_department, id2 = t2.id_employee };
            var q5 = from x in empl.Union(empl)
                     group x by x.id_department into g
                     select new { Key = g.Key, Values = g };

            foreach (var x in q5)
            {
                Department temp_dep = new Department(0, "");
                var f1 = (from y in deps select y).First(y => y.id_department == x.Key);
                temp_dep = f1;
                Console.WriteLine('\n' + temp_dep.name_department + ':');
                foreach (var i in x.Values)
                {
                    Console.WriteLine(i.name_employee);
                }

            }

            //Задание 7
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("\nСписок всех отделов с количеством сотрудников");
            foreach (var x in q5)
            {
                Department temp_dep = new Department(0, "");
                var f1 = (from y in deps select y).First(y => y.id_department == x.Key);
                temp_dep = f1;
                Console.WriteLine(temp_dep.name_department + " - " + x.Values.Count().ToString() + " сотр.");

            }
        }
    }
}
