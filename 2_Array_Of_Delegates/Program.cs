using System;

namespace _2_Array_Of_Delegates
{
    delegate int MyDelegate(int a, int b, int c);
    internal class Program
    {
        public static int Max(int a, int b, int c)
        {
            Console.WriteLine("Максимум из трёх чисел:");
            return Math.Max(Math.Max(a, b), c);
        }
        public static int Min(int a, int b, int c)
        {
            Console.WriteLine("Минимум из трёх чисел:");
            return Math.Min(Math.Min(a, b), c);
        }
        public static int Sum(int a, int b, int c)
        {
            Console.WriteLine("Сумма трёх чисел:");
            return a + b + c;
        }
        public static int Mult(int a, int b, int c)
        {
            Console.WriteLine("Произведение трёх чисел:");
            return a * b * c;
        }
        static void Main(string[] args)
        {
            // MyDelegate[] dg = new MyDelegate[4] { new MyDelegate(Max), new MyDelegate(Min), new MyDelegate(Sum), new MyDelegate(Mult) };
            // MyDelegate[] dg = new MyDelegate[4] {Max, Min, Sum, Mult};
            MyDelegate[] dg = { Max, Min, Sum, Mult };
            int choice = 0;
            while (choice != 5)
            {
                Console.Write("\n1 Max\n2 Min \n3 Sum\n4 Mult\n5 Exit\nYour choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice >= 1 && choice <= 4)
                {
                    Console.WriteLine("Введите три числа: ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    int b = Convert.ToInt32(Console.ReadLine());
                    int c = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(dg[choice - 1](a, b, c));
                }
            }
        }
    }
}