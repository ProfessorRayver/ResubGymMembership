using System;
using System.Collections.Generic;
namespace GymMemSystem2;
class Program
{
    static GymLogic gymLogic = new GymLogic();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nWELCOME TO DIWATA GYM OVERLOAD!\nUNLI BUHAT, UNLI WEIGHTS, UNLI PAWIS!\n");
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. Remove Member");
            Console.WriteLine("3. Display Members");
            Console.WriteLine("4. Update Payment Status");
            Console.WriteLine("5. Search Member Status");
            Console.WriteLine("6. Show Workout Routines");
            Console.WriteLine("7. Exit");
            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1") AddMember();
            else if (choice == "2") RemoveMember();
            else if (choice == "3") DisplayMembers();
            else if (choice == "4") UpdatePaymentStatus();
            else if (choice == "6") ShowWorkoutRoutines();
            else if (choice == "7") break;
            else if (choice == "5") SearchMemberStatus();
            else Console.WriteLine("Wrong Input. Try again!!\n");
        }
    }

    static void AddMember()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter membership type (normal or special): ");
        string membershipType = Console.ReadLine();

        Console.Write("Enter the month the member registered: ");
        string month = Console.ReadLine();

        gymLogic.AddMember(name, membershipType, month);
        Console.WriteLine("Member added successfully, Thank you!\n");
    }

    static void RemoveMember()
    {
        Console.Write("Enter name to REMOVE: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name does not exist. Please enter a valid name.\n");
            return;
        }

        gymLogic.RemoveMember(name);
        Console.WriteLine("Member removed!\n");
    }

    static void DisplayMembers()
    {
        List<GymData.Member> members = gymLogic.GetMembers();
        if (members.Count == 0)
        {
            Console.WriteLine("\nNo members registered at the moment.\n");
            return;
        }

        Console.WriteLine("\nList of Members:");
        foreach (var member in members)
        {
            Console.WriteLine("Name: " + member.Name +
                              ", Membership: " + member.MembershipType +
                              ", Month: " + member.Month +
                              ", Payment Status: " + member.PaymentStatus);
        }
        Console.WriteLine();
    }

    static void ShowWorkoutRoutines()
    {
        List<string> routines = gymLogic.GetWorkoutRoutines();
        Console.WriteLine("\nAvailable Workout Routines:");
        for (int i = 0; i < routines.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + routines[i]);
        }
        Console.WriteLine();
    }

    static void UpdatePaymentStatus()
    {
        Console.Write("Enter name of the member to update payment status: ");
        string name = Console.ReadLine();

        Console.Write("Enter new payment status (Paid/Unpaid): ");
        string status = Console.ReadLine();

        Console.Write("Enter the month the member is valid as paid (n/a if not paid): ");
        string validMonth = Console.ReadLine();

        if (gymLogic.UpdatePaymentStatus(name, status, validMonth))
        {
            Console.WriteLine("Payment status and valid month updated successfully!\n");
        }
        else
        {
            Console.WriteLine("Member not found.\n");
        }
    }

    static void SearchMemberStatus()
    {
        Console.Write("Enter the name of the member to search: ");
        string name = Console.ReadLine();

        string result = gymLogic.SearchMemberStatus(name);
        Console.WriteLine(result);
    }
}
