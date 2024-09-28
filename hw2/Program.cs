using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Transactions;
using hw2;
using LibraryContext db = new LibraryContext();


List<string> menuItems =
    ["Get All",
        "Add",
        "Edit",
        "Exit"
];
ConsoleKeyInfo key;
int count = 0;
for (int i = 0; i < menuItems.Count; i++)
{
    if (i == count)
        Console.WriteLine($"> {menuItems[i]}");
    else Console.WriteLine(menuItems[i]);
}
while (true)
{
    key = Console.ReadKey();
    Console.Clear();
    switch (key.Key)
    {
        case ConsoleKey.UpArrow:
            count--;
            break;

        case ConsoleKey.DownArrow:
            count++;
            break;
        case ConsoleKey.Enter:
            if (count == 0) GetAll();
            else if (count == 1) AddAuthor();
            else if (count == 2) EditAuthor();
            else if (count == 3) return 0;
            break;

    }
    if (count < 0) count = menuItems.Count - 1;
    for (int i = 0; i < menuItems.Count; i++)
    {
        if (i == count % menuItems.Count)
            Console.WriteLine($"> {menuItems[i]}");
        else Console.WriteLine(menuItems[i]);
    }


    static void LoadDatabase()
    {
        Thread.Sleep(5000);
    }

    static void ShowLoadingIndicator()
    {
        int percentage = 100;

        for (int i = 0; i <= percentage; i++)
        {
            Console.Write($"\rLoading: {i}%");
            Thread.Sleep(100);
        }

        Console.WriteLine();
    }


    void GetAll()
    {
        Console.WriteLine("Starting database load...");

        Thread loadingThread = new Thread(LoadDatabase);
        loadingThread.Start();

        ShowLoadingIndicator();

        loadingThread.Join();

        Console.WriteLine("Database loaded successfully!");
        var authors = db.Authors.ToList();
        authors.ForEach(Console.WriteLine);
        Console.WriteLine();
    }
    void AddAuthor()
    {
        Console.WriteLine("Starting database load...");

        Thread loadingThread = new Thread(LoadDatabase);
        loadingThread.Start();

        ShowLoadingIndicator();

        loadingThread.Join();

        Console.WriteLine("Database loaded successfully!");
        Console.Clear();
        Console.WriteLine("Enter author's name and surname ");
        string user_name = Console.ReadLine()!;
        string user_surname = Console.ReadLine()!;
        Author author = new Author()
        {

            FirstName = user_name,
            LastName = user_surname,
        };

        db.Authors.Add(author);
        db.SaveChanges();
    }
   
    void EditAuthor()
    {
        Console.WriteLine("Starting database load...");

        Thread loadingThread = new Thread(LoadDatabase);
        loadingThread.Start();

        ShowLoadingIndicator();

        loadingThread.Join();

        Console.WriteLine("Database loaded successfully!");

        Console.Clear();
        Console.WriteLine("Enter author's name and surname ");
        string user_name = Console.ReadLine()!;
        string user_surname = Console.ReadLine()!;
        var existingAuthor = db.Authors.FirstOrDefault(a => a.FirstName.Equals(user_name, StringComparison.OrdinalIgnoreCase) &&
                              a.LastName.Equals(user_surname, StringComparison.OrdinalIgnoreCase));

        if (existingAuthor == null)
        {
            Console.WriteLine("Author not found in the database.");
        }
        else
        {
            Console.WriteLine("Enter new first name (leave blank to keep current):");
            string newFirstName = Console.ReadLine()!;
            Console.WriteLine("Enter new last name (leave blank to keep current):");
            string newLastName = Console.ReadLine()!;
            existingAuthor.FirstName = newFirstName;
            existingAuthor.LastName = newLastName;
        }



    }
}