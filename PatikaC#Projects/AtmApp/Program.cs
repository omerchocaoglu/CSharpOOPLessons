using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApp
{
    class Program
    {
        static void Main()
        {
            var userManager = new UserManager();
            var transactionManager = new TransactionManager();
            var logger = new Logger(Environment.CurrentDirectory);

            Console.WriteLine("ATM Uygulamasýna Hoþgeldiniz");

            while (true)
            {
                Console.Write("Kullanýcý adý: ");
                string username = Console.ReadLine();

                if (!userManager.IsRegistered(username))
                {
                    Console.WriteLine("Kullanýcý kayýtlý deðil. Kayýt olmak ister misiniz? (E/H)");
                    string cevap = Console.ReadLine();
                    if (cevap?.ToUpper() == "E")
                    {
                        // Yeni kullanýcý oluþtur (bakiye sýfýr)
                        // Ýstersen bu kýsmý geniþletebilirsin
                        Console.WriteLine("Kayýt iþlemi yapýlmadý, demo amaçlý kayýt gereklidir.");
                        continue;
                    }
                    else
                    {
                        transactionManager.LogFraudAttempt(username);
                        Console.WriteLine("Giriþ reddedildi.");
                        continue;
                    }
                }

                var user = userManager.GetUser(username);

                Console.WriteLine($"Hoþgeldiniz, {user.Username}. Bakiyeniz: {user.Balance} TL");

                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\nYapmak istediðiniz iþlemi seçin:");
                    Console.WriteLine("1 - Para Çekme");
                    Console.WriteLine("2 - Para Yatýrma");
                    Console.WriteLine("3 - Ödeme Yapma");
                    Console.WriteLine("4 - Gün Sonu Raporu");
                    Console.WriteLine("5 - Çýkýþ");

                    string secim = Console.ReadLine();

                    switch (secim)
                    {
                        case "1":
                            Console.Write("Çekmek istediðiniz tutar: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal cekmeTutar))
                            {
                                if (transactionManager.Withdraw(user, cekmeTutar))
                                    Console.WriteLine("Ýþlem baþarýlý.");
                                else
                                    Console.WriteLine("Yetersiz bakiye veya geçersiz tutar.");
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz tutar.");
                            }
                            break;

                        case "2":
                            Console.Write("Yatýrmak istediðiniz tutar: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal yatirmaTutar))
                            {
                                if (transactionManager.Deposit(user, yatirmaTutar))
                                    Console.WriteLine("Ýþlem baþarýlý.");
                                else
                                    Console.WriteLine("Geçersiz tutar.");
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz tutar.");
                            }
                            break;

                        case "3":
                            Console.Write("Ödeme tutarý: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal odemeTutar))
                            {
                                if (transactionManager.Payment(user, odemeTutar))
                                    Console.WriteLine("Ýþlem baþarýlý.");
                                else
                                    Console.WriteLine("Yetersiz bakiye veya geçersiz tutar.");
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz tutar.");
                            }
                            break;

                        case "4":
                            logger.WriteEndOfDayReport(transactionManager.Transactions);
                            Console.WriteLine("Gün sonu raporu oluþturuldu.");
                            break;

                        case "5":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Geçersiz seçim.");
                            break;
                    }
                }

                Console.WriteLine("Baþka kullanýcý var mý? (E/H)");
                var devam = Console.ReadLine();
                if (devam?.ToUpper() != "E")
                    break;
            }

            Console.WriteLine("Uygulama sonlandýrýldý.");
        }
    }
    public class User
    {
        public string Username { get; set; }
        public decimal Balance { get; set; }
    }
    public class Transaction
    {
        public string Username { get; set; }
        public string Type { get; set; } // Para Çekme, Yatýrma, Ödeme
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }
        public bool IsFraud { get; set; } = false;
    }
    public class UserManager
    {
        private readonly Dictionary<string, User> _users = new Dictionary<string, User>();

        public UserManager()
        {
            // Örnek kullanýcýlar
            _users.Add("user1", new User { Username = "user1", Balance = 1000 });
            _users.Add("user2", new User { Username = "user2", Balance = 500 });
        }

        public bool IsRegistered(string username)
        {
            return _users.ContainsKey(username);
        }

        public User GetUser(string username)
        {
            _users.TryGetValue(username, out var user);
            return user;
        }
    }
    public class TransactionManager
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();

        public IEnumerable<Transaction> Transactions => _transactions;

        public bool Withdraw(User user, decimal amount)
        {
            if (user.Balance >= amount && amount > 0)
            {
                user.Balance -= amount;
                LogTransaction(user.Username, "Para Çekme", amount, false);
                return true;
            }
            return false;
        }

        public bool Deposit(User user, decimal amount)
        {
            if (amount > 0)
            {
                user.Balance += amount;
                LogTransaction(user.Username, "Para Yatýrma", amount, false);
                return true;
            }
            return false;
        }

        public bool Payment(User user, decimal amount)
        {
            if (user.Balance >= amount && amount > 0)
            {
                user.Balance -= amount;
                LogTransaction(user.Username, "Ödeme", amount, false);
                return true;
            }
            return false;
        }
        private void LogTransaction(string username, string type, decimal amount, bool isFraud)
        {
            _transactions.Add(new Transaction
            {
                Username = username,
                Type = type,
                Amount = amount,
                Time = DateTime.Now,
                IsFraud = isFraud
            });
        }
        public void LogFraudAttempt(string username)
        {
            _transactions.Add(new Transaction
            {
                Username = username,
                Type = "Hatalý Giriþ",
                Amount = 0,
                Time = DateTime.Now,
                IsFraud = true
            });
        }
    }
    public class Logger
    {
        private readonly string _logDirectory;

        public Logger(string logDirectory)
        {
            _logDirectory = logDirectory;

            if (!Directory.Exists(_logDirectory))
                Directory.CreateDirectory(_logDirectory);
        }

        public void WriteEndOfDayReport(IEnumerable<Transaction> transactions)
        {
            string fileName = $"EOD_{DateTime.Now:ddMMyyyy}.txt";
            string filePath = Path.Combine(_logDirectory, fileName);

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine("Gün Sonu Raporu");
                writer.WriteLine("=================");
                writer.WriteLine();

                var normalTransactions = transactions.Where(t => !t.IsFraud).ToList();
                var fraudTransactions = transactions.Where(t => t.IsFraud).ToList();

                writer.WriteLine("Ýþlemler:");
                foreach (var t in normalTransactions)
                {
                    writer.WriteLine($"{t.Time}: {t.Username} - {t.Type} - {t.Amount} TL");
                }

                writer.WriteLine();
                writer.WriteLine("Hatalý Giriþ Denemeleri:");
                foreach (var t in fraudTransactions)
                {
                    writer.WriteLine($"{t.Time}: {t.Username} - {t.Type}");
                }
            }
        }
    }

}
