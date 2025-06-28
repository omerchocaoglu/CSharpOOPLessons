using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp
{
    class Program
    {
        static void Main()
        {
            var userManager = new UserManager();
            var categoryManager = new CategoryManager();
            var votingManager = new VotingManager(userManager, categoryManager);

            Console.WriteLine("=== Voting Uygulamasýna Hoþgeldiniz ===");
            votingManager.StartVoting();
            votingManager.ShowResults();

            Console.WriteLine("Uygulama sonlandýrýldý.");
        }
    }
    public class User
    {
        public string Username { get; set; }
    }
    public class Category
    {
        public string Name { get; set; }
        public int VoteCount { get; set; } = 0;
    }
    public class UserManager
    {
        private readonly HashSet<string> _registeredUsers = new HashSet<string>();

        public bool IsRegistered(string username) => _registeredUsers.Contains(username);

        public void RegisterUser(string username)
        {
            if (!_registeredUsers.Contains(username))
            {
                _registeredUsers.Add(username);
            }
        }
    }
    public class CategoryManager
    {
        public List<Category> Categories { get; }

        public CategoryManager()
        {
            Categories = new List<Category>
        {
            new Category { Name = "Film Kategorileri" },
            new Category { Name = "Tech Stack Kategorileri" },
            new Category { Name = "Spor Kategorileri" }
        };
        }

        public void DisplayCategories()
        {
            for (int i = 0; i < Categories.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {Categories[i].Name}");
            }
        }
    }
    public class VotingManager
    {
        private readonly UserManager _userManager;
        private readonly CategoryManager _categoryManager;

        public VotingManager(UserManager userManager, CategoryManager categoryManager)
        {
            _userManager = userManager;
            _categoryManager = categoryManager;
        }

        public void StartVoting()
        {
            while (true)
            {
                Console.Write("Kullanýcý adýnýzý giriniz (Çýkmak için 'exit'): ");
                var username = Console.ReadLine();

                if (username?.ToLower() == "exit") break;

                if (!_userManager.IsRegistered(username))
                {
                    Console.WriteLine("Kullanýcý kayýtlý deðil. Kayýt olmak ister misiniz? (E/H)");
                    var cevap = Console.ReadLine();
                    if (cevap?.ToUpper() == "E")
                    {
                        _userManager.RegisterUser(username);
                        Console.WriteLine("Kayýt tamamlandý. Oy verebilirsiniz.");
                    }
                    else
                    {
                        Console.WriteLine("Oylama için kayýt olmanýz gerekir.");
                        continue;
                    }
                }

                _categoryManager.DisplayCategories();
                Console.Write("Oy vermek istediðiniz kategori numarasýný giriniz: ");
                if (int.TryParse(Console.ReadLine(), out int secim) && secim > 0 && secim <= _categoryManager.Categories.Count)
                {
                    _categoryManager.Categories[secim - 1].VoteCount++;
                    Console.WriteLine("Oyunuz alýndý. Teþekkürler!");
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim.");
                }
            }
        }
        public void ShowResults()
        {
            int totalVotes = 0;
            foreach (var c in _categoryManager.Categories)
            {
                totalVotes += c.VoteCount;
            }

            Console.WriteLine("\n--- Oylama Sonuçlarý ---");
            foreach (var c in _categoryManager.Categories)
            {
                double percentage = totalVotes > 0 ? (double)c.VoteCount / totalVotes * 100 : 0;
                Console.WriteLine($"{c.Name}: {c.VoteCount} oy ({percentage:F2}%)");
            }
        }
    }
}
