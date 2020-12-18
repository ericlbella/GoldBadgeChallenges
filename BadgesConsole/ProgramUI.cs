using BadgesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesConsole
{
    class ProgramUI
    {
        private BadgeRepostiory _badgeRepo = new BadgeRepostiory();

        // Method that runs/starts the application
        public void Run()
        {
            SeedBadgeDictionary();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                // Display our options to the user
                Console.WriteLine("Hello Security Admin, What would you like to do?\n\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Add a badge
                        AddABadge();
                        break;
                    case "2":
                        // Update a badge
                        UpdateABadge();
                        break;
                    case "3":
                        // List all badges
                        ListAllBadges();
                        break;
                    case "4":
                        // Exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        // Create new Badge
        private void AddABadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            List<string> Doors = new List<string>();

            // BadgeID
            Console.WriteLine("What is the number on the badge?");
            string badgeNumber = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeNumber);

            Console.WriteLine("List a door that it needs access to:");
            string door = Console.ReadLine();
            Doors.Add(door);

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Any other doors (y/n).  Type y for yes or n for no.");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
                        // Add another door
                        Console.WriteLine("List a door that it needs access to:");
                        string door2 = Console.ReadLine();
                        Doors.Add(door2);
                        break;
                    case "n":
                        keepRunning = false;
                        break;
                }

            }

            newBadge.Doors = Doors;
            _badgeRepo.AddBadgeToDictionary(newBadge);
        }

        private void UpdateABadge()
        {
            Badge newBadge = new Badge();

            Console.Clear();
            // Ask for the Badge ID of the badge we want to update
            Console.WriteLine("What is the badge number to update?");

            // Get that badge
            string oldBadge = Console.ReadLine();
            newBadge.BadgeID = int.Parse(oldBadge);

            KeyValuePair<int, List<string>> dictionaryBadge = _badgeRepo.GetBadgeByBadgeID(newBadge.BadgeID);

            string badgeKeyValuePair = string.Join(", ", dictionaryBadge.Value);
            Console.WriteLine(dictionaryBadge.Key + " has access to  " + badgeKeyValuePair)
                ;
            Console.WriteLine("What would you like to do?\n\n" +
                "1. Remove a door.\n" +
                "2. Add a door.");

            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("Which door would you like to remove?");
                string door = Console.ReadLine();
                _badgeRepo.RemoveDoorFromBadge(newBadge.BadgeID, door);

            }
            else
            {
                Console.WriteLine("Which door would you like to add?");
                string door = Console.ReadLine();

                // Verify the update worked
                _badgeRepo.UpdateDoorToBadge(newBadge.BadgeID, door);

            }
        }

        private void ListAllBadges()
        {
            Dictionary<int, List<string>> dictionaryBadge = _badgeRepo.GetBadgeDictionary();

            foreach (KeyValuePair<int, List<string>> badgeKeyValuePair in dictionaryBadge)
            {
                /*string x = "Hello";
                string y = "Eric";
                Console.WriteLine(x + " " + y);
                Console.WriteLine($"{x} {y}");
                Console.WriteLine("{0} {1}", x, y);*/

                int badgeKeyValuePair2 = badgeKeyValuePair.Key;
                string badgeKeyValuePair3 = string.Join(", ", badgeKeyValuePair.Value);
                Console.WriteLine(badgeKeyValuePair2 + " " + badgeKeyValuePair3);
            }
        }

        // Seed Method
        private void SeedBadgeDictionary()
        {
            List<string> doors = new List<string>();
            doors.Add("A7");
            Badge badge = new Badge(12345, doors);

            List<string> doors2 = new List<string>();
            doors2.Add("A1");
            doors2.Add("A4");
            doors2.Add("B1");
            doors2.Add("B2");
            Badge badge2 = new Badge(22345, doors2);

            List<string> doors3 = new List<string>();
            doors3.Add("A4");
            doors3.Add("A5");
            Badge badge3 = new Badge(32345, doors3);

            _badgeRepo.AddBadgeToDictionary(badge);
            _badgeRepo.AddBadgeToDictionary(badge2);
            _badgeRepo.AddBadgeToDictionary(badge3);

            //string interpolation
        }
    }
}
