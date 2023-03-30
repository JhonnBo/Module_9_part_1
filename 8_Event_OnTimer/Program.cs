
namespace _8_Event_Args
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Bill Gates", new Account(100));
            user1.account.Notify += DisplayMessage;
            user1.AccountAction += DisplayUserMessage;

            user1.Put(100);
            user1.Take(120);
            user1.Take(100);
            user1.Put(100);

            static void DisplayMessage(object? sender, AccoutEventArgs e) // Метод обработки событий 
            {
                Console.WriteLine("Ответ банка: " + e.Message + e.Sum + ". Баланс средств: " + e.Balance);
                Console.WriteLine("---------------------------------------------------------------------");
                Console.ResetColor();
            }
            static void DisplayUserMessage(object? sender, AccoutEventArgs e) // Метод обработки событий 
            {
                if (sender is User user)
                {
                    Console.WriteLine(e.Message + e.Sum + " клиентом: " + user.UserName);
                }
            }

        }
    }
    public class Account
    {
        public EventHandler<AccoutEventArgs>? Notify; // 1. Define an event
        public int Balance { get; set; } = 0;
        public Account(int sum) { this.Balance = sum; }
        public void Put(int sum)
        {
            Balance += sum;
            Notify?.Invoke(this, new AccoutEventArgs("Положено на счет ", sum, Balance)); // 2. Raise Event
        }
        public void Take(int sum)
        {
            if (Balance >= sum)
            {
                Balance -= sum;
                Notify?.Invoke(this, new AccoutEventArgs("Снято со счета ", sum, Balance)); // 2. Raise Event
            }
            else
            {
                //AccoutEventArgs args = new AccoutEventArgs();
                Console.ForegroundColor = ConsoleColor.Red;
                Notify?.Invoke(this, new AccoutEventArgs("Недостаточно денег для снятия ", sum, Balance)); // 2. Raise Event

            }
        }
        public override string ToString()
        {
            return "Accoutn object";
        }

    }
    public class AccoutEventArgs : EventArgs
    {
        public AccoutEventArgs(string? message, int sum, int balance)
        {
            Message = message;
            Sum = sum;
            Balance = balance;
        }
        public string? Message { get; set; }
        public int Sum { get; set; }
        public int Balance { get; set; }
    }
    public class User
    {
        public EventHandler<AccoutEventArgs>? AccountAction;
        public string? UserName { get; set; }

        public Account account { get; set; }
        public User(string? userName, Account account)
        {
            UserName = userName;
            this.account = account;
        }
        public void Take(int sum)
        {
            AccountAction?.Invoke(this, new AccoutEventArgs("Попытка снятия со счета суммы в размере ", sum, account.Balance));
            account.Take(sum);
        }
        public void Put(int sum)
        {
            AccountAction?.Invoke(this, new AccoutEventArgs("Попытка положить на счет суммы в размере ", sum, account.Balance));
            account.Put(sum);
        }
    }
}