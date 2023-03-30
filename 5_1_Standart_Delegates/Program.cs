namespace _5_1_Standart_Delegates
{
    internal class Program
    {
        static Func<int, int, string>? func; //Func возвращает результат действия и может принимать параметры.
                                             //Он также имеет различные формы: от Func<out T>(), где T - тип возвращаемого значения,
                                             //до Func<in T1, in T2,...in T16, out TResult>(), то есть может принимать до 16 параметров.

        static Action<int, int>? act; // Делегат Action представляет некоторое действие, которое ничего не возвращает,
                                      // то есть в качестве возвращаемого типа имеет тип void.
                                      // Данный делегат имеет ряд перегруженных версий.
                                      // Каждая версия принимает разное число параметров:
                                      // от Action<in T1> до Action<in T1, in T2,....in T16>. Таким образом можно передать до 16 значений в метод.

        static Predicate<int>? predicate; // Делегат Predicate<T> принимает один параметр и возвращает значение типа bool:

        static void Main(string[] args)
        {
            Console.WriteLine("------------Func Delegate------------");
            func = AB;
            Console.WriteLine("Cцепление цифр: " + func(3, 5));

            Console.WriteLine("------------Action Delegate------------");
            act = Stepin;
            act(3, 4);
            DoAct(4, 6, Stepin);
            DoAct(5, 2, act);

            Console.WriteLine("------------Predicate Delegate------------");
            predicate = IsEven;
            Console.WriteLine("Число является четным? Ответ: " + predicate(4));
        }

        static void DoAct(int a, int b, Action<int, int> act) // либо можно создать функцию, принимающую в кач. параметра делегат Экшин (3 параметр)
        {
            act(a, b);
        }

        static string AB(int a, int b)
        {
            return ($"{a}{b}");
        }

        static void Stepin(int ch, int step)
        {
            Console.WriteLine($"Степень числа {Math.Pow(ch, step)}");
        }

        static bool IsEven(int a)
        {
            return (a % 2 == 0);
        }

    }
}