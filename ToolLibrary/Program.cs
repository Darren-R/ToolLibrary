using System;

public class Program
{
    public static void Main(string[] args)
    {
        ToolLibrary toolLibrary = new ToolLibrary();

        toolLibrary.AddTool(new Tool("Shovel", "A tool for digging", "gardening tools", 5));
        toolLibrary.AddTool(new Tool("Zammer", "A tool for driving nails", "construction tools", 10));
        toolLibrary.AddTool(new Tool("Rake", "A tool for gathering leaves", "gardening tools", 3));
        toolLibrary.AddTool(new Tool("Hammer", "A tool for driving nails", "construction tools", 10));
        toolLibrary.AddTool(new Tool("Screwdriver", "A tool for driving screws", "construction tools", 7));
        toolLibrary.AddTool(new Tool("Wrench", "A tool for tightening bolts", "automotive tools", 4));
        toolLibrary.AddTool(new Tool("Steering Wheel", "A spare streering wheel", "automotive tools", 1));
        toolLibrary.AddTool(new Tool("Allen Key", "Tightens things", "construction tools", 99));

        while (true)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Display tools by type");
            Console.WriteLine("2. Add new tool");
            Console.WriteLine("3. Lend tool");
            Console.WriteLine("4. Return tool");
            Console.WriteLine("5. Exit");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    toolLibrary.PrintAllowedToolTypes();
                    Console.WriteLine("Enter the tool type:");
                    string toolTypeToDisplay = Console.ReadLine();
                    toolLibrary.DisplayToolsByType(toolTypeToDisplay);
                    break;
                case 2:
                    Console.WriteLine("Enter the tool name:");
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
                    Console.WriteLine("Enter the tool name:");
                    string toolName = Console.ReadLine();
                    Console.WriteLine("Enter the tool type:");
                    string toolType = Console.ReadLine();
                    Console.WriteLine("Enter borrower's full name:");
                    string fullName = Console.ReadLine();
                    Console.WriteLine("Enter borrower's phone number:");
                    string phoneNumber = Console.ReadLine();
                    toolLibrary.LendTool(toolName, toolType, fullName, phoneNumber);
                    break;
                case 4:
                    Console.WriteLine("Enter the tool name:");
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
