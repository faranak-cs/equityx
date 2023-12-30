using EquityX.Maui.FileHandler;
using EquityX.Maui.Models;

namespace EquityX.Maui.ViewModels;

public static class HomePageViewModel
{

    /// <summary>
    /// USERS' LIST
    /// </summary>
    public static List<User> _users = new List<User>()
    {
        new User {Id=0, Name="Faran", Funds=0.00},
        new User {Id=1,Name="Khan", Funds=0.00}
    };

    ///// <summary>
    ///// HOMEPAGEVIEWMODEL CONSTRUCTOR
    ///// </summary>
    //static HomePageViewModel()
    //{
    //    LoadFunds();
    //}

    // FILE PATH "FUNDS.JSON"
    private static string path = StorageManager.GetFilePath("funds.json");

    // STORE DATA INTO FILE
    private static void StoreFunds()
    {
        StorageManager.StoreToFile(path, _users);
    }

    // LOAD DATA FROM FILE
    private static void LoadFunds()
    {
        var Users = StorageManager.LoadFromFile<List<User>>(path);

        if (Users != null)
        {
            _users = Users;
        }
    }

    /// <summary>
    /// GET USERS
    /// </summary>
    /// <returns></returns>
    public static List<User> GetUsers()
    {
        LoadFunds();
        return _users;
    }

    /// <summary>
    /// GET USER DETAILS USING ID
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static User GetUserById(int userId)
    {
        LoadFunds();

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
        LoadFunds();
        var user = _users.FirstOrDefault(x => x.Id == userId);
        if (user != null)
        {
            // AMOUNT IS ADDED
            user.Funds += amount;

            StoreFunds();

            return "y";
        }
        else
        {
            return "n";
        }
    }

    // WITHDRAW FUNDS LOGIC
    public static string WithdrawFunds(int userId, double amount)
    {
        LoadFunds();
        var user = _users.FirstOrDefault(x => x.Id == userId);
        if (user != null)
        {
            if (amount <= user.Funds)
            {
                // AMOUNT IS WITHDRAWN
                user.Funds -= amount;

                StoreFunds();

                return "y";
            }
            else
            {
                return "n";
            }
        }
        else
        {
            return "n";
        }
    }

    // UPDATE FUNDS
    public static void UpdateFunds(int userId, double amount, string status)
    {
        if (status == "increase")
        {
            _users[userId].Funds += amount;
        }
        else if (status == "decrease")
        {
            _users[userId].Funds -= amount;
        }

        StoreFunds();
    }
}
