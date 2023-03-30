using System;

namespace _4_MultyCastDelegate
{
    delegate void MyDelegate(int a, int b, int c);
    internal class Program
    {
        public static void Max(int a, int b, int c)
        {
            Console.WriteLine("Максимум из трёх чисел:" + Math.Max(Math.Max(a, b), c));
        }
        public static void Min(int a, int b, int c)
        {
            Console.WriteLine("Минимум из трёх чисел:" + Math.Min(Math.Min(a, b), c));
        }
        public static void Sum(int a, int b, int c)
        {
            Console.WriteLine("Сумма трёх чисел:" + (a + b + c));
        }
        public static void Mult(int a, int b, int c)
        {
            Console.WriteLine("Произведение трёх чисел:" + a * b * c);
        }
        static void Main(string[] args)
        {
            MyDelegate? dg = new MyDelegate(Max);
            dg += Min;
            dg += Sum;
            dg += Mult;
            Console.WriteLine("Введите три числа: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());

            dg(a, b, c); // запуск на выполнение сразу всех 3-х методов

            foreach (MyDelegate item in dg.GetInvocationList())
            {
                Console.WriteLine("Это имя метода делегата {0}", item.Method.Name);
            }
            dg -= Max;
            dg -= Min;
            //dg -= Sum;
            //dg -= Mult;
            Console.WriteLine("----------------------------------------------------");

            dg?.Invoke(a, b, c); //Запуск делегата с двумя методами
            foreach (MyDelegate item in dg.GetInvocationList())
            {
                Console.WriteLine("Это оставшиеся методы в делегате {0}", item.Method.Name);
            }
            dg = Min;
            Console.WriteLine("---------------------------------------------------");

            dg(a, b, c);

            foreach (MyDelegate item in dg.GetInvocationList())
            {
                Console.WriteLine("Это единственный метод делегата {0}", item.Method.Name);
            }
        }
    }
}