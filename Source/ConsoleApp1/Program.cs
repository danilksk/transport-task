//блок подключения других пространств
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11 //пространство имен с названием(ConsoleApplication11)
{ //начало пространство имен
    class Program ////основной класс программы
    {
        struct Element //способ создания собственных типов данных
        {

            public int Delivery { get; set; } //устанавливаем свойство, то срабатывает блок Set
            public int Value { get; set; } // получаем значение свойства и присваиваем его переменной, то срабатывает блок Get
            public static int FindMinElement(int a, int b)
            {
                if (a > b) return b; //если a > b, то return завершает выполнение метоа, в котором он находится, и возращает 
                if (a == b) { return a; }
                else return a;
            }

        }

        static void Main(string[] args) //Главный метод программы (точка входа)
        {
            int i = 0;
            int j = 0;
            int n;
            Console.ForegroundColor = ConsoleColor.Green; //задает цвет переднего плана консоли(символы цвет меняют)
            Console.WriteLine("Введите количество производителей [A]"); //выводит в консоль то, что в скобках
            n = Convert.ToInt32(Console.ReadLine()); //преобразует строку, считанную в консоли к типу int (целое число).
            int[] a = new int[n]; //new выделяет объем памяти, необходимый для хранения запрашиваемого массива
            Console.ForegroundColor = ConsoleColor.Green; //задает цвет переднего плана консоли(символы цвет меняют)
            Console.WriteLine("Введите количество потребителей (магазинов) [B]"); //выводит в консоль то, что в скобках
            int m = Convert.ToInt32(Console.ReadLine()); //преобразует строку, считанную в консоли к типу int (целое число)
            int[] b = new int[m]; //new выделяет объем памяти, необходимый для хранения запрашиваемого массива
            Element[,] C = new Element[n, m]; //выделяет объем памяти, для предыдущих значений(n, m)
            Console.ForegroundColor = ConsoleColor.Red;  //задает цвет переднего плана консоли(символы цвет меняют)
            Console.WriteLine("Введите a[i]"); //выводит в консоль то, что в скобках
            for (i = 0; i < a.Length; i++) // использовать свойство Length для инициализации массива a
            {
                // а теперь воспользоваться свойством Length
                // для ввода содержимого в массив a
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите b[i]");
            for (j = 0; j < b.Length; j++) // использовать свойство Length для инициализации массива b
            {
                // и еще раз воспользоваться свойством Length
                // для ввода содержимого в массив b
                b[j] = Convert.ToInt32(Console.ReadLine());
            }
            Console.ForegroundColor = ConsoleColor.White; //задает цвет переднего плана консоли(символы цвет меняют)
            Console.WriteLine("Введите C[i][j]");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++) //двойной цикл для ввода значений
                {
                    Console.Write("a[{0},{1}] = ", i, j); //вывод значений
                    Console.ForegroundColor = ConsoleColor.White; //задает цвет переднего плана консоли(символы цвет меняют)
                    C[i, j].Value = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor(); //устанавливает для текста консоли их значения по умолчанию

                }
            }
            i = j = 0;

            // действуем по алгоритму 
            // идём с северо-западного элемента 
            // если a[i] = 0 i++
            // если b[j] = 0 j++
            //  если a[i],b[j] = 0 то i++,j++;
            // доходим до последнего i , j
            while (i < n && j < m) //выполняет блок операторов, пока определенное логическое выражение равно значению true
            {

                try //будет выплняться, пока не возникнет исключение или ока не будет УСПЕШНО завершен
                {
                    if (a[i] == 0) { i++; } //если a[i] = 0  i++
                    if (b[j] == 0) { j++; }
                    if (a[i] == 0 && b[j] == 0) { i++; j++; }
                    C[i, j].Delivery = Element.FindMinElement(a[i], b[j]); //поиск минимального элемента в массивах
                    a[i] -= C[i, j].Delivery; //сетит первое значение в созданое свойство delivery
                    b[j] -= C[i, j].Delivery; //сетит второе значение в созданое свойство delivery
                }
                catch { } //перехват любого типа исключений, такое использование не рекомендуется\
            }
            //выводим массив на экран
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (C[i, j].Delivery != 0) //если C[i, j].Delivery не 0, то выполняется след блок кода. Если нет, то блок else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue; //задает цвет переднего плана консоли(символы цвет меняют)
                        Console.Write("{0}", C[i, j].Value); //получает значения из C[i, j].Value и выводит\
                        Console.ForegroundColor = ConsoleColor.Red; //задает цвет переднего плана консоли(символы цвет меняют)
                        Console.Write("({0})", C[i, j].Delivery); Console.ResetColor(); //получает значения из C[i, j].Delivery и выводит\
                    }
                    else
                        Console.Write("{0}({1})", C[i, j].Value, C[i, j].Delivery); 
                }
                Console.WriteLine();
            }
            int ResultFunction = 0;
            //считаем целевую функцию
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++) { ResultFunction += (C[i, j].Value * C[i, j].Delivery); }
            }

            Console.WriteLine("Результат (Целевая функция) = {0}", ResultFunction);
            i = 0;
            j = 0;
            int[] u = new int[n];
            int[] v = new int[m];




            Console.ReadLine();
        }
    }
} //Конец пространства имен