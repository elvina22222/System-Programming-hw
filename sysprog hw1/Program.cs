using System.Collections.Generic;
using System.Diagnostics;
using System.Transactions;

//1.Get List all Process +
//2. Start process by Name +  
//3. Kill process by Id +
//4. Kill processes by Name +
//5. Add Black list
//6. Remove from Black list
//7. Exit

Console.WriteLine("1. Get List all Process");
Console.WriteLine("2. Start process by Name");
Console.WriteLine("3. Kill process by Id");
Console.WriteLine("4. Kill processes by Name");
Console.WriteLine("5. Add Black list");
Console.WriteLine("6. Remove from Black list");
Console.WriteLine("7. Exit");

List<string> processNames = [];

string choice = Console.ReadLine()!;

switch (choice)
{
    case "1":
        var AllProcesses = Process.GetProcesses();

        foreach (var process in AllProcesses)
        {
            Console.WriteLine($"{process.Id} - {process.ProcessName}");
        }
        break;
    case "2":
        Console.WriteLine("Enter process name");
        var processname = Console.ReadLine()!;
        Process.Start(processname);
        break;
    case "3":
        Console.WriteLine("Enter process ID:");
        var processID = Console.ReadLine()!;
        if (int.TryParse(processID, out int processId))
        {
            Process processid = Process.GetProcessById(processId);
            processid.Kill();
        }
        else
        {
            Console.WriteLine("Wrong ID.");
        }
        break;
    case "4":
        Console.WriteLine("Enter process ID:");
        var processName = Console.ReadLine()!;

        var processn = Process.GetProcessesByName(processName);
        foreach (var process in processn)
        {
            process.Kill();
        }
        break;
    case "5":
        Console.WriteLine("Enter process to add to Black List:");
        var processN = Console.ReadLine()!;
        processNames.Add(processN);
        foreach (var process in processNames)
        {
            var processnm = Process.GetProcessesByName(process);
            foreach (var proc in processnm)
            {
                proc.Kill();
            }
        }
    break;
    case "6":
        Console.WriteLine("Enter process to remove from Black List:");
        var processRemove = Console.ReadLine()!;
        processNames.Remove(processRemove);
        break;
    case "7":
        Environment.Exit(0);
        break;
    default:
        Console.WriteLine("Invalid choice. Please try again.");
        break;
}
    