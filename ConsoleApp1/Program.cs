namespace ConsoleApp1
{
    internal class Program
    {
        private struct Person
        {
            public string FirstName;
            public string LastName;
            public DateTime BirthDay;

            public Person(string firstName, string lastName, DateTime birthDay)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.BirthDay = birthDay;
            }

            public override string ToString()
            {
                return string.Format("Имя: {0}; Фамилия: {1}; Дата рождения: {2:d}.", FirstName, LastName, BirthDay);
            }

            public static string GetTypeName() { return "Человек"; }
        }

        private delegate string GetAsString();

        static void Main(string[] args)
        {
            DateTime birthDay = new DateTime(1978, 2, 15);
            Person person = new Person("Иван", "Петров", birthDay);

            // System.DateTime object.
            // public string ToLongDateString();

            GetAsString getStringMethod = new GetAsString(birthDay.ToLongDateString);

            Console.WriteLine(getStringMethod.Invoke());

            getStringMethod = person.ToString;
            Console.WriteLine(getStringMethod());

            getStringMethod = Person.GetTypeName;
            Console.WriteLine(getStringMethod());
        }
    }
}
