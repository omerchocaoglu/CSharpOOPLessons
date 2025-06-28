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

            Console.WriteLine("=== Voting Uygulamas�na Ho�geldiniz ===");
            votingManager.StartVoting();
            votingManager.ShowResults();

            Console.WriteLine("Uygulama sonland�r�ld�.");
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
                Console.Write("Kullan�c� ad�n�z� giriniz (��kmak i�in 'exit'): ");
                var username = Console.ReadLine();

                if (username?.ToLower() == "exit") break;

                if (!_userManager.IsRegistered(username))
                {
                    Console.WriteLine("Kullan�c� kay�tl� de�il. Kay�t olmak ister misiniz? (E/H)");
                    var cevap = Console.ReadLine();
                    if (cevap?.ToUpper() == "E")
                    {
                        _userManager.RegisterUser(username);
                        Console.WriteLine("Kay�t tamamland�. Oy verebilirsiniz.");
                    }
                    else
                    {
                        Console.WriteLine("Oylama i�in kay�t olman�z gerekir.");
                        continue;
                    }
                }

                _categoryManager.DisplayCategories();
                Console.Write("Oy vermek istedi�iniz kategori numaras�n� giriniz: ");
                if (int.TryParse(Console.ReadLine(), out int secim) && secim > 0 && secim <= _categoryManager.Categories.Count)
                {
                    _categoryManager.Categories[secim - 1].VoteCount++;
                    Console.WriteLine("Oyunuz al�nd�. Te�ekk�rler!");
                }
                else
                {
                    Console.WriteLine("Ge�ersiz se�im.");
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

            Console.WriteLine("\n--- Oylama Sonu�lar� ---");
            foreach (var c in _categoryManager.Categories)
            {
                double percentage = totalVotes > 0 ? (double)c.VoteCount / totalVotes * 100 : 0;
                Console.WriteLine($"{c.Name}: {c.VoteCount} oy ({percentage:F2}%)");
            }
        }
    }
}
