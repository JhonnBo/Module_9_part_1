namespace _5_Callback_Mechanism
{
    internal class Program1
    {
        class Account
        {
            int _sum; // Переменная для хранения суммы
            int _percentage; // Переменная для хранения процента

            public Account(int sum, int percentage)
            {
                _sum = sum;
                _percentage = percentage;
            }

            public int CurrentSum
            {
                get { return _sum; }
            }

            public void Put(int sum)
            {
                _sum += sum;
            }

            public void Withdraw(int sum)
            {
                if (sum <= _sum)
                {
                    _sum -= sum;

                    del?.Invoke("Сумма " + sum.ToString() + " снята со счета");
                }
                else
                {
                    del?.Invoke("Недостаточно денег на счете");
                }
            }

            public int Percentage
            {
                get { return _percentage; }
            }

            // Объявляем делегат
            public delegate void AccountStateHandler(string message);
            // Создаем переменную делегата
            internal AccountStateHandler del;

            /*
             * Когда компилятор C# обрабатывает тип делегата, 
             * он автоматически генерирует запечатанный (sealed) класс, 
             * унаследованный от System.MulticastDelegate. 
             * Этот класс (в сочетании с его базовым классом System.Delegate) 
             * предоставляет необходимую инфраструктуру для делегата, 
             * чтобы хранить список методов, подлежащих вызову.
             */
            // Регистрируем делегат
            public void RegisterHandler(AccountStateHandler _del)
            {
                // метод Combine объединяет делегаты _del и del в один, 
                // который потом присваивается переменной del
                //System.Delegate mainDel = System.Delegate.Combine(del, _del);
                //del = mainDel as AccountStateHandler;

                //сокращенная форма добавления
                del += _del; // добавляем делегат
            }

            // Отмена регистрации делегата
            public void UnregisterHandler(AccountStateHandler _del)
            {
                // метод Remove возвращает делегат, из списка вызовов которого удален делегат _del
                //System.Delegate mainDel = System.Delegate.Remove(del, _del);
                //del = mainDel as AccountStateHandler;

                // сокращенная форма удаления 
                del -= _del; // добавляем делегат
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Account account = new Account(200, 6);
                Account.AccountStateHandler colorDelegate = new Account.AccountStateHandler(Color_Message);
                // Добавляем в делегат ссылку на методы
                account.RegisterHandler(new Account.AccountStateHandler(Show_Message));
                account.RegisterHandler(colorDelegate);
                //account.del += colorDelegate;
                foreach (Account.AccountStateHandler item in account.del.GetInvocationList())
                {
                    Console.WriteLine("{0}", item.Method.Name);
                }
                // Два раза подряд пытаемся снять деньги
                account.Withdraw(100);
                account.Withdraw(150);

                // Удаляем делегат
                account.UnregisterHandler(colorDelegate);
                foreach (Account.AccountStateHandler item in account.del.GetInvocationList())
                {
                    Console.WriteLine("{0}", item.Method.Name);
                }
                account.Withdraw(50);
            }

            /*
             * Так как у нас консольное приложение, мы можем через делегат выводить сообщение на консоль. 
             * Если мы создаем графическое приложение Windows Forms или WPF, то можно выводить сообщение 
             * в виде графического окна. Другой вариант, например, при снятии денег записать информацию об этом 
             * действии в файл или отправить уведомление на электронную почту
             */
            private static void Show_Message(string message)
            {
                Console.WriteLine(message);
            }
            private static void Color_Message(string message)
            {
                // Устанавливаем красный цвет символов
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                // Сбрасываем настройки цвета
                Console.ResetColor();
            }
        }
    }
}