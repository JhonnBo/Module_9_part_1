namespace _7_Event_Accessors
{
    delegate void MyDelegate();
    class SourceEvent
    {
        //List<MyDelegate> list = new List<MyDelegate>();

        MyDelegate? mdel;

        // Для управления списком обработчиков событий служит 
        // расширенная форма оператора event, позволяющая использовать аксессоры событий. 
        // Эти аксессоры предоставляют средства для управления реализацией подобного списка. 
        // Элементы управления WPF используют этот подход для добавления функциональности 
        // "пузырькового" и туннельного распространения событий.

        public event MyDelegate ev
        {
            // Используем аксессоры событий
            add
            {
                mdel += value;
            }

            remove
            {
                mdel -= value;
            }
        }
        public void GeneratorEvent()
        {
            Console.WriteLine("Произошло событие!!!!");
            mdel?.Invoke();
        }
    }

    class ObserverEventA
    {
        public void see()
        {
            Console.WriteLine("ObserverEventA. Событие обработано! ");
        }
    }

    class ObserverEventB
    {
        public void see()
        {
            Console.WriteLine("ObserverEventB. Событие обработано!");
        }
    }

    class MainClass
    {
        static void Main()
        {
            SourceEvent s = new SourceEvent(); // объект класса-источника события
            ObserverEventA obj1 = new ObserverEventA(); // объект класса наблюдателя
            ObserverEventA obj2 = new ObserverEventA(); // объект класса наблюдателя
            ObserverEventB obj3 = new ObserverEventB(); // объект класса наблюдателя
            ObserverEventB obj4 = new ObserverEventB(); // объект класса наблюдателя

            // добавление обработчиков к событию
            s.ev += new MyDelegate(obj1.see);
            s.ev += new MyDelegate(obj2.see);
            s.ev += new MyDelegate(obj3.see);
            s.ev += new MyDelegate(obj4.see);

            s.GeneratorEvent(); // инициирование события

            s.ev -= obj3.see;
            s.ev -= obj4.see;

            s.GeneratorEvent(); // инициирование события
        }
    }
}