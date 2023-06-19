using System;
using System.Collections.Generic;

class ShoppingListApp
{
    static void Main()
    {
        Console.WriteLine("Welcome to Shopping List App!");

        List<string> shoppingList = new List<string>();

        bool continueShopping = true;

        while (continueShopping)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Add item to the shopping list");
            Console.WriteLine("2. Remove item from the shopping list");
            Console.WriteLine("3. Mark item as purchased");
            Console.WriteLine("4. View shopping list");
            Console.WriteLine("5. Search for an item");
            Console.WriteLine("6. Sort shopping list");
            Console.WriteLine("7. Clear shopping list");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the item to add: ");
                    string newItem = Console.ReadLine();
                    shoppingList.Add(newItem);
                    Console.WriteLine("Item added to the shopping list.");
                    break;
                case "2":
                    Console.Write("Enter the item to remove: ");
                    string itemToRemove = Console.ReadLine();
                    bool removed = shoppingList.Remove(itemToRemove);
                    if (removed)
                    {
                        Console.WriteLine("Item removed from the shopping list.");
                    }
                    else
                    {
                        Console.WriteLine("Item not found in the shopping list.");
                    }
                    break;
                case "3":
                    Console.Write("Enter the item to mark as purchased: ");
                    string itemToMark = Console.ReadLine();
                    bool found = false;
                    for (int i = 0; i < shoppingList.Count; i++)
                    {
                        if (shoppingList[i] == itemToMark)
                        {
                            shoppingList[i] = "[Purchased] " + itemToMark;
                            found = true;
                            Console.WriteLine("Item marked as purchased: " + itemToMark);
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Item not found in the shopping list.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Shopping List:");
                    if (shoppingList.Count > 0)
                    {
                        for (int i = 0; i < shoppingList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {shoppingList[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The shopping list is empty.");
                    }
                    break;
                case "5":
                    Console.Write("Enter the item to search for: ");
                    string itemToSearch = Console.ReadLine();
                    List<string> searchResults = SearchItems(shoppingList, itemToSearch);
                    if (searchResults.Count > 0)
                    {
                        Console.WriteLine("Search results for '" + itemToSearch + "':");
                        foreach (string result in searchResults)
                        {
                            Console.WriteLine("- " + result);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No items found matching the search criteria.");
                    }
                    break;
                case "6":
                    Console.WriteLine("How would you like to sort the shopping list?");
                    Console.WriteLine("1. Sort in alphabetical order");
                    Console.WriteLine("2. Sort in reverse alphabetical order");
                    Console.Write("Enter your choice: ");
                    string sortChoice = Console.ReadLine();
                    SortShoppingList(shoppingList, sortChoice);
                    Console.WriteLine("Shopping list sorted.");
                    break;
                case "7":
                    Console.WriteLine("Are you sure you want to clear the shopping list? (Y/N)");
                    string confirmation = Console.ReadLine();
                    if (confirmation.ToUpper() == "Y")
                    {
                        shoppingList.Clear();
                        Console.WriteLine("Shopping list cleared.");
                    }
                    break;
                case "8":
                    continueShopping = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("\nThank you for using the Shopping List App!");
    }

    static List<string> SearchItems(List<string> shoppingList, string searchQuery)
    {
        List<string> searchResults = new List<string>();
        foreach (string item in shoppingList)
        {
            if (item.Contains(searchQuery))
            {
                searchResults.Add(item);
            }
        }
        return searchResults;
    }

    static void SortShoppingList(List<string> shoppingList, string sortChoice)
    {
        switch (sortChoice)
        {
            case "1":
                shoppingList.Sort();
                break;
            case "2":
                shoppingList.Sort();
                shoppingList.Reverse();
                break;
            default:
                Console.WriteLine("Invalid sort choice. Shopping list will not be sorted.");
                break;
        }
    }
}
