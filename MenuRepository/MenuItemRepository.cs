using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuRepository
{
    public class MenuItemRepository

    {
        private List<MenuItem> _listOfMenuItem = new List<MenuItem>();

        //Create
        public void AddItemToMenu(MenuItem foodItem)
        {
            _listOfMenuItem.Add(foodItem);
        }

        //Read
        public List<MenuItem> GetMenuItemList()
        {
            return _listOfMenuItem;
        }

        //Update
        public bool UpdateExistingMenuItem(int originalMealNumber, MenuItem newMenuItem)
        {
            // Find the menu item
            MenuItem oldMenuItem = GetMenuItemBytMealNumber(originalMealNumber);

            // Update the menu item
            if (oldMenuItem != null)
            {
                oldMenuItem.MealNumber = newMenuItem.MealNumber;
                oldMenuItem.MealName = newMenuItem.MealName;
                oldMenuItem.Description = newMenuItem.Description;
                oldMenuItem.Ingredients = newMenuItem.Ingredients;


                return true;
            }
            else
            {
                return false;
            }
        }

    //Delete
    public bool RemoveMenuItemFromList(int mealNumber)
    {
        MenuItem foodItem = GetMenuItemBytMealNumber(mealNumber);

        if (foodItem == null)
        {
            return false;
        }

        int initialCount = _listOfMenuItem.Count;
        _listOfMenuItem.Remove(foodItem);

        if (initialCount > _listOfMenuItem.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    //Helper method
    public MenuItem GetMenuItemBytMealNumber(int mealNumber)
    {
        foreach (MenuItem foodName in _listOfMenuItem)
        {
            if (foodName.MealNumber == mealNumber)
            {
                return foodName;
            }
        }
        return null;
    }

}
}
