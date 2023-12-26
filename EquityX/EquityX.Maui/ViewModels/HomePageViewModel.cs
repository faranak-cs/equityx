using EquityX.Maui.Models;

namespace EquityX.Maui.ViewModels
{
    public static class HomePageViewModel
    {
        public static List<User> _users = new List<User>()
        {
            new User {Id=0, Name="Faran", Funds=0.00},
            new User {Id=1,Name="Khan", Funds=0.00}
        };

        // GET USER DETAILS USING ID
        public static User GetUserById(int userId)
        {
            var user = _users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                return new User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Funds = user.Funds,
                };
            }
            return null;
        }


        // ADD FUNDS LOGIC
        public static string AddFunds(int userId, double amount)
        {
            var user = _users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.Funds += amount;
                // AMOUNT IS ADDED
                return "y";
            }
            else
            {
                return "n";
            }
        }

        // WITHDRAW FUNDS LOGIC
        public static string WithdrawFunds(int userId, int amount)
        {
            var user = _users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.Funds -= amount;
                // AMOUNT IS WITHDRAWN
                return "y";
            }
            else
            {
                return "n";
            }
        }
    }
}
