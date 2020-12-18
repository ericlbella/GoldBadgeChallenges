using MenuRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeConsole
{
    public class ProgramUI
    {
        private MenuItemRepository _menuItemRepo = new MenuItemRepository();
        // Method that runs/starts the application
        public void Run()
        {
            SeedMenuItemList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a Meal Number\n" +
                    "2. View All Meal Numbers\n" +
                    "3. View Meal By Meal Number\n" +
                    "4. Upate Existing Meal Number\n" +
                    "5. Delete Exising Meal Number\n" +
                    "6. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Add a Meal Number
                        AddAMealNumber();
                        break;
                    case "2":
                        // View All Meal Numbers
                        DisplayAllMealNumbers();
                        break;
                    case "3":
                        // View Meal By Meal Number
                        DisplayMealByMealNumber();
                        break;
                    case "4":
                        // Update Existing Meal Number
                        UpdateExistingMealNumber();
                        break;
                    case "5":
                        // Delete Existing Meal Number
                        DeleteExistingMealNumber();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("Goodbye!");
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

        // Create new MenuItem
        private void AddAMealNumber()
        {
            Console.Clear();
            MenuItem newMenuItem = new MenuItem();

            // Meal Number
            Console.WriteLine("Enter the meal number for the meal:");
            string mealNumber = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(mealNumber);

            // Meal Name
            Console.WriteLine("Enter a meal name for the meal:");
            newMenuItem.MealName = Console.ReadLine();

            // Description
            Console.WriteLine("Enter the description for the meal:");
            newMenuItem.Description = Console.ReadLine();

            // Ingredients
            Console.WriteLine("Please enter the first ingredient for your meal");
            string ingredient = Console.ReadLine();
            List<string> Ingredients = new List<string>();
            Ingredients.Add(ingredient);

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Do you want to add another ingredient.  Type y for yes or n for no.");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
                        // Add another ingredient
                        Console.WriteLine("What is your next ingredient.");
                        string ingredient2 = Console.ReadLine();
                        Ingredients.Add(ingredient2);
                        break;
                    case "n":
                        keepRunning = false;
                        break;

                }
            }

            newMenuItem.Ingredients = Ingredients;

            // Price
            Console.WriteLine("Please enter the price for the meal.");
            string mealPrice = Console.ReadLine();
            newMenuItem.Price = decimal.Parse(mealPrice);

            _menuItemRepo.AddItemToMenu(newMenuItem);
        }


        // View All Meal Numbers
        private void DisplayAllMealNumbers()
        {
            Console.Clear();
            List<MenuItem> listOfMenuItems = _menuItemRepo.GetMenuItemList();
            
            foreach (MenuItem foodItem in listOfMenuItems)
            {
                Console.WriteLine($"Meal Number: {foodItem.MealNumber}");
                Console.WriteLine($"Meal Name: {foodItem.MealName}");
                Console.WriteLine($"Description: {foodItem.Description}");
                Console.WriteLine("This meal has the following ingredients:");

                if (foodItem.Ingredients != null)
                {
                    foreach (string ingredient in foodItem.Ingredients)
                    {
                        Console.WriteLine(ingredient);
                    }
                }
                else
                {
                    Console.WriteLine("This meal doesn't have any ingredients.");
                }
                Console.WriteLine(foodItem.Price);
                        
            }
        }    
        

        // View Meal By Meal Number
        private void DisplayMealByMealNumber()
        {
            Console.Clear();
            // Prompt the user to give me a Meal Number
            Console.WriteLine("Enter the meal number of the meal you'd like to see:");

            // Get the user's input
            string foodItem = Console.ReadLine();
            int mealNumber = int.Parse(foodItem);

            // Find the meal by that Meal Number
            MenuItem foodItem2 = _menuItemRepo.GetMenuItemBytMealNumber(mealNumber);

            // Display said meal number if it isn't null
            if (foodItem2 != null)
            {
                Console.WriteLine($"Meal Number: {foodItem2.MealNumber}");
                Console.WriteLine($"Meal Name: {foodItem2.MealName}");
                Console.WriteLine($"Description: {foodItem2.Description}");
                Console.WriteLine("This meal has the following ingredients:");

                if (foodItem2.Ingredients != null)
                {
                    foreach (string ingredient in foodItem2.Ingredients)
                    {
                        Console.WriteLine(ingredient);
                    }
                }
                else
                {
                    Console.WriteLine("This meal doesn't have any ingredients.");
                }
                Console.WriteLine(foodItem2.Price);
            }
            else
            {
                Console.WriteLine("No meal by that meal number.");

            }
        }

        // Update Existing Meal Number
        private void UpdateExistingMealNumber()
        {
            // Display all meals
            DisplayAllMealNumbers();

            // Ask for the meal number of the meal to update
            Console.WriteLine("Enter the meal number of the meal that you'd like to update:");

            // Get that meal number
            string foodItem = Console.ReadLine();
            int oldMealNumber = int.Parse(foodItem);

            // Build new object
            MenuItem newMenuItem = new MenuItem();

            // Meal Number
            Console.WriteLine("Enter the meal number for the meal:");
            string mealNumber = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(mealNumber);

            // Meal Name
            Console.WriteLine("Enter a meal name for the meal:");
            newMenuItem.MealName = Console.ReadLine();

            // Description
            Console.WriteLine("Enter the description for the meal:");
            newMenuItem.Description = Console.ReadLine();

            // Ingredients
            Console.WriteLine("Please enter the first ingredient for your meal");
            string ingredient = Console.ReadLine();
            List<string> Ingredients = new List<string>();
            Ingredients.Add(ingredient);

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Do you want to add another ingredient.  Type y for yes or n for no.");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
                        // Add another ingredient
                        Console.WriteLine("What is your next ingredient.");
                        string ingredient2 = Console.ReadLine();
                        Ingredients.Add(ingredient2);
                        break;
                    case "n":
                        keepRunning = false;
                        break;

                }
            }

            // Verify the update worked
            bool wasUpdated = _menuItemRepo.UpdateExistingMenuItem(oldMealNumber, newMenuItem);

            if (wasUpdated)
            {
                Console.WriteLine("Meal number sucessfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update the meal number.");
            }
        }

        // Delete Existing Meal Number
        private void DeleteExistingMealNumber()
        {
            DisplayAllMealNumbers();

            // Get the meal they want to remove
            Console.WriteLine("\nEnter the meal number of the meal you'd like to remove:");

            string input = Console.ReadLine();
            int mealNumber = int.Parse(input);

            // Call the delete method
            bool wasDeleted = _menuItemRepo.RemoveMenuItemFromList(mealNumber);

            // If the meal was deleted, say so
            // Otherwise state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The meal was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The meal cold not be deleted.");
            }
            
        }

        // Seed method
        private void SeedMenuItemList()
        {

            List<string> ingredients = new List<string>();
            ingredients.Add("Pepperoni");
            ingredients.Add("Sausage");
            ingredients.Add("Tomato");

            MenuItem foodItem = new MenuItem(1, "Pizza", "The best pizza in the whole world!", ingredients, 5.00m);

            _menuItemRepo.AddItemToMenu(foodItem);
    }

    }
}

