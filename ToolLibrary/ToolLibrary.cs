public class ToolLibrary
{
    private ToolNode ToolHead { get; set; }
    private BorrowerNode BorrowerHead { get; set; }
    private string[] AllowedToolTypes { get; set; }

    public ToolLibrary()
    {
        BorrowerHead = null;
        ToolHead = null;
        AllowedToolTypes = new string[9]
        {
            "gardening tools",
            "flooring tools",
            "fencing tools",
            "measuring tools",
            "cleaning tools",
            "painting tools",
            "electronic tools",
            "electricity tools",
            "automotive tools"
        };
    }

    public void PrintAllowedToolTypes()
    {
        Console.Write("Existing tool types are: ");
        for (int i = 0; i < AllowedToolTypes.Length; i++)
        {
            if (i == AllowedToolTypes.Length - 1)
            {
                Console.Write(AllowedToolTypes[i]);
            }
            else
            {
                Console.Write(AllowedToolTypes[i] + ", ");
            }
        }
        Console.WriteLine();
    }


    public void AddTool(Tool tool)
    {
        ToolNode newNode = new ToolNode(tool);
        if (ToolHead == null)
        {
            ToolHead = newNode;
        }
        else
        {
            ToolNode currentNode = ToolHead;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = newNode;
        }

        ToolHead = ToolSort.BubbleSortTools(ToolHead);
    }



    public void AddOrUpdateTool(string name, string description, string type, int quantity)
    {
        if (!AllowedToolTypes.Contains(type))
        {
            Console.WriteLine($"Invalid tool type: {type}. Please enter a valid tool type.");
            return;
        }

        ToolNode currentNode = ToolHead;
        Tool existingTool = null;

        while (currentNode != null)
        {
            if (currentNode.Tool.Name == name && currentNode.Tool.Type == type)
            {
                existingTool = currentNode.Tool;
                break;
            }
            currentNode = currentNode.Next;
        }

        if (existingTool != null)
        {
            existingTool.Quantity += quantity;
            Console.WriteLine($"Updated quantity for {name}: {existingTool.Quantity}");
        }
        else
        {
            Tool newTool = new Tool(name, description, type, quantity);
            AddTool(newTool);
            Console.WriteLine($"Added new tool: {name}");
        }
    }


    private void AddBorrower(BorrowerNode newNode)
    {
        if (BorrowerHead == null)
        {
            BorrowerHead = newNode;
        }
        else
        {
            BorrowerNode currentNode = BorrowerHead;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = newNode;
        }
    }

    public BorrowerNode FindBorrowerNode(string toolName, string fullName)
    {
        BorrowerNode currentNode = BorrowerHead;

        while (currentNode != null)
        {
            if (currentNode.Borrower.FullName == fullName &&
                currentNode.Borrower.BorrowedTool.Name == toolName)
            {
                return currentNode;
            }

            currentNode = currentNode.Next;
        }

        return null;
    }


    public void LendTool(string toolName, string toolType, string fullName, string phoneNumber)
    {
        ToolNode currentNode = ToolHead;
        Tool tool = null;

        while (currentNode != null)
        {
            if (currentNode.Tool.Name == toolName && currentNode.Tool.Type == toolType)
            {
                tool = currentNode.Tool;
                break;
            }
            currentNode = currentNode.Next;
        }

        if (tool.Quantity == 0)
        {
            Console.WriteLine($"Tool not available: {toolName}");
            return;
        }

        tool.Quantity--;
        Borrower borrower = new Borrower(fullName, phoneNumber, tool);
        AddBorrower(new BorrowerNode(borrower));
        Console.WriteLine($"Lent tool {toolName} to {fullName}");
        BorrowerHead.PrintBorrowers();
    }

    public void ReturnTool(string toolName, string toolType, string fullName)
    {
        ToolNode currentNode = ToolHead;
        Tool tool = null;

        while (currentNode != null)
        {
            if (currentNode.Tool.Name == toolName && currentNode.Tool.Type == toolType)
            {
                tool = currentNode.Tool;
                break;
            }
            currentNode = currentNode.Next;
        }

        if (tool == null)
        {
            Console.WriteLine($"Tool not found: {toolName}");
            return;
        }

        var borrowerNode = FindBorrowerNode(toolName, fullName);

        if (borrowerNode == null)
        {
            Console.WriteLine($"Borrower not found: {fullName}");
            return;
        }

        tool.Quantity++;
        var nodeToRemove = borrowerNode;
        BorrowerHead = BorrowerHead.Remove(nodeToRemove);
        Console.WriteLine($"Returned tool {toolName} from {fullName}");
        if (BorrowerHead != null)
        {
            BorrowerHead.PrintBorrowers();
        }
        else
        {
            Console.WriteLine("No tools currently outstanding");
        }
    }


    public void DisplayToolsByType(string type)
    {
        type = type.ToLower();

        ToolNode currentNode = ToolHead;
        List<Tool> selectedTools = new List<Tool>();

        while (currentNode != null)
        {
            if (currentNode.Tool.Type.ToLower() == type)
            {
                selectedTools.Add(currentNode.Tool);
            }
            currentNode = currentNode.Next;
        }

        if (selectedTools.Count == 0)
        {
            Console.WriteLine($"No tools found of type: {type}\n");
            return;
        }

        Console.WriteLine($"Tools of type: {type}");
        foreach (var tool in selectedTools)
        {
            string availability = tool.Quantity > 0 ? "Available" : "Not Available";
            Console.WriteLine($"{tool.Name} - {tool.Description} - {availability}");
        }
        Console.WriteLine("");
    }
}