using System;

public class Program
{
    public static void Main(string[] args)
    {
        ToolLibrary toolLibrary = new ToolLibrary();

        toolLibrary.AddTool(new Tool("Shovel", "A tool for digging", "gardening tools", 5));
        toolLibrary.AddTool(new Tool("Drill", "A tool for drilling", "electronic tools", 10));
        toolLibrary.AddTool(new Tool("Rake", "A tool for gathering leaves", "gardening tools", 3));
        toolLibrary.AddTool(new Tool("Wrench", "A tool for tightening bolts", "automotive tools", 4));
        toolLibrary.AddTool(new Tool("Steering Wheel", "A spare streering wheel", "automotive tools", 0));

        while (true)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Display tools by type");
            Console.WriteLine("2. Add new tool");
            Console.WriteLine("3. Lend tool");
            Console.WriteLine("4. Return tool");
            Console.WriteLine("5. Exit");
            Console.Write("Input: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    toolLibrary.PrintAllowedToolTypes();
                    Console.Write("Enter the tool type: ");
                    string toolTypeToDisplay = Console.ReadLine();
                    toolLibrary.DisplayToolsByType(toolTypeToDisplay);
                    break;
                case 2:
                    Console.WriteLine("\nEnter the tool name:");
                    string newName = Console.ReadLine();
                    Console.WriteLine("Enter the tool description:");
                    string newDescription = Console.ReadLine();
                    Console.WriteLine("Enter the tool type:");
                    string newType = Console.ReadLine();
                    Console.WriteLine("Enter the tool quantity:");
                    int newQuantity = int.Parse(Console.ReadLine());
                    toolLibrary.AddOrUpdateTool(newName, newDescription, newType, newQuantity);
                    break;
                case 3:
                    Console.WriteLine("\nEnter the tool name:");
                    string toolName = Console.ReadLine();
                    Console.WriteLine("Enter the tool type:");
                    string toolType = Console.ReadLine();
                    Console.WriteLine("Enter borrower's full name:");
                    string fullName = Console.ReadLine();
                    Console.WriteLine("Enter borrower's phone number (if no valid number press 5 to exit):");
                    string phoneNumber = Console.ReadLine();
                    int parsedPhoneNumber;
                    while (true)
                    {
                        if (phoneNumber == "5")
                        {
                            Environment.Exit(0);
                        }

                        phoneNumber = phoneNumber.Replace(" ", "");

                        if (int.TryParse(phoneNumber, out parsedPhoneNumber))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid phone number. Please enter a phone number with only integers and spaces (press 5 to exit):");
                            phoneNumber = Console.ReadLine();
                        }
                    }
                    toolLibrary.LendTool(toolName, toolType, fullName, phoneNumber);
                    break;
                case 4:
                    Console.WriteLine("\nEnter the tool name:");
                    string returnToolName = Console.ReadLine();
                    Console.WriteLine("Enter the tool type:");
                    string returnToolType = Console.ReadLine();
                    Console.WriteLine("Enter borrower's full name:");
                    string returnFullName = Console.ReadLine();
                    toolLibrary.ReturnTool(returnToolName, returnToolType, returnFullName);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
