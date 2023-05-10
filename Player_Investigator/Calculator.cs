using Player_Investigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Player_Investigator
{
    public class UserInfo
    {
        // Define your properties for user information here
        // ...

        // Example properties:
        public string SteamID { get; set; }
        public string Username { get; set; }
        public int TimePlayed { get; set; }
        public int NumFriends { get; set; }
        public int SteamLevel { get; set; }
        public DateTime AccountCreationDate { get; set; }
    }

    public class SmurfAccountChecker
    {
        private const int MaxScore = 100;

        // Define the weights for each factor
        private const int TimePlayedWeight = 30;
        private const int NumFriendsWeight = 20;
        private const int SteamLevelWeight = 25;
        private const int AccountAgeWeight = 25;

        // Define the thresholds or criteria for each factor
        private const int MaxTimePlayed = 100; // Example threshold for high time played
        private const int MinNumFriends = 10; // Example threshold for low number of friends
        private const int MinSteamLevel = 10; // Example threshold for low Steam level
        private const int MaxAccountAgeInDays = 365; // Example threshold for new accounts

        public static double CheckSmurfAccount(
            int timePlayed, int numFriends, int steamLevel, DateTime accountCreationDate)
        {
            // Calculate individual scores for each factor
            int timePlayedScore = CalculateScore(timePlayed, MaxTimePlayed) * TimePlayedWeight;
            int numFriendsScore = CalculateScore(numFriends, MinNumFriends) * NumFriendsWeight;
            int steamLevelScore = CalculateScore(steamLevel, MinSteamLevel) * SteamLevelWeight;
            int accountAgeScore = CalculateAccountAgeScore(accountCreationDate) * AccountAgeWeight;

            // Calculate the overall score
            int overallScore = timePlayedScore + numFriendsScore + steamLevelScore + accountAgeScore;

            // Convert the score to a percentage
            double percentage = (double)overallScore / MaxScore * 100;

            return percentage;
        }

        private static int CalculateScore(int value, int threshold)
        {
            if (value <= threshold)
            {
                return MaxScore;
            }

            double ratio = (double)threshold / value;
            return (int)(MaxScore * ratio);
        }

        private static int CalculateAccountAgeScore(DateTime accountCreationDate)
        {
            TimeSpan age = DateTime.Now - accountCreationDate;
            int accountAgeInDays = (int)age.TotalDays;

            if (accountAgeInDays <= MaxAccountAgeInDays)
            {
                return MaxScore;
            }

            double ratio = (double)MaxAccountAgeInDays / accountAgeInDays;
            return (int)(MaxScore * ratio);
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Example usage
            int timePlayed = 50;
            int numFriends = 5;
            int steamLevel = 8;
            DateTime accountCreationDate = new DateTime(2022, 1, 1);

            double smurfPercentage = SmurfAccountChecker.CheckSmurfAccount(timePlayed, numFriends, steamLevel, accountCreationDate);
            Console.WriteLine($"Likelihood of smurf account: {smurfPercentage}%");
        }
    }
}
